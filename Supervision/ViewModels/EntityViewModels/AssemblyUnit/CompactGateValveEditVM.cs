using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.CompactGateValve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve;
using Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating;
using Supervision.Views.EntityViews;
using Supervision.Views.EntityViews.AssemblyUnit;
using Supervision.Views.EntityViews.DetailViews.CompactGateValve;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;
using Supervision.Views.EntityViews.MaterialViews.AnticorrosiveCoating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnit
{
    public class CompactGateValveEditVM : BasePropertyChanged
    {
        #region Main
        private readonly BaseTable parentEntity;
        private readonly DataContext db;
        private CompactGateValve selectedItem;

        private IEnumerable<string> journalNumbers;
        private IEnumerable<string> drawings;

        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<string> JournalNumbers
        {
            get => journalNumbers;
            set
            {
                journalNumbers = value;
                RaisePropertyChanged();
            }
        }
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<CompactGateValveJournal> assemblyJournal;
        private IEnumerable<CompactGateValveJournal> assemblyPreparationJournal;

        private ICommand saveItem;
        private ICommand closeWindow;
        private IEnumerable<CompactGateValveJournal> testJournal;
        private IEnumerable<CompactGateValveJournal> afterTestJournal;
        private IEnumerable<CompactGateValveJournal> documentationJournal;
        private IEnumerable<CompactGateValveJournal> shippingJournal;
        private IEnumerable<CoatingJournal> coatingJournal;

        public CompactGateValve SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<CompactGateValveJournal> AssemblyPreparationJournal
        {
            get => assemblyPreparationJournal;
            set
            {
                assemblyPreparationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CompactGateValveJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CompactGateValveJournal> TestJournal
        {
            get => testJournal;
            set
            {
                testJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CompactGateValveJournal> AfterTestJournal
        {
            get => afterTestJournal;
            set
            {
                afterTestJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CompactGateValveJournal> DocumentationJournal
        {
            get => documentationJournal;
            set
            {
                documentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CompactGateValveJournal> ShippingJournal
        {
            get => shippingJournal;
            set
            {
                shippingJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingJournal> CoatingJournal
        {
            get => coatingJournal;
            set
            {
                coatingJournal = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Inspector> Inspectors
        {
            get => inspectors;
            set
            {
                inspectors = value;
                RaisePropertyChanged();
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
                            if (SelectedItem.WeldGateValveCaseId != null)
                            {
                                var detail = db.CompactGateValveCases.Include(i => i.BaseWeldValve).SingleOrDefault(i => i.Id == SelectedItem.WeldGateValveCaseId);
                                if (detail?.BaseWeldValve != null && detail.BaseWeldValve.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Корпус применен в {detail.BaseWeldValve.Name} № {detail.BaseWeldValve.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.WeldGateValveCoverId != null)
                            {
                                var detail = db.CompactGateValveCovers.Include(i => i.BaseWeldValve).SingleOrDefault(i => i.Id == SelectedItem.WeldGateValveCoverId);
                                if (detail?.BaseWeldValve != null && detail.BaseWeldValve.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Крышка применена в {detail.BaseWeldValve.Name} № {detail.BaseWeldValve.Number}", "Ошибка");
                                    return;
                                }
                            }
                            if (SelectedItem.ShutterId != null)
                            {
                                var detail = db.Shutters.Include(i => i.BaseValve).SingleOrDefault(i => i.Id == SelectedItem.ShutterId);
                                if (detail?.BaseValve != null && detail.BaseValve.Id != SelectedItem.Id)
                                {
                                    MessageBox.Show($"Затвор применен в {detail.BaseValve.Name} № {detail.BaseValve.Number}", "Ошибка");
                                    return;
                                }
                            }
                            db.Set<CompactGateValve>().Update(SelectedItem);
                            db.SaveChanges();
                            db.Set<CompactGateValveJournal>().UpdateRange(AssemblyPreparationJournal);
                            db.Set<CompactGateValveJournal>().UpdateRange(AssemblyJournal);
                            db.Set<CompactGateValveJournal>().UpdateRange(AfterTestJournal);
                            db.Set<CoatingJournal>().UpdateRange(CoatingJournal);
                            db.Set<CompactGateValveJournal>().UpdateRange(TestJournal);
                            db.Set<CompactGateValveJournal>().UpdateRange(DocumentationJournal);
                            db.Set<CompactGateValveJournal>().UpdateRange(ShippingJournal);
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
                        if (db.Entry(SelectedItem).State == EntityState.Modified)
                        {
                            MessageBoxResult result = MessageBox.Show("Закрыть без сохранения изменений?", "Выход", MessageBoxButton.YesNo);
                            if (result == MessageBoxResult.Yes)
                            {
                                if (parentEntity is CompactGateValve)
                                {
                                    var wn = new CompactGateValveView();
                                    var vm = new CompactGateValveVM();
                                    wn.DataContext = vm;
                                    w?.Close();
                                    wn.ShowDialog();
                                }
                                else w?.Close();
                            }
                            else return;
                        }
                        else
                        {
                            if (parentEntity is CompactGateValve)
                            {
                                var wn = new CompactGateValveView();
                                var vm = new CompactGateValveVM();
                                wn.DataContext = vm;
                                w?.Close();
                                wn.ShowDialog();
                            }
                            else w?.Close();
                        }
                    }));
            }
        }
        #endregion

        #region Case
        private IEnumerable<CompactGateValveCase> cases;
        private ICommand editCase;

        public ICommand EditCase
        {
            get
            {
                return editCase ?? (
                           editCase = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.WeldGateValveCaseId != null)
                               {
                                   var wn = new WeldGateValveCaseEditView();
                                   var vm = new WeldGateValveCaseEditVM<CompactGateValveCase, CompactGateValveCaseTCP, CompactGateValveCaseJournal>(SelectedItem.WeldGateValveCase.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<CompactGateValveCase> Cases
        {
            get => cases;
            set
            {
                cases = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Cover
        private IEnumerable<CompactGateValveCover> covers;
        private ICommand editCover;

        public ICommand EditCover
        {
            get
            {
                return editCover ?? (
                           editCover = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.WeldGateValveCoverId != null)
                               {
                                   var wn = new WeldGateValveCoverEditView();
                                   var vm = new WeldGateValveCoverEditVM<CompactGateValveCover, CompactGateValveCoverTCP, CompactGateValveCoverJournal>(SelectedItem.WeldGateValveCover.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<CompactGateValveCover> Covers
        {
            get => covers;
            set
            {
                covers = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Shutter
        private IEnumerable<Shutter> shutters;
        private ICommand editShutter;

        public ICommand EditShutter
        {
            get
            {
                return editShutter ?? (
                           editShutter = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.GateId != null)
                               {
                                   var wn = new ShutterEditView();
                                   var vm = new ShutterEditVM(SelectedItem.Shutter.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<Shutter> Shutters
        {
            get => shutters;
            set
            {
                shutters = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Saddle
        private IEnumerable<Saddle> saddles;
        private Saddle selectedSaddle;
        private Saddle selectedSaddleFromList;
        private ICommand editSaddle;
        private ICommand addSaddleToValve;
        private ICommand deleteSaddleFromValve;

        public Saddle SelectedSaddle
        {
            get => selectedSaddle;
            set
            {
                selectedSaddle = value;
                RaisePropertyChanged();
            }
        }
        public Saddle SelectedSaddleFromList
        {
            get => selectedSaddleFromList;
            set
            {
                selectedSaddleFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddSaddleToValve
        {
            get
            {
                return addSaddleToValve ?? (
                           addSaddleToValve = new DelegateCommand(() =>
                           {
                               if (SelectedItem.Saddles.Count() < 2)
                               {
                                   if (SelectedSaddle != null)
                                   {
                                       var item = SelectedSaddle;
                                       item.BaseValveId = SelectedItem.Id;
                                       db.Saddles.Update(item);
                                       db.SaveChanges();
                                       Saddles = null;
                                       Saddles = db.Saddles.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 седел!", "Ошибка");
                           }));
            }
        }
        public ICommand EditSaddle
        {
            get
            {
                return editSaddle ?? (
                           editSaddle = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedSaddleFromList != null)
                               {
                                   var wn = new SaddleEditView();
                                   var vm = new SaddleEditVM(SelectedSaddleFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteSaddleFromValve
        {
            get
            {
                return deleteSaddleFromValve ?? (
                    deleteSaddleFromValve = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedSaddleFromList != null)
                        {
                            var item = SelectedSaddleFromList;
                            item.BaseValveId = null;
                            db.Saddles.Update(item);
                            db.SaveChanges();
                            Saddles = null;
                            Saddles = db.Saddles.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }
        public IEnumerable<Saddle> Saddles
        {
            get => saddles;
            set
            {
                saddles = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CounterFlange
        private IEnumerable<CounterFlange> counterFlanges;
        private CounterFlange selectedCounterFlange;
        private CounterFlange selectedCounterFlangeFromList;
        private ICommand editCounterFlange;
        private ICommand addCounterFlangeToValve;
        private ICommand deleteCounterFlangeFromValve;

        public CounterFlange SelectedCounterFlange
        {
            get => selectedCounterFlange;
            set
            {
                selectedCounterFlange = value;
                RaisePropertyChanged();
            }
        }
        public CounterFlange SelectedCounterFlangeFromList
        {
            get => selectedCounterFlangeFromList;
            set
            {
                selectedCounterFlangeFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddCounterFlangeToValve
        {
            get
            {
                return addCounterFlangeToValve ?? (
                           addCounterFlangeToValve = new DelegateCommand(() =>
                           {
                               if (SelectedItem.CounterFlanges.Count() < 2)
                               {
                                   if (SelectedCounterFlange != null)
                                   {
                                       var item = SelectedCounterFlange;
                                       item.BaseValveId = SelectedItem.Id;
                                       db.CounterFlanges.Update(item);
                                       db.SaveChanges();
                                       CounterFlanges = null;
                                       CounterFlanges = db.CounterFlanges.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 фланцев!", "Ошибка");
                           }));
            }
        }
        public ICommand EditCounterFlange
        {
            get
            {
                return editCounterFlange ?? (
                           editCounterFlange = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedCounterFlangeFromList != null)
                               {
                                   var wn = new CounterFlangeEditView();
                                   var vm = new CounterFlangeEditVM(SelectedCounterFlangeFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteCounterFlangeFromValve
        {
            get
            {
                return deleteCounterFlangeFromValve ?? (
                    deleteCounterFlangeFromValve = new DelegateCommand<Window>((w) =>
                    {
                        if (SelectedCounterFlangeFromList != null)
                        {
                            var item = SelectedCounterFlangeFromList;
                            item.BaseValveId = null;
                            db.CounterFlanges.Update(item);
                            db.SaveChanges();
                            CounterFlanges = null;
                            CounterFlanges = db.CounterFlanges.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                        }
                        else MessageBox.Show("Объект не выбран", "Ошибка");
                    }));
            }
        }
        public IEnumerable<CounterFlange> CounterFlanges
        {
            get => counterFlanges;
            set
            {
                counterFlanges = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ShearPin
        private IEnumerable<ShearPin> shearPins;
        private ShearPin selectedShearPin;
        private ShearPin selectedShearPinFromList;
        private ICommand editShearPin;
        private ICommand addShearPinToValve;
        private ICommand deleteShearPinFromValve;

        public ShearPin SelectedShearPin
        {
            get => selectedShearPin;
            set
            {
                selectedShearPin = value;
                RaisePropertyChanged();
            }
        }
        public ShearPin SelectedShearPinFromList
        {
            get => selectedShearPinFromList;
            set
            {
                selectedShearPinFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddShearPinToValve
        {
            get
            {
                return addShearPinToValve ?? (
                           addShearPinToValve = new DelegateCommand(() =>
                           {
                               if (SelectedItem.ShearPins.Count() < 6)
                               {
                                   if (SelectedShearPin != null)
                                   {
                                       var item = SelectedShearPin;
                                       item.BaseValveId = SelectedItem.Id;
                                       db.ShearPins.Update(item);
                                       db.SaveChanges();
                                       ShearPins = null;
                                       ShearPins = db.ShearPins.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 6 штифтов!", "Ошибка");
                           }));
            }
        }
        public ICommand EditShearPin
        {
            get
            {
                return editShearPin ?? (
                           editShearPin = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedShearPinFromList != null)
                               {
                                   var wn = new ShearPinEditView();
                                   var vm = new ShearPinEditVM(SelectedShearPinFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteShearPinFromValve
        {
            get
            {
                return deleteShearPinFromValve ?? (
                           deleteShearPinFromValve = new DelegateCommand(() =>
                           {
                               if (SelectedShearPinFromList != null)
                               {
                                   var item = SelectedShearPinFromList;
                                   item.BaseValveId = null;
                                   db.ShearPins.Update(item);
                                   db.SaveChanges();
                                   ShearPins = null;
                                   ShearPins = db.ShearPins.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public IEnumerable<ShearPin> ShearPins
        {
            get => shearPins;
            set
            {
                shearPins = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ScrewStud
        private IEnumerable<ScrewStud> screwStuds;
        private ScrewStud selectedScrewStud;
        private BaseValveWithScrewStud selectedScrewStudFromList;
        private ICommand editScrewStud;
        private ICommand addScrewStudToValve;
        private ICommand deleteScrewStudFromValve;

        public ScrewStud SelectedScrewStud
        {
            get => selectedScrewStud;
            set
            {
                selectedScrewStud = value;
                RaisePropertyChanged();
            }
        }
        public BaseValveWithScrewStud SelectedScrewStudFromList
        {
            get => selectedScrewStudFromList;
            set
            {
                selectedScrewStudFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddScrewStudToValve
        {
            get
            {
                return addScrewStudToValve ?? (
                           addScrewStudToValve = new DelegateCommand(() =>
                           {
                               if (SelectedScrewStud != null)
                               {
                                   bool success = Int32.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введите количество шпилек:"), out int tempAmount);
                                   if (success && tempAmount > 0)
                                   {
                                       if (tempAmount <= SelectedScrewStud.AmountRemaining)
                                       {
                                           SelectedScrewStud.AmountRemaining -= tempAmount;
                                           db.ScrewStuds.Update(SelectedScrewStud);
                                           db.SaveChanges();
                                           var item = new BaseValveWithScrewStud()
                                           {
                                               BaseValveId = SelectedItem.Id,
                                               ScrewStudId = SelectedScrewStud.Id,
                                               ScrewStudAmount = tempAmount
                                           };
                                           db.BaseValveWithScrewStuds.Add(item);
                                           db.SaveChanges();
                                           ScrewStuds = db.ScrewStuds.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
                                       }
                                       else MessageBox.Show($"Остаток шпилек составляет {SelectedScrewStud.AmountRemaining}", "Ошибка");
                                   }
                                   else MessageBox.Show("Введено некорректное знаение", "Ошибка");
                               }
                               else MessageBox.Show("Объект не выбран!", "Ошибка");
                           }));
            }
        }
        public ICommand EditScrewStud
        {
            get
            {
                return editScrewStud ?? (
                           editScrewStud = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedScrewStudFromList != null)
                               {
                                   var wn = new ScrewStudEditView();
                                   var vm = new ScrewStudEditVM(SelectedScrewStudFromList.ScrewStudId, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteScrewStudFromValve
        {
            get
            {
                return deleteScrewStudFromValve ?? (
                           deleteScrewStudFromValve = new DelegateCommand(() =>
                           {
                               if (SelectedScrewStudFromList != null)
                               {
                                   var item = SelectedScrewStudFromList;
                                   var stud = db.ScrewStuds.Find(item.ScrewStudId);
                                   stud.AmountRemaining += item.ScrewStudAmount;
                                   db.BaseValveWithScrewStuds.Remove(item);
                                   db.ScrewStuds.Update(stud);
                                   db.SaveChanges();
                                   ScrewStuds = db.ScrewStuds.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public IEnumerable<ScrewStud> ScrewStuds
        {
            get => screwStuds;
            set
            {
                screwStuds = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ScrewNut
        private IEnumerable<ScrewNut> screwNuts;
        private ScrewNut selectedScrewNut;
        private BaseValveWithScrewNut selectedScrewNutFromList;
        private ICommand editScrewNut;
        private ICommand addScrewNutToValve;
        private ICommand deleteScrewNutFromValve;

        public ScrewNut SelectedScrewNut
        {
            get => selectedScrewNut;
            set
            {
                selectedScrewNut = value;
                RaisePropertyChanged();
            }
        }
        public BaseValveWithScrewNut SelectedScrewNutFromList
        {
            get => selectedScrewNutFromList;
            set
            {
                selectedScrewNutFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddScrewNutToValve
        {
            get
            {
                return addScrewNutToValve ?? (
                           addScrewNutToValve = new DelegateCommand(() =>
                           {
                               if (SelectedScrewNut != null)
                               {
                                   bool success = Int32.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введите количество гаек:"), out int tempAmount);
                                   if (success && tempAmount > 0)
                                   {
                                       if (tempAmount <= SelectedScrewNut.AmountRemaining)
                                       {
                                           SelectedScrewNut.AmountRemaining -= tempAmount;
                                           db.ScrewNuts.Update(SelectedScrewNut);
                                           db.SaveChanges();
                                           var item = new BaseValveWithScrewNut()
                                           {
                                               BaseValveId = SelectedItem.Id,
                                               ScrewNutId = SelectedScrewNut.Id,
                                               ScrewNutAmount = tempAmount
                                           };
                                           db.BaseValveWithScrewNuts.Add(item);
                                           db.SaveChanges();
                                           ScrewNuts = db.ScrewNuts.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
                                       }
                                       else MessageBox.Show($"Остаток гаек составляет {SelectedScrewNut.AmountRemaining}", "Ошибка");
                                   }
                                   else MessageBox.Show("Введено некорректное знаение", "Ошибка");
                               }
                               else MessageBox.Show("Объект не выбран!", "Ошибка");
                           }));
            }
        }
        public ICommand EditScrewNut
        {
            get
            {
                return editScrewNut ?? (
                           editScrewNut = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedScrewNutFromList != null)
                               {
                                   var wn = new ScrewNutEditView();
                                   var vm = new ScrewNutEditVM(SelectedScrewNutFromList.ScrewNutId, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteScrewNutFromValve
        {
            get
            {
                return deleteScrewNutFromValve ?? (
                           deleteScrewNutFromValve = new DelegateCommand(() =>
                           {
                               if (SelectedScrewNutFromList != null)
                               {
                                   var item = SelectedScrewNutFromList;
                                   var stud = db.ScrewNuts.Find(item.ScrewNutId);
                                   stud.AmountRemaining += item.ScrewNutAmount;
                                   db.BaseValveWithScrewNuts.Remove(item);
                                   db.ScrewNuts.Update(stud);
                                   db.SaveChanges();
                                   ScrewNuts = db.ScrewNuts.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public IEnumerable<ScrewNut> ScrewNuts
        {
            get => screwNuts;
            set
            {
                screwNuts = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Seal
        private IEnumerable<AssemblyUnitSealing> seals;
        private AssemblyUnitSealing selectedSeal;
        private BaseValveWithSealing selectedSealFromList;
        private ICommand editSeal;
        private ICommand addSealToValve;
        private ICommand deleteSealFromValve;

        public AssemblyUnitSealing SelectedSeal
        {
            get => selectedSeal;
            set
            {
                selectedSeal = value;
                RaisePropertyChanged();
            }
        }
        public BaseValveWithSealing SelectedSealFromList
        {
            get => selectedSealFromList;
            set
            {
                selectedSealFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddSealToValve
        {
            get
            {
                return addSealToValve ?? (
                           addSealToValve = new DelegateCommand(() =>
                           {
                               if (SelectedSeal != null)
                               {
                                   if (SelectedSeal.AmountRemaining > 0)
                                   {
                                       SelectedSeal.AmountRemaining -= 1;
                                       db.AssemblyUnitSeals.Update(SelectedSeal);
                                       var item = new BaseValveWithSealing()
                                       {
                                           BaseValveId = SelectedItem.Id,
                                           AssemblyUnitSealingId = SelectedSeal.Id,
                                       };
                                       db.BaseValveWithSeals.Add(item);
                                       db.SaveChanges();
                                       Seals = db.AssemblyUnitSeals.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
                                   }
                                   else MessageBox.Show($"Остаток уплотнений составляет {SelectedSeal.AmountRemaining}", "Ошибка");
                               }
                               else MessageBox.Show("Объект не выбран!", "Ошибка");
                           }));
            }
        }
        public ICommand EditSeal
        {
            get
            {
                return editSeal ?? (
                           editSeal = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedSealFromList != null)
                               {
                                   var wn = new AssemblyUnitSealingEditView();
                                   var vm = new AssemblyUnitSealingEditVM(SelectedSealFromList.AssemblyUnitSealingId, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteSealFromValve
        {
            get
            {
                return deleteSealFromValve ?? (
                           deleteSealFromValve = new DelegateCommand(() =>
                           {
                               if (SelectedSealFromList != null)
                               {
                                   var item = SelectedSealFromList;
                                   var stud = db.AssemblyUnitSeals.Find(item.AssemblyUnitSealingId);
                                   stud.AmountRemaining += 1;
                                   db.BaseValveWithSeals.Remove(item);
                                   db.AssemblyUnitSeals.Update(stud);
                                   db.SaveChanges();
                                   Seals = db.AssemblyUnitSeals.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public IEnumerable<AssemblyUnitSealing> Seals
        {
            get => seals;
            set
            {
                seals = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region BallValve
        private IEnumerable<BallValve> ballValves;
        private BallValve selectedBallValve;
        private BallValve selectedBallValveFromList;
        private ICommand addBallValveToValve;
        private ICommand deleteBallValveFromValve;
        private ICommand editBallValve;

        public BallValve SelectedBallValve
        {
            get => selectedBallValve;
            set
            {
                selectedBallValve = value;
                RaisePropertyChanged();
            }
        }
        public BallValve SelectedBallValveFromList
        {
            get => selectedBallValveFromList;
            set
            {
                selectedBallValveFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddBallValveToValve
        {
            get
            {
                return addBallValveToValve ?? (
                           addBallValveToValve = new DelegateCommand(() =>
                           {
                               if (SelectedItem.BallValves.Count() < 6)
                               {
                                   if (SelectedBallValve != null)
                                   {
                                       var item = SelectedBallValve;
                                       item.BaseValveId = SelectedItem.Id;
                                       db.BallValves.Update(item);
                                       db.SaveChanges();
                                       BallValves = null;
                                       BallValves = db.BallValves.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("", "Ошибка");
                           }));
            }
        }
        public ICommand EditBallValve
        {
            get
            {
                return editBallValve ?? (
                           editBallValve = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedBallValveFromList != null)
                               {
                                   var wn = new BallValveEditView();
                                   var vm = new BallValveEditVM(SelectedBallValveFromList.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteBallValveFromValve
        {
            get
            {
                return deleteBallValveFromValve ?? (
                           deleteBallValveFromValve = new DelegateCommand(() =>
                           {
                               if (SelectedBallValveFromList != null)
                               {
                                   var item = SelectedBallValveFromList;
                                   item.BaseValveId = null;
                                   db.BallValves.Update(item);
                                   db.SaveChanges();
                                   BallValves = null;
                                   BallValves = db.BallValves.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public IEnumerable<BallValve> BallValves
        {
            get => ballValves;
            set
            {
                ballValves = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region TCP
        private IEnumerable<CompactGateValveTCP> points;
        private CompactGateValveTCP selectedTCPPoint;
        private CoatingTCP selectedCoatingTCPPoint;
        private IEnumerable<CoatingTCP> coatingPoints;
        private ICommand addCoatingOperation;
        private ICommand addOperation;

        public IEnumerable<CompactGateValveTCP> Points
        {
            get => points;
            set
            {
                points = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<CoatingTCP> CoatingPoints
        {
            get => coatingPoints;
            set
            {
                coatingPoints = value;
                RaisePropertyChanged();
            }
        }
        public CompactGateValveTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }
        public CoatingTCP SelectedCoatingTCPPoint
        {
            get => selectedCoatingTCPPoint;
            set
            {
                selectedCoatingTCPPoint = value;
                RaisePropertyChanged();
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
                                   var item = new CompactGateValveJournal()
                                   {
                                       DetailDrawing = SelectedItem.Drawing,
                                       DetailNumber = SelectedItem.Number,
                                       DetailName = SelectedItem.Name,
                                       DetailId = SelectedItem.Id,
                                       Point = SelectedTCPPoint.Point,
                                       Description = SelectedTCPPoint.Description,
                                       PointId = SelectedTCPPoint.Id,
                                   };
                                   db.Set<CompactGateValveJournal>().Add(item);
                                   db.SaveChanges();
                                   SelectedTCPPoint = null;
                                   AssemblyPreparationJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Подготовка к сборке").OrderBy(x => x.PointId).ToList();
                                   AssemblyJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
                                   TestJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
                                   AfterTestJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId).ToList();
                                   DocumentationJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
                                   ShippingJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
                               }
                           }));
            }
        }
        public ICommand AddCoatingOperation
        {
            get
            {
                return addCoatingOperation ?? (
                           addCoatingOperation = new DelegateCommand(() =>
                           {
                               if (SelectedCoatingTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
                               else
                               {
                                   var item = new CoatingJournal()
                                   {
                                       DetailDrawing = SelectedItem.Drawing,
                                       DetailNumber = SelectedItem.Number,
                                       DetailName = SelectedItem.Name,
                                       DetailId = SelectedItem.Id,
                                       Point = SelectedCoatingTCPPoint.Point,
                                       Description = SelectedCoatingTCPPoint.Description,
                                       PointId = SelectedCoatingTCPPoint.Id,
                                   };
                                   db.Set<CoatingJournal>().Add(item);
                                   db.SaveChanges();
                                   SelectedCoatingTCPPoint = null;
                                   CoatingJournal = db.Set<CoatingJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                               }
                           }));
            }
        }
        #endregion

        #region CoatingMaterial
        private IEnumerable<BaseAnticorrosiveCoating> anticorrosiveMaterials;
        private BaseAnticorrosiveCoating selectedMaterial;
        private BaseValveWithCoating selectedMaterialFromList;
        private ICommand addMaterialToValve;
        private ICommand editMaterial;
        private ICommand deleteMaterialFromValve;

        public IEnumerable<BaseAnticorrosiveCoating> AnticorrosiveMaterials
        {
            get => anticorrosiveMaterials;
            set
            {
                anticorrosiveMaterials = value;
                RaisePropertyChanged();
            }
        }
        public BaseAnticorrosiveCoating SelectedMaterial
        {
            get => selectedMaterial;
            set
            {
                selectedMaterial = value;
                RaisePropertyChanged();
            }
        }
        public BaseValveWithCoating SelectedMaterialFromList
        {
            get => selectedMaterialFromList;
            set
            {
                selectedMaterialFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddMaterialToValve
        {
            get
            {
                return addMaterialToValve ?? (
                           addMaterialToValve = new DelegateCommand(() =>
                           {
                               if (SelectedMaterial != null)
                               {
                                   var item = new BaseValveWithCoating()
                                   {
                                       BaseValveId = SelectedItem.Id,
                                       BaseAnticorrosiveCoatingId = SelectedMaterial.Id
                                   };
                                   db.BaseValveWithCoatings.Add(item);
                                   db.SaveChanges();
                               }
                               else MessageBox.Show("Объект не выбран!", "Ошибка");
                           }));
            }
        }
        public ICommand EditMaterial
        {
            get
            {
                return editMaterial ?? (
                           editMaterial = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedMaterialFromList != null)
                               {
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is Undercoat)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<Undercoat, AnticorrosiveCoatingTCP, UndercoatJournal>(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbovegroundCoating)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<AbovegroundCoating, AnticorrosiveCoatingTCP, AbovegroundCoatingJournal>(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is UndergroundCoating)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<UndergroundCoating, AnticorrosiveCoatingTCP, UndergroundCoatingJournal>(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbrasiveMaterial)
                                   {
                                       var wn = new BaseAnticorrosiveCoatingEditView();
                                       var vm = new BaseAnticorrosiveCoatingEditVM<AbrasiveMaterial, AnticorrosiveCoatingTCP, AbrasiveMaterialJournal>(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        public ICommand DeleteMaterialFromValve
        {
            get
            {
                return deleteMaterialFromValve ?? (
                           deleteMaterialFromValve = new DelegateCommand(() =>
                           {
                               if (SelectedMaterialFromList != null)
                               {
                                   db.BaseValveWithCoatings.Remove(SelectedMaterialFromList);
                                   db.SaveChanges();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }
        #endregion

        #region PID
        private ICommand editPID;
        private IEnumerable<PID> pIDs;

        public ICommand EditPID
        {
            get
            {
                return editPID ?? (
                           editPID = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.PIDId != null)
                               {
                                   var wn = new PIDEditView();
                                   var vm = new PIDEditVM(SelectedItem.PID.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        public IEnumerable<PID> PIDs
        {
            get => pIDs;
            set
            {
                pIDs = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Spindle
        private ICommand editSpindle;
        public ICommand EditSpindle
        {
            get
            {
                return editSpindle ?? (
                           editSpindle = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedItem.WeldGateValveCover.Spindle != null)
                               {
                                   var wn = new SpindleEditView();
                                   var vm = new SpindleEditVM(SelectedItem.WeldGateValveCover.Spindle.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Для просмотра привяжите деталь", "Ошибка");
                           }));
            }
        }
        #endregion

        public CompactGateValveEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<CompactGateValve>().SingleOrDefault(i => i.Id == id);
            PIDs = db.PIDs.Include(i => i.Specification).ToList();
            AssemblyPreparationJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Подготовка к сборке").OrderBy(x => x.PointId).ToList();
            AssemblyJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId).ToList();
            TestJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId).ToList();
            AfterTestJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId).ToList();
            CoatingJournal = db.Set<CoatingJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            DocumentationJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId).ToList();
            ShippingJournal = db.Set<CompactGateValveJournal>().Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Set<CompactGateValve>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            db.Saddles.Load();
            SelectedItem.Saddles = db.Saddles.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.ShearPins.Load();
            SelectedItem.ShearPins = db.ShearPins.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.BallValves.Load();
            SelectedItem.BallValves = db.BallValves.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.BaseValveWithCoatings.Load();
            SelectedItem.BaseValveWithCoatings = db.BaseValveWithCoatings.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.BaseValveWithScrewStuds.Load();
            SelectedItem.BaseValveWithScrewStuds = db.BaseValveWithScrewStuds.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.BaseValveWithScrewNuts.Load();
            SelectedItem.BaseValveWithScrewNuts = db.BaseValveWithScrewNuts.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.BaseValveWithSeals.Load();
            SelectedItem.BaseValveWithSeals = db.BaseValveWithSeals.Local.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            db.CounterFlanges.Load();
            CounterFlanges = db.CounterFlanges.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
            SelectedItem.CounterFlanges = db.CounterFlanges.Where(i => i.BaseValveId == SelectedItem.Id).ToObservableCollection();
            Cases = db.CompactGateValveCases.ToList();
            Covers = db.CompactGateValveCovers.Include(i => i.Spindle).ToList();
            Shutters = db.Shutters.ToList();
            Saddles = db.Saddles.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
            ShearPins = db.ShearPins.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
            BallValves = db.BallValves.Local.Where(i => i.BaseValveId == null).ToObservableCollection();
            db.ScrewNuts.Load();
            ScrewNuts = db.ScrewNuts.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
            db.ScrewStuds.Load();
            ScrewStuds = db.ScrewStuds.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
            db.AssemblyUnitSeals.Load();
            Seals = db.AssemblyUnitSeals.Local.Where(i => i.AmountRemaining > 0).ToObservableCollection();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<CompactGateValveTCP>().ToList();
            CoatingPoints = db.CoatingTCPs.ToList();
            AnticorrosiveMaterials = db.BaseAnticorrosiveCoatings.ToList();
        }
    }
}
