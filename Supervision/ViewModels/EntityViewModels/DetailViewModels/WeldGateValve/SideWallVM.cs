﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve
{
    public class SideWallVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<SideWall> allInstances;
        private ICollectionView allInstancesView;
        private SideWall selectedItem;
        private ICommand removeItem;
        private ICommand editItem;
        private ICommand addItem;
        private ICommand copyItem;
        private ICommand closeWindow;

        private string name;
        private string number = "";
        private string drawing = "";
        private string status = "";
        private string certificate = "";

        #region Filter
        public string Number 
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is SideWall item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Drawing
        {
            get => drawing;
            set
            {
                drawing = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is SideWall item && item.Drawing != null)
                    {
                        return item.Drawing.ToLower().Contains(Drawing.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Status
        {
            get => status;
            set
            {
                status = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is SideWall item && item.Status != null)
                    {
                        return item.Status.ToLower().Contains(Status.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Certificate
        {
            get => certificate;
            set
            {
                certificate = value;
                RaisePropertyChanged();
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is SideWall item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
                    }
                    else return false;
                };
            }
        }
        #endregion

        #region Commands              
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (
                    closeWindow = new DelegateCommand<Window>((w) =>
                    {
                        w?.Close();
                    }));
            }
        }
        public ICommand EditItem
        {
            get
            {
                return editItem ?? (
                    editItem = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedItem != null)
                        {
                            var wn = new SideWallEditView();
                            var vm = new SideWallEditVM(SelectedItem.Id, SelectedItem);
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand CopyItem
        {
            get
            {
                return copyItem ?? (
                    copyItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            var item = new SideWall()
                            {
                                Number = Microsoft.VisualBasic.Interaction.InputBox("Введите номер детали:"),
                                Drawing = SelectedItem.Drawing,
                                Certificate = SelectedItem.Certificate,
                                Status = SelectedItem.Status,
                                Name = SelectedItem.Name,
                                MetalMaterialId = SelectedItem.MetalMaterialId
                            };
                            db.SideWalls.Add(item);
                            db.SaveChanges();
                            var Journal = db.SideWallJournals.Where(i => i.DetailId == SelectedItem.Id).ToList();
                            foreach (var record in Journal)
                            {
                                var Record = new SideWallJournal()
                                {
                                    Date = record.Date,
                                    DetailId = item.Id,
                                    Description = record.Description,
                                    DetailName = item.Name,
                                    DetailNumber = item.Number,
                                    DetailDrawing = item.Drawing,
                                    InspectorId = record.InspectorId,
                                    Point = record.Point,
                                    PointId = record.PointId,
                                    RemarkIssued = record.RemarkIssued,
                                    RemarkClosed = record.RemarkClosed,
                                    Comment = record.Comment,
                                    Status = record.Status,
                                    JournalNumber = record.JournalNumber
                                };
                                db.SideWallJournals.Add(Record);
                                db.SaveChanges();
                            }

                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }

        public ICommand AddItem
        {
            get
            {
                return addItem ?? (
                    addItem = new DelegateCommand<Window>((w) =>
                    {
                        var item = new SideWall();
                        db.SideWalls.Add(item);
                        db.SaveChanges();
                        SelectedItem = item;
                        var tcpPoints = db.SideWallTCPs.ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new SideWallJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                DetailName = SelectedItem.Name,
                                DetailNumber = SelectedItem.Number,
                                DetailDrawing = SelectedItem.Drawing,
                                Point = i.Point,
                                Description = i.Description
                            };
                            if (journal != null)
                            {
                                db.SideWallJournals.Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new SideWallEditView();
                        var vm = new SideWallEditVM(SelectedItem.Id, SelectedItem);
                        wn.DataContext = vm;
                        w?.Close();
                        wn.ShowDialog();
                    }));
            }
        }
        public ICommand RemoveItem
        {
            get
            {
                return removeItem ?? (
                    removeItem = new DelegateCommand(() =>
                    {
                        if (SelectedItem != null)
                        {
                            db.SideWalls.Remove(SelectedItem);
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Объект не выбран!", "Ошибка");
                    }));
            }
        }
        #endregion

        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        public SideWall SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SideWall> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged();
            }
        }
        public ICollectionView AllInstancesView
        {
            get => allInstancesView;
            set
            {
                allInstancesView = value;
                RaisePropertyChanged();
            }
        }

        public SideWallVM()
        {
            db = new DataContext();
            db.SideWalls.Include(i => i.MetalMaterial).Load();
            AllInstances = db.SideWalls.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            if (AllInstances.Count() != 0)
            {
                Name = AllInstances.First().Name;
            }
        }
    }
}