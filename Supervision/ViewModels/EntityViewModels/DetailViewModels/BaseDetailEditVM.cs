﻿using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Supervision.Views.EntityViews.DetailViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class BaseDetailEditVM<TEntity, TUser, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : BaseDetail, new()
        where TUser : Inspector
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<TEntityTCP> points;
        private IEnumerable<TUser> inspectors;
        private IEnumerable<TEntityJournal> journal;

        private TEntity selectedItem;
        private TEntityTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public TEntity SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntityJournal> Journal
        {
            get { return journal; }
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<TEntityTCP> Points
        {
            get { return points; }
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public IEnumerable<TUser> Inspectors
        {
            get { return inspectors; }
            set
            {
                inspectors = value;
                RaisePropertyChanged("Inspectors");
            }
        }

        public ICommand SaveItem
        {
            get
            {
                return saveItem ?? (
                    saveItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            db.Set<TEntity>().Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in Journal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.Set<TEntityJournal>().UpdateRange(Journal);
                            db.SaveChanges();
                            
                        }
                        else
                        {
                            MessageBox.Show("Объект не найден!", "Ошибка");
                        }

                    }));
            }
        }
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        var wn = new BaseDetailView();
                        var vm = new BaseDetailVM<TEntity, TEntityTCP, TEntityJournal>();
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();
                    }));
            }
        }
        public ICommand AddOperation
        {
            get
            {
                return addOperation ?? (
                    addOperation = new DelegateCommand(() =>
                    {
                        if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
                        else
                        {
                            var item = new TEntityJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.Set<TEntityJournal>().Add(item);
                            db.SaveChanges();
                            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }

        public IEnumerable<string> Materials
        {
            get { return materials; }
            set
            {
                materials = value;
                RaisePropertyChanged("Materials");
            }
        }
        public IEnumerable<string> Drawings
        {
            get { return drawings; }
            set
            {
                drawings = value;
                RaisePropertyChanged("Drawings");
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get { return journalNumbers; }
            set
            {
                journalNumbers = value;
                RaisePropertyChanged("JournalNumbers");
            }
        }

        public TEntityTCP SelectedTCPPoint
        {
            get { return selectedTCPPoint; }
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged("SelectedTCPPoint");
            }
        }

        public BaseDetailEditVM(int id)
        {
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Find(id);
            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Select(i => i.Number).Distinct().ToList();
            Materials = db.Set<TEntity>().Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.Set<TEntity>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Set<TUser>().OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
        }
    }
}
