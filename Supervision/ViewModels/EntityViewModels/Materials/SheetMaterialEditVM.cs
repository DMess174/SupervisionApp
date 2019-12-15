﻿using DataLayer;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer.TechnicalControlPlans.Materials;
using DataLayer.Journals.Materials;
using DataLayer.Entities.Materials;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class SheetMaterialEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> materials;
        private IEnumerable<string> firstSize;
        private IEnumerable<string> secondSize;
        private IEnumerable<string> thirdSize;
        private IEnumerable<MetalMaterialTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<SheetMaterialJournal> journal;
        private readonly BaseTable parentEntity;
        private MetalMaterialTCP selectedTCPPoint;

        private SheetMaterial selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public SheetMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<SheetMaterialJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<MetalMaterialTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged("Points");
            }
        }
        public IEnumerable<Inspector> Inspectors
        {
            get => inspectors;
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
                            db.SheetMaterials.Update(SelectedItem);
                            db.SaveChanges();
                            if (Journal != null)
                            {
                                foreach (var i in Journal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                }
                                db.SheetMaterialJournals.UpdateRange(Journal);
                            }
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не найден!", "Ошибка");
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
                        if (!(parentEntity is SheetMaterial)) w?.Close();
                        else
                        {
                            var wn = new SheetMaterialView();
                            var vm = new SheetMaterialVM();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
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
                            var item = new SheetMaterialJournal()
                            {
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.SheetMaterialJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.SheetMaterialJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }

        public IEnumerable<string> Materials
        {
            get => materials;
            set
            {
                materials = value;
                RaisePropertyChanged("Materials");
            }
        }

        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged("JournalNumbers");
            }
        }

        public IEnumerable<string> FirstSize
        {
            get => firstSize;
            set
            {
                firstSize = value;
                RaisePropertyChanged("FirstSize");
            }
        }

        public IEnumerable<string> SecondSize
        {
            get => secondSize;
            set
            {
                secondSize = value;
                RaisePropertyChanged("SecondSize");
            }
        }

        public IEnumerable<string> ThirdSize
        {
            get => thirdSize;
            set
            {
                thirdSize = value;
                RaisePropertyChanged("ThirdSize");
            }
        }

        public MetalMaterialTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged("SelectedTCPPoint");
            }
        }

        public SheetMaterialEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.SheetMaterials.Find(id);
            Journal = db.Set<SheetMaterialJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Select(i => i.Number).Distinct().ToList();
            Materials = db.SheetMaterials.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            FirstSize = db.SheetMaterials.Select(t => t.FirstSize).Distinct().OrderBy(x => x).ToList();
            SecondSize = db.SheetMaterials.Select(t => t.SecondSize).Distinct().OrderBy(x => x).ToList();
            ThirdSize = db.SheetMaterials.Select(d => d.ThirdSize).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.MetalMaterialTCPs.ToList();
        }
    }
}
