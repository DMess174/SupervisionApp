using BusinessLayer.Repository.Implementations.Entities;
using BusinessLayer.Repository.Implementations.Entities.Detailing;
using BusinessLayer.Repository.Implementations.Entities.Material;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.DetailViewModels;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve;
using Supervision.ViewModels.EntityViewModels.DetailViewModels.WeldGateValve;
using Supervision.ViewModels.EntityViewModels.Materials.AnticorrosiveCoating;
using Supervision.Views.EntityViews;
using Supervision.Views.EntityViews.AssemblyUnit;
using Supervision.Views.EntityViews.DetailViews;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.DetailViews.WeldGateValve;
using Supervision.Views.EntityViews.MaterialViews.AnticorrosiveCoating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.AssemblyUnit
{
    public class SheetGateValveEditVM : ViewModelBase
    {
        #region Main
        private readonly BaseTable parentEntity;
        private readonly SheetGateValveRepository repo;
        private readonly InspectorRepository inspectorRepo;
        private readonly JournalNumberRepository journalRepo;
        private readonly SheetGateValveCaseRepository caseRepo;
        private readonly SheetGateValveCoverRepository coverRepo;
        private readonly GateRepository gateRepo;
        private readonly SaddleRepository saddleRepo;
        private readonly ShearPinRepository shearPinRepo;
        private readonly ScrewStudRepository screwStudRepo;
        private readonly ScrewNutRepository screwNutRepo;
        private readonly SpringRepository springRepo;
        private readonly AssemblyUnitSealingRepository sealRepo;
        private readonly BallValveRepository ballValveRepo;
        private readonly DataContext db;
        private SheetGateValve selectedItem;
        private readonly BaseAnticorrosiveCoatingRepository materialRepo;
        private readonly PIDRepository pIDRepo;
        private readonly CounterFlangeRepository flangeRepo;
        private SheetGateValveJournal operation;
        private CoatingJournal coatingOperation;
        private IEnumerable<CounterFlange> counterFlanges;
        private CounterFlange selectedCounterFlange;
        private CounterFlange selectedCounterFlangeFromList;

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

        public IEnumerable<CounterFlange> CounterFlanges
        {
            get => counterFlanges;
            set
            {
                counterFlanges = value;
                RaisePropertyChanged();
            }
        }

        public CoatingJournal CoatingOperation
        {
            get => coatingOperation;
            set
            {
                coatingOperation = value;
                RaisePropertyChanged();
            }
        }

        public SheetGateValveJournal Operation
        {
            get => operation;
            set
            {
                operation = value;
                RaisePropertyChanged();
            }
        }

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
        private IEnumerable<SheetGateValveJournal> assemblyPreparationJournal;
        private IEnumerable<SheetGateValveJournal> assemblyJournal;
        private IEnumerable<SheetGateValveJournal> testJournal;
        private IEnumerable<SheetGateValveJournal> afterTestJournal;
        private IEnumerable<SheetGateValveJournal> documentationJournal;
        private IEnumerable<SheetGateValveJournal> shippingJournal;
        private IEnumerable<CoatingJournal> coatingJournal;

        public SheetGateValve SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SheetGateValveJournal> AssemblyPreparationJournal
        {
            get => assemblyPreparationJournal;
            set
            {
                assemblyPreparationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveJournal> AssemblyJournal
        {
            get => assemblyJournal;
            set
            {
                assemblyJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveJournal> TestJournal
        {
            get => testJournal;
            set
            {
                testJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveJournal> AfterTestJournal
        {
            get => afterTestJournal;
            set
            {
                afterTestJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveJournal> DocumentationJournal
        {
            get => documentationJournal;
            set
            {
                documentationJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SheetGateValveJournal> ShippingJournal
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
        #endregion

        #region Case
        private IEnumerable<SheetGateValveCase> cases;

        public IEnumerable<SheetGateValveCase> Cases
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
        private IEnumerable<SheetGateValveCover> covers;

        public IEnumerable<SheetGateValveCover> Covers
        {
            get => covers;
            set
            {
                covers = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Gate
        private IEnumerable<Gate> gates;

        public IEnumerable<Gate> Gates
        {
            get => gates;
            set
            {
                gates = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Saddle
        private IEnumerable<Saddle> saddles;
        private Saddle selectedSaddle;
        private Saddle selectedSaddleFromList;

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

        #region ShearPin
        private IEnumerable<ShearPin> shearPins;
        private ShearPin selectedShearPin;
        private ShearPin selectedShearPinFromList;

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

        #region Spring
        private IEnumerable<Spring> springs;
        private Spring selectedSpring;
        private BaseValveWithSpring selectedSpringFromList;

        public Spring SelectedSpring
        {
            get => selectedSpring;
            set
            {
                selectedSpring = value;
                RaisePropertyChanged();
            }
        }
        public BaseValveWithSpring SelectedSpringFromList
        {
            get => selectedSpringFromList;
            set
            {
                selectedSpringFromList = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Spring> Springs
        {
            get => springs;
            set
            {
                springs = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Seal
        private IEnumerable<AssemblyUnitSealing> seals;
        private AssemblyUnitSealing selectedSeal;
        private BaseValveWithSealing selectedSealFromList;

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
        private IEnumerable<SheetGateValveTCP> points;
        private SheetGateValveTCP selectedTCPPoint;
        private CoatingTCP selectedCoatingTCPPoint;
        private IEnumerable<CoatingTCP> coatingPoints;

        public IEnumerable<SheetGateValveTCP> Points
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
        public SheetGateValveTCP SelectedTCPPoint
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
        #endregion

        #region CoatingMaterial
        private IEnumerable<BaseAnticorrosiveCoating> anticorrosiveMaterials;
        private BaseAnticorrosiveCoating selectedMaterial;
        private BaseValveWithCoating selectedMaterialFromList;

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
        #endregion

        #region PID
        private IEnumerable<PID> pIDs;
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

        protected override void CloseWindow(object obj)
        {
            if (repo.HasChanges(SelectedItem) || repo.HasChanges(SelectedItem.SheetGateValveJournals) || repo.HasChanges(SelectedItem.CoatingJournals))
            {
                MessageBoxResult result = MessageBox.Show("Закрыть без сохранения изменений?", "Выход", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    base.CloseWindow(obj);
                }
            }
            else
            {
                base.CloseWindow(obj);
            }
        }

        public static SheetGateValveEditVM LoadVM(int id, BaseTable entity, DataContext context)
        {
            SheetGateValveEditVM vm = new SheetGateValveEditVM(entity, context);
            vm.LoadItemCommand.ExecuteAsync(id);
            return vm;
        }

        private bool CanExecute()
        {
            return true;
        }

        public Supervision.Commands.IAsyncCommand AddMaterialToValveCommand { get; private set; }
        private async Task AddMaterialToValve()
        {
            try
            {
                if (SelectedMaterial != null)
                {
                    IsBusy = true;
                    SelectedItem.BaseValveWithCoatings.Add(new BaseValveWithCoating() { BaseValveId = SelectedItem.Id, BaseAnticorrosiveCoatingId = SelectedMaterial.Id });
                    materialRepo.Update(SelectedMaterial);
                    SelectedMaterial = null;
                    await SaveItemCommand.ExecuteAsync();
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteMaterialFromValveCommand { get; private set; }
        private async Task DeleteMaterialFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedMaterialFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedMaterial = SelectedMaterialFromList.BaseAnticorrosiveCoating;
                        SelectedItem.BaseValveWithCoatings.Remove(SelectedMaterialFromList);
                        materialRepo.Update(SelectedMaterial);
                        SelectedMaterial = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditMaterialCommand { get; private set; }
        private void EditMaterial()
        {
            if (SelectedMaterialFromList != null)
            {
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is Undercoat)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = UndercoatEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbovegroundCoating)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = AbovegroundCoatingEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is UndergroundCoating)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = UndergroundCoatingEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
                if (SelectedMaterialFromList.BaseAnticorrosiveCoating is AbrasiveMaterial)
                {
                    _ = new BaseAnticorrosiveCoatingEditView
                    {
                        DataContext = AbrasiveMaterialEditVM.LoadVM(SelectedMaterialFromList.BaseAnticorrosiveCoatingId, SelectedItem, db)
                    };
                }
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddCounterFlangeToValveCommand { get; private set; }
        private async Task AddCounterFlangeToValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.CounterFlanges?.Count() < 2 || SelectedItem.CounterFlanges == null)
                {
                    if (SelectedCounterFlange != null)
                    {
                        if (!await flangeRepo.IsAssembliedAsync(SelectedCounterFlange))
                        {
                            SelectedCounterFlange.BaseValveId = SelectedItem.Id;
                            flangeRepo.Update(SelectedCounterFlange);
                            SelectedCounterFlange = null;
                            CounterFlanges = flangeRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 фланцев!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteCounterFlangeFromValveCommand { get; private set; }
        private async Task DeleteCounterFlangeFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedCounterFlangeFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedCounterFlangeFromList.BaseValveId = null;
                        flangeRepo.Update(SelectedCounterFlangeFromList);
                        CounterFlanges = flangeRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditCounterFlangeCommand { get; private set; }
        private void EditCounterFlange()
        {
            if (SelectedCounterFlangeFromList != null)
            {
                _ = new CounterFlangeEditView
                {
                    DataContext = CounterFlangeEditVM.LoadVM(SelectedCounterFlangeFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddBallValveToValveCommand { get; private set; }
        private async Task AddBallValveToValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedBallValve != null)
                {
                    if (!await ballValveRepo.IsAssembliedAsync(SelectedBallValve))
                    {
                        SelectedBallValve.BaseValveId = SelectedItem.Id;
                        ballValveRepo.Update(SelectedBallValve);
                        SelectedBallValve = null;
                        BallValves = ballValveRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteBallValveFromValveCommand { get; private set; }
        private async Task DeleteBallValveFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedBallValveFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedBallValveFromList.BaseValveId = null;
                        ballValveRepo.Update(SelectedBallValveFromList);
                        BallValves = ballValveRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditBallValveCommand { get; private set; }
        private void EditBallValve()
        {
            if (SelectedBallValveFromList != null)
            {
                _ = new BallValveEditView
                {
                    DataContext = BallValveEditVM.LoadVM(SelectedBallValveFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddSealToValveCommand { get; private set; }
        private async Task AddSealToValve()
        {
            try
            {
                if (SelectedSeal != null)
                {
                    IsBusy = true;
                    if (await sealRepo.IsAmountRemaining(SelectedSeal))
                    {
                        SelectedItem.BaseValveWithSeals.Add(new BaseValveWithSealing() { BaseValveId = SelectedItem.Id, AssemblyUnitSealingId = SelectedSeal.Id });
                        SelectedSeal.AmountRemaining -= 1;
                        sealRepo.Update(SelectedSeal);
                        SelectedSeal = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteSealFromValveCommand { get; private set; }
        private async Task DeleteSealFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedSealFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedSeal = SelectedSealFromList.AssemblyUnitSealing;
                        SelectedSeal.AmountRemaining += 1;
                        SelectedItem.BaseValveWithSeals.Remove(SelectedSealFromList);
                        sealRepo.Update(SelectedSeal);
                        SelectedSeal = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSealCommand { get; private set; }
        private void EditSeal()
        {
            if (SelectedSealFromList != null)
            {
                _ = new AssemblyUnitSealingEditView
                {
                    DataContext = AssemblyUnitSealingEditVM.LoadVM(SelectedSealFromList.AssemblyUnitSealing.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddSpringToValveCommand { get; private set; }
        private async Task AddSpringToValve()
        {
            try
            {
                if (SelectedSpring != null)
                {
                    bool success = Int32.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введите количество пружин:"), out int tempAmount);
                    if (success && tempAmount > 0)
                    {
                        IsBusy = true;
                        if (await springRepo.IsAmountRemaining(SelectedSpring, tempAmount))
                        {
                            SelectedItem.BaseValveWithSprings.Add(new BaseValveWithSpring() { BaseValveId = SelectedItem.Id, SpringId = SelectedSpring.Id, SpringAmount = tempAmount });
                            SelectedSpring.AmountRemaining -= tempAmount;
                            springRepo.Update(SelectedSpring);
                            SelectedSpring = null;
                            await SaveItemCommand.ExecuteAsync();
                        }
                    }
                    else MessageBox.Show("Введено некорректное знаение", "Ошибка");
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteSpringFromValveCommand { get; private set; }
        private async Task DeleteSpringFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedSpringFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedSpring = SelectedSpringFromList.Spring;
                        SelectedSpring.AmountRemaining += SelectedSpringFromList.SpringAmount;
                        SelectedItem.BaseValveWithSprings.Remove(SelectedSpringFromList);
                        springRepo.Update(SelectedSpring);
                        SelectedSpring = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSpringCommand { get; private set; }
        private void EditSpring()
        {
            if (SelectedSpringFromList != null)
            {
                _ = new SpringEditView
                {
                    DataContext = SpringEditVM.LoadVM(SelectedSpringFromList.Spring.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddScrewNutToValveCommand { get; private set; }
        private async Task AddScrewNutToValve()
        {
            try
            {
                if (SelectedScrewNut != null)
                {
                    bool success = Int32.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введите количество гаек:"), out int tempAmount);
                    if (success && tempAmount > 0)
                    {
                        IsBusy = true;
                        if (await screwNutRepo.IsAmountRemaining(SelectedScrewNut, tempAmount))
                        {
                            SelectedItem.BaseValveWithScrewNuts.Add(new BaseValveWithScrewNut() { BaseValveId = SelectedItem.Id, ScrewNutId = SelectedScrewNut.Id, ScrewNutAmount = tempAmount });
                            SelectedScrewNut.AmountRemaining -= tempAmount;
                            screwNutRepo.Update(SelectedScrewNut);
                            SelectedScrewNut = null;
                            await SaveItemCommand.ExecuteAsync();
                        }
                    }
                    else MessageBox.Show("Введено некорректное знаение", "Ошибка");
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteScrewNutFromValveCommand { get; private set; }
        private async Task DeleteScrewNutFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedScrewNutFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedScrewNut = SelectedScrewNutFromList.ScrewNut;
                        SelectedScrewNut.AmountRemaining += SelectedScrewNutFromList.ScrewNutAmount;
                        SelectedItem.BaseValveWithScrewNuts.Remove(SelectedScrewNutFromList);
                        screwNutRepo.Update(SelectedScrewNut);
                        SelectedScrewNut = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditScrewNutCommand { get; private set; }
        private void EditScrewNut()
        {
            if (SelectedScrewNutFromList != null)
            {
                _ = new ScrewNutEditView
                {
                    DataContext = ScrewNutEditVM.LoadVM(SelectedScrewNutFromList.ScrewNut.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddScrewStudToValveCommand { get; private set; }
        private async Task AddScrewStudToValve()
        {
            try
            {
                if (SelectedScrewStud != null)
                {
                    bool success = Int32.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введите количество шпилек:"), out int tempAmount);
                    if (success && tempAmount > 0)
                    {
                        IsBusy = true;
                        if (await screwStudRepo.IsAmountRemaining(SelectedScrewStud, tempAmount))
                        {
                            SelectedItem.BaseValveWithScrewStuds.Add(new BaseValveWithScrewStud() { BaseValveId = SelectedItem.Id, ScrewStudId = SelectedScrewStud.Id, ScrewStudAmount = tempAmount });
                            SelectedScrewStud.AmountRemaining -= tempAmount;
                            screwStudRepo.Update(SelectedScrewStud);
                            SelectedScrewStud = null;
                            await SaveItemCommand.ExecuteAsync();
                        }
                    }
                    else MessageBox.Show("Введено некорректное знаение", "Ошибка");
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteScrewStudFromValveCommand { get; private set; }
        private async Task DeleteScrewStudFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedScrewStudFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedScrewStud = SelectedScrewStudFromList.ScrewStud;
                        SelectedScrewStud.AmountRemaining += SelectedScrewStudFromList.ScrewStudAmount;
                        SelectedItem.BaseValveWithScrewStuds.Remove(SelectedScrewStudFromList);
                        screwStudRepo.Update(SelectedScrewStud);
                        SelectedScrewStud = null;
                        await SaveItemCommand.ExecuteAsync();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditScrewStudCommand { get; private set; }
        private void EditScrewStud()
        {
            if (SelectedScrewStudFromList != null)
            {
                _ = new ScrewStudEditView
                {
                    DataContext = ScrewStudEditVM.LoadVM(SelectedScrewStudFromList.ScrewStud.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddShearPinToValveCommand { get; private set; }
        private async Task AddShearPinToValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.ShearPins?.Count() < 6 || SelectedItem.ShearPins == null)
                {
                    if (SelectedShearPin != null)
                    {
                        if (!await shearPinRepo.IsAssembliedAsync(SelectedShearPin))
                        {
                            SelectedShearPin.BaseValveId = SelectedItem.Id;
                            shearPinRepo.Update(SelectedShearPin);
                            SelectedShearPin = null;
                            ShearPins = shearPinRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 6 штифтов!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteShearPinFromValveCommand { get; private set; }
        private async Task DeleteShearPinFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedShearPinFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedShearPinFromList.BaseValveId = null;
                        shearPinRepo.Update(SelectedShearPinFromList);
                        ShearPins = shearPinRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditShearPinCommand { get; private set; }
        private void EditShearPin()
        {
            if (SelectedShearPinFromList != null)
            {
                _ = new ShearPinEditView
                {
                    DataContext = ShearPinEditVM.LoadVM(SelectedShearPinFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand AddSaddleToValveCommand { get; private set; }
        private async Task AddSaddleToValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedItem.Saddles?.Count() < 2 || SelectedItem.Saddles == null)
                {
                    if (SelectedSaddle != null)
                    {
                        if (!await saddleRepo.IsAssembliedAsync(SelectedSaddle))
                        {
                            SelectedSaddle.BaseValveId = SelectedItem.Id;
                            saddleRepo.Update(SelectedSaddle);
                            SelectedSaddle = null;
                            Saddles = saddleRepo.UpdateList();
                        }
                    }
                    else MessageBox.Show("Объект не выбран!", "Ошибка");
                }
                else MessageBox.Show("Невозможно привязать более 2 седел!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand DeleteSaddleFromValveCommand { get; private set; }
        private async Task DeleteSaddleFromValve()
        {
            try
            {
                IsBusy = true;
                if (SelectedSaddleFromList != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedSaddleFromList.BaseValveId = null;
                        saddleRepo.Update(SelectedSaddleFromList);
                        Saddles = saddleRepo.UpdateList();
                    }
                }
                else MessageBox.Show("Объект не выбран!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public ICommand EditSaddleCommand { get; private set; }
        private void EditSaddle()
        {
            if (SelectedSaddleFromList != null)
            {
                _ = new SaddleEditView
                {
                    DataContext = SaddleEditVM.LoadSaddleEditVM(SelectedSaddleFromList.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Объект не выбран", "Ошибка");
        }

        public ICommand EditGateCommand { get; private set; }
        private void EditGate()
        {
            if (SelectedItem.GateId != null)
            {
                _ = new GateEditView
                {
                    DataContext = GateEditVM.LoadVM(SelectedItem.Gate.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите шибер", "Ошибка");
        }

        public ICommand EditCoverCommand { get; private set; }
        private void EditCover()
        {
            if (SelectedItem.WeldGateValveCover != null)
            {
                _ = new WeldGateValveCoverEditView
                {
                    DataContext = SheetGateValveCoverEditVM.LoadVM(SelectedItem.WeldGateValveCover.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите крышку", "Ошибка");
        }

        public ICommand EditCaseCommand { get; private set; }
        private void EditCase()
        {
            if (SelectedItem.WeldGateValveCase != null)
            {
                _ = new WeldGateValveCaseEditView
                {
                    DataContext = SheetGateValveCaseEditVM.LoadVM(SelectedItem.WeldGateValveCase.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите корпус", "Ошибка");
        }

        public ICommand EditSpindleCommand { get; private set; }
        private void EditSpindle()
        {
            if (SelectedItem.WeldGateValveCover.Spindle != null)
            {
                _ = new SpindleEditView
                {
                    DataContext = SpindleEditVM.LoadVM(SelectedItem.WeldGateValveCover.Spindle.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите шпиндель", "Ошибка");
        }

        public ICommand EditPIDCommand { get; private set; }
        private void EditPID()
        {
            if (SelectedItem.PID != null)
            {
                _ = new PIDEditView
                {
                    DataContext = PIDEditVM.LoadPIDEditVM(SelectedItem.PID.Id, SelectedItem, db)
                };
            }
            else MessageBox.Show("Для просмотра привяжите PID", "Ошибка");
        }

        public Supervision.Commands.IAsyncCommand SaveItemCommand { get; private set; }
        private async Task SaveItem()
        {
            try
            {
                IsBusy = true;
                //if (SelectedItem.PIDId != null)
                //{
                //    if (!await Task.Run(() => pIDRepo.IsAmountRemaining(SelectedItem)))
                //    {
                //        SelectedItem.PID = null;
                //    }
                //}
                if (SelectedItem.WeldGateValveCaseId != null)
                {
                    if (await Task.Run(() => caseRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.WeldGateValveCase = null;
                    }
                }
                if (SelectedItem.WeldGateValveCoverId != null)
                {
                    if (await Task.Run(() => coverRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.WeldGateValveCover = null;
                    }
                }
                if (SelectedItem.GateId != null)
                {
                    if (await Task.Run(() => gateRepo.IsAssembliedAsync(SelectedItem)))
                    {
                        SelectedItem.Gate = null;
                    }
                }
                await Task.Run(() => repo.Update(SelectedItem));
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddOperationCommand { get; private set; }
        public async Task AddOperation()
        {
            if (SelectedTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.SheetGateValveJournals.Add(new SheetGateValveJournal(SelectedItem, SelectedTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                AssemblyPreparationJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Подготовка к сборке").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                TestJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                AfterTestJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId);
                DocumentationJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                ShippingJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
                SelectedTCPPoint = null;
            }
        }

        public Commands.IAsyncCommand RemoveOperationCommand { get; private set; }
        private async Task RemoveOperation()
        {
            try
            {
                IsBusy = true;
                if (Operation != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedItem.SheetGateValveJournals.Remove(Operation);
                        await SaveItemCommand.ExecuteAsync();
                        AssemblyPreparationJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Подготовка к сборке").OrderBy(x => x.PointId);
                        AssemblyJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                        TestJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                        AfterTestJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId);
                        DocumentationJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                        ShippingJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Supervision.Commands.IAsyncCommand AddCoatingOperationCommand { get; private set; }
        public async Task AddCoatingOperation()
        {
            if (SelectedCoatingTCPPoint == null) MessageBox.Show("Выберите пункт ПТК!", "Ошибка");
            else
            {
                SelectedItem.CoatingJournals.Add(new CoatingJournal(SelectedItem, SelectedCoatingTCPPoint));
                await SaveItemCommand.ExecuteAsync();
                CoatingJournal = SelectedItem.CoatingJournals.OrderBy(x => x.PointId);
                SelectedCoatingTCPPoint = null;
            }
        }

        public Commands.IAsyncCommand RemoveCoatingOperationCommand { get; private set; }
        private async Task RemoveCoatingOperation()
        {
            try
            {
                IsBusy = true;
                if (CoatingOperation != null)
                {
                    MessageBoxResult result = MessageBox.Show("Подтвердите удаление", "Удаление", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        SelectedItem.CoatingJournals.Remove(CoatingOperation);
                        await SaveItemCommand.ExecuteAsync();
                        CoatingJournal = SelectedItem.CoatingJournals.OrderBy(x => x.PointId);
                    }
                }
                else MessageBox.Show("Выберите операцию!", "Ошибка");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Commands.IAsyncCommand<int> LoadItemCommand { get; private set; }
        public async Task Load(int id)
        {
            try
            {
                IsBusy = true;
                SelectedItem = await Task.Run(() => repo.GetByIdIncludeAsync(id));
                PIDs = await Task.Run(() => pIDRepo.GetAllAsync());
                Cases = await Task.Run(() => caseRepo.GetAllAsync());
                Covers = await Task.Run(() => coverRepo.GetAllIncludeAsync());
                Gates = await Task.Run(() => gateRepo.GetAllAsync());
                await Task.Run(() => saddleRepo.Load());
                await Task.Run(() => flangeRepo.Load());
                await Task.Run(() => shearPinRepo.Load());
                ScrewStuds = await Task.Run(() => screwStudRepo.GetAllAsync());
                ScrewNuts = await Task.Run(() => screwNutRepo.GetAllAsync());
                Springs = await Task.Run(() => springRepo.GetAllAsync());
                Seals = await Task.Run(() => sealRepo.GetAllAsync());
                await Task.Run(() => ballValveRepo.Load());
                AnticorrosiveMaterials = await Task.Run(() => materialRepo.GetAllAsync());
                Inspectors = await Task.Run(() => inspectorRepo.GetAllAsync());
                Drawings = await Task.Run(() => repo.GetPropertyValuesDistinctAsync(i => i.Drawing));
                Points = await Task.Run(() => repo.GetTCPsAsync());
                CoatingPoints = await Task.Run(() => repo.GetCoatingTCPsAsync());
                JournalNumbers = await Task.Run(() => journalRepo.GetActiveJournalNumbersAsync());
                Saddles = saddleRepo.UpdateList();
                ShearPins = shearPinRepo.UpdateList();
                Saddles = saddleRepo.UpdateList();
                BallValves = ballValveRepo.UpdateList();
                CounterFlanges = flangeRepo.UpdateList();
                AssemblyPreparationJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Подготовка к сборке").OrderBy(x => x.PointId);
                AssemblyJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Сборка").OrderBy(x => x.PointId);
                TestJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "ПСИ").OrderBy(x => x.PointId);
                AfterTestJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "ВИК после ПСИ").OrderBy(x => x.PointId);
                CoatingJournal = SelectedItem.CoatingJournals.OrderBy(x => x.PointId);
                DocumentationJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Документация").OrderBy(x => x.PointId);
                ShippingJournal = SelectedItem.SheetGateValveJournals.Where(i => i.EntityTCP.OperationType.Name == "Отгрузка").OrderBy(x => x.PointId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public SheetGateValveEditVM(BaseTable entity, DataContext context)
        {
            db = context;
            parentEntity = entity;
            repo = new SheetGateValveRepository(db);
            inspectorRepo = new InspectorRepository(db);
            journalRepo = new JournalNumberRepository(db);
            caseRepo = new SheetGateValveCaseRepository(db);
            coverRepo = new SheetGateValveCoverRepository(db);
            gateRepo = new GateRepository(db);
            saddleRepo = new SaddleRepository(db);
            shearPinRepo = new ShearPinRepository(db);
            screwStudRepo = new ScrewStudRepository(db);
            screwNutRepo = new ScrewNutRepository(db);
            springRepo = new SpringRepository(db);
            sealRepo = new AssemblyUnitSealingRepository(db);
            ballValveRepo = new BallValveRepository(db);
            materialRepo = new BaseAnticorrosiveCoatingRepository(db);
            pIDRepo = new PIDRepository(db);
            flangeRepo = new CounterFlangeRepository(db);
            LoadItemCommand = new Supervision.Commands.AsyncCommand<int>(Load);
            SaveItemCommand = new Supervision.Commands.AsyncCommand(SaveItem);
            CloseWindowCommand = new Supervision.Commands.Command(o => CloseWindow(o));
            AddOperationCommand = new Supervision.Commands.AsyncCommand(AddOperation);
            RemoveOperationCommand = new Supervision.Commands.AsyncCommand(RemoveOperation);
            AddCoatingOperationCommand = new Supervision.Commands.AsyncCommand(AddCoatingOperation);
            RemoveCoatingOperationCommand = new Supervision.Commands.AsyncCommand(RemoveCoatingOperation);
            AddBallValveToValveCommand = new Supervision.Commands.AsyncCommand(AddBallValveToValve);
            DeleteBallValveFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteBallValveFromValve);
            EditBallValveCommand = new Supervision.Commands.Command(o => EditBallValve());
            AddSaddleToValveCommand = new Supervision.Commands.AsyncCommand(AddSaddleToValve);
            DeleteSaddleFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteSaddleFromValve);
            EditSaddleCommand = new Supervision.Commands.Command(o => EditSaddle());
            AddShearPinToValveCommand = new Supervision.Commands.AsyncCommand(AddShearPinToValve);
            DeleteShearPinFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteShearPinFromValve);
            EditShearPinCommand = new Supervision.Commands.Command(o => EditShearPin());
            AddScrewStudToValveCommand = new Supervision.Commands.AsyncCommand(AddScrewStudToValve);
            DeleteScrewStudFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteScrewStudFromValve);
            EditScrewStudCommand = new Supervision.Commands.Command(o => EditScrewStud());
            AddScrewNutToValveCommand = new Supervision.Commands.AsyncCommand(AddScrewNutToValve);
            DeleteScrewNutFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteScrewNutFromValve);
            EditScrewNutCommand = new Supervision.Commands.Command(o => EditScrewNut());
            AddSpringToValveCommand = new Supervision.Commands.AsyncCommand(AddSpringToValve);
            DeleteSpringFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteSpringFromValve);
            EditSpringCommand = new Supervision.Commands.Command(o => EditSpring());
            AddSealToValveCommand = new Supervision.Commands.AsyncCommand(AddSealToValve);
            DeleteSealFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteSealFromValve);
            EditSealCommand = new Supervision.Commands.Command(o => EditSeal());
            AddMaterialToValveCommand = new Supervision.Commands.AsyncCommand(AddMaterialToValve);
            DeleteMaterialFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteMaterialFromValve);
            EditMaterialCommand = new Supervision.Commands.Command(o => EditMaterial());
            AddCounterFlangeToValveCommand = new Supervision.Commands.AsyncCommand(AddCounterFlangeToValve);
            DeleteCounterFlangeFromValveCommand = new Supervision.Commands.AsyncCommand(DeleteCounterFlangeFromValve);
            EditCounterFlangeCommand = new Supervision.Commands.Command(o => EditCounterFlange());
            EditCaseCommand = new Supervision.Commands.Command(o => EditCase());
            EditCoverCommand = new Supervision.Commands.Command(o => EditCover());
            EditGateCommand = new Supervision.Commands.Command(o => EditGate());
            EditSpindleCommand = new Supervision.Commands.Command(o => EditSpindle());
            EditPIDCommand = new Supervision.Commands.Command(o => EditPID());
        }
    }
}
