﻿using DataLayer;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DataLayer.Entities.Materials;
using Supervision.Views.EntityViews.MaterialViews;
using DataLayer.Journals.Materials;

namespace Supervision.ViewModels.EntityViewModels.Materials
{
    public class RolledMaterialVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<RolledMaterial> allInstances;
        private ICollectionView allInstancesView;
        private RolledMaterial selectedItem;
        private ICommand removeItem;
        private ICommand editItem;
        private ICommand addItem;
        private ICommand copyItem;
        private ICommand closeWindow;

        private string name;
        private string number = "";
        private string pipeNumber = "";
        private string batch = "";
        private string material = "";
        private string certificate = "";
        private string melt = "";

        #region Filter
        public string Number 
        {
            get => number;
            set
            {
                number = value;
                RaisePropertyChanged("Number");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is RolledMaterial item && item.Number != null)
                    {
                        return item.Number.ToLower().Contains(Number.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string PipeNumber
        {
            get => pipeNumber;
            set
            {
                pipeNumber = value;
                RaisePropertyChanged("SheetNumber");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is RolledMaterial item && item.MaterialCertificateNumber != null)
                    {
                        return item.MaterialCertificateNumber.ToLower().Contains(PipeNumber.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Batch
        {
            get => batch;
            set
            {
                batch = value;
                RaisePropertyChanged("Batch");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is RolledMaterial item && item.Status != null)
                    {
                        return item.Batch.ToLower().Contains(Batch.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Material
        {
            get => material;
            set
            {
                material= value;
                RaisePropertyChanged("Material");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is RolledMaterial item && item.Material != null)
                    {
                        return item.Material.ToLower().Contains(Material.ToLower());
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
                RaisePropertyChanged("Certificate");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is RolledMaterial item && item.Certificate != null)
                    {
                        return item.Certificate.ToLower().Contains(Certificate.ToLower());
                    }
                    else return false;
                };
            }
        }
        public string Melt
        {
            get => melt;
            set
            {
                melt = value;
                RaisePropertyChanged("Melt");
                allInstancesView.Filter += (obj) =>
                {
                    if (obj is RolledMaterial item && item.Melt != null)
                    {
                        return item.Melt.ToLower().Contains(Melt.ToLower());
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
                            var wn = new RolledMaterialEditView();
                            var vm = new RolledMaterialEditVM(SelectedItem.Id, SelectedItem);
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
                            var item = new RolledMaterial()
                            {
                                Number = Microsoft.VisualBasic.Interaction.InputBox("Введите номер детали:"),
                                MaterialCertificateNumber = SelectedItem.MaterialCertificateNumber,
                                Material = SelectedItem.Material,
                                Melt = SelectedItem.Melt,
                                Batch = SelectedItem.Batch,
                                Certificate = SelectedItem.Certificate,
                                Status = SelectedItem.Status,
                                Name = SelectedItem.Name,
                                FirstSize = SelectedItem.FirstSize,
                                SecondSize = SelectedItem.SecondSize,
                                ThirdSize = SelectedItem.ThirdSize
                            };
                            db.RolledMaterials.Add(item);
                            db.SaveChanges();
                            var journal = db.RolledMaterialJournals.Where(i => i.DetailId == SelectedItem.Id).ToList();
                            foreach (var record in journal)
                            {
                                var Record = new RolledMaterialJournal()
                                {
                                    Date = record.Date,
                                    DetailId = item.Id,
                                    Description = record.Description,
                                    DetailName = item.Name,
                                    DetailNumber = item.Number,
                                    InspectorId = record.InspectorId,
                                    Point = record.Point,
                                    PointId = record.PointId,
                                    Remark = record.Remark,
                                    Status = record.Status,
                                    JournalNumber = record.JournalNumber
                                };
                                db.RolledMaterialJournals.Add(Record);
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
                        var item = new RolledMaterial();
                        db.RolledMaterials.Add(item);
                        db.SaveChanges();
                        SelectedItem = item;
                        var tcpPoints = db.MetalMaterialTCPs.ToList();
                        foreach (var i in tcpPoints)
                        {
                            var journal = new RolledMaterialJournal()
                            {
                                DetailId = SelectedItem.Id,
                                PointId = i.Id,
                                DetailName = SelectedItem.Name,
                                DetailNumber = SelectedItem.Number,
                                Point = i.Point,
                                Description = i.Description
                            };
                            if (journal != null)
                            {
                                db.RolledMaterialJournals.Add(journal);
                                db.SaveChanges();
                            }
                        }
                        var wn = new RolledMaterialEditView();
                        var vm = new RolledMaterialEditVM(SelectedItem.Id, SelectedItem);
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
                            db.RolledMaterials.Remove(SelectedItem);
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
                RaisePropertyChanged("Name");
            }
        }

        public RolledMaterial SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<RolledMaterial> AllInstances
        {
            get => allInstances;
            set
            {
                allInstances = value;
                RaisePropertyChanged("AllInstances");
            }
        }
        public ICollectionView AllInstancesView
        {
            get => allInstancesView;
            set
            {
                allInstancesView = value;
                RaisePropertyChanged("AllInstancesView");
            }
        }

        public RolledMaterialVM()
        {
            db = new DataContext();
            db.RolledMaterials.Load();
            AllInstances = db.RolledMaterials.Local.ToObservableCollection();
            AllInstancesView = CollectionViewSource.GetDefaultView(AllInstances);
            if (AllInstances.Count() != 0)
            {
                Name = AllInstances.First().Name;
            }
        }
    }
}
