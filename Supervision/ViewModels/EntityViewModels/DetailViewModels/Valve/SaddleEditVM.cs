using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.Views.EntityViews.DetailViews.Valve;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.Valve
{
    public class SaddleEditVM: BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<SaddleTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<SaddleJournal> castJournal;
        private IEnumerable<SaddleJournal> sheetJournal;
        private IEnumerable<SaddleJournal> compactJournal;
        private IEnumerable<FrontalSaddleSealing> frontalSaddleSeals;
        private FrontalSaddleSealing selectedFrontalSaddleSealing;
        private SaddleWithSealing selectedFrontalSaddleSealingFromList;
        private ICommand editFrontalSaddleSealing;
        private ICommand addFrontalSaddleSealingToSaddle;
        private ICommand deleteFrontalSaddleSealingFromSaddle;
        private readonly BaseTable parentEntity;
        private Saddle selectedItem;
        private SaddleTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editMaterial;

        public Saddle SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<SaddleJournal> CastJournal
        {
            get => castJournal;
            set
            {
                castJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SaddleJournal> SheetJournal
        {
            get => sheetJournal;
            set
            {
                sheetJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SaddleJournal> CompactJournal
        {
            get => compactJournal;
            set
            {
                compactJournal = value;
                RaisePropertyChanged();
            }
        }
        public IEnumerable<SaddleTCP> Points
        {
            get => points;
            set
            {
                points = value;
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
        public IEnumerable<FrontalSaddleSealing> FrontalSaddleSeals
        {
            get => frontalSaddleSeals;
            set
            {
                frontalSaddleSeals = value;
                RaisePropertyChanged();
            }
        }
        public FrontalSaddleSealing SelectedFrontalSaddleSealing
        {
            get => selectedFrontalSaddleSealing;
            set
            {
                selectedFrontalSaddleSealing = value;
                RaisePropertyChanged();
            }
        }

        public SaddleWithSealing SelectedFrontalSaddleSealingFromList
        {
            get => selectedFrontalSaddleSealingFromList;
            set
            {
                selectedFrontalSaddleSealingFromList = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddFrontalSaddleSealingToSaddle
        {
            get
            {
                return addFrontalSaddleSealingToSaddle ?? (
                           addFrontalSaddleSealingToSaddle = new DelegateCommand(() =>
                           {
                               if (SelectedItem.SaddleWithSealings.Count() < 2)
                               {
                                   if (SelectedFrontalSaddleSealing != null)
                                   {
                                       var amount = db.FrontalSaddleSeals.Where(i => i.Id == SelectedFrontalSaddleSealing.Id).Count();
                                       if (amount > 0)
                                       {
                                           var item = new SaddleWithSealing()
                                           {
                                               SaddleId = SelectedItem.Id,
                                               FrontalSaddleSealingId = SelectedFrontalSaddleSealing.Id
                                           };
                                           db.SaddleWithSeals.Add(item);
                                           SelectedFrontalSaddleSealing.AmountRemaining -= 1;
                                           db.FrontalSaddleSeals.Update(SelectedFrontalSaddleSealing);
                                           db.SaveChanges();
                                           SelectedFrontalSaddleSealing = null;
                                       }
                                       else MessageBox.Show("Торцевые уплотнения данной партии закончились", "Ошибка");
                                   }
                                   else MessageBox.Show("Объект не выбран!", "Ошибка");
                               }
                               else MessageBox.Show("Невозможно привязать более 2 уплотнений!", "Ошибка");
                           }));
            }
        }
        public ICommand EditFrontalSaddleSealing
        {
            get
            {
                return editFrontalSaddleSealing ?? (
                           editFrontalSaddleSealing = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedFrontalSaddleSealingFromList != null)
                               {
                                   var wn = new FrontalSaddleSealingEditView();
                                   var vm = new FrontalSaddleSealingEditVM(SelectedFrontalSaddleSealingFromList.FrontalSaddleSealingId, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
            }
        }

        public ICommand DeleteFrontalSaddleSealingFromSaddle
        {
            get
            {
                return deleteFrontalSaddleSealingFromSaddle ?? (
                           deleteFrontalSaddleSealingFromSaddle = new DelegateCommand<Window>((w) =>
                           {
                               if (SelectedFrontalSaddleSealingFromList != null)
                               {
                                   var item = db.FrontalSaddleSeals.Find(SelectedFrontalSaddleSealingFromList.FrontalSaddleSealingId);
                                   item.AmountRemaining += 1;
                                   db.FrontalSaddleSeals.Update(item);
                                   db.SaddleWithSeals.Remove(SelectedFrontalSaddleSealingFromList);
                                   db.SaveChanges();
                               }
                               else MessageBox.Show("Объект не выбран", "Ошибка");
                           }));
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
                            db.Saddles.Update(SelectedItem);
                            db.SaveChanges();
                            foreach(var i in CastJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.SaddleJournals.UpdateRange(CastJournal);
                            db.SaveChanges();
                            foreach (var i in SheetJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.SaddleJournals.UpdateRange(SheetJournal);
                            db.SaveChanges();
                            foreach (var i in CompactJournal)
                            {
                                i.DetailNumber = SelectedItem.Number;
                                i.DetailDrawing = SelectedItem.Drawing;
                            }
                            db.SaddleJournals.UpdateRange(CompactJournal);
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
                        if (parentEntity is Saddle)
                        {
                            var wn = new SaddleView();
                            var vm = new SaddleVM();
                            wn.DataContext = vm;
                            w?.Close();
                            wn.ShowDialog();
                        }
                        else w?.Close();
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
                            var item = new SaddleJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.SaddleJournals.Add(item);
                            db.SaveChanges();
                            CastJournal = db.SaddleJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                            SheetJournal = db.SaddleJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
                            CompactJournal = db.SaddleJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId).ToList();
                        }
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
                               if (SelectedItem.MetalMaterial is PipeMaterial)
                               {
                                   var wn = new PipeMaterialEditView();
                                   var vm = new PipeMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                   wn.DataContext = vm;
                                   wn.Show();
                               }
                               else if (SelectedItem.MetalMaterial != null)
                               {
                                   if (SelectedItem.MetalMaterial is SheetMaterial)
                                   {
                                       var wn = new SheetMaterialEditView();
                                       var vm = new SheetMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   else if (SelectedItem.MetalMaterial is ForgingMaterial)
                                   {
                                       var wn = new ForgingMaterialEditView();
                                       var vm = new ForgingMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                                   else if (SelectedItem.MetalMaterial is RolledMaterial)
                                   {
                                       var wn = new RolledMaterialEditView();
                                       var vm = new RolledMaterialEditVM(SelectedItem.MetalMaterial.Id, SelectedItem);
                                       wn.DataContext = vm;
                                       wn.Show();
                                   }
                               }
                               else MessageBox.Show("Для просмотра привяжите материал", "Ошибка");
                           }));
            }
        }

        public IEnumerable<MetalMaterial> Materials
        {
            get => materials;
            set
            {
                materials = value;
                RaisePropertyChanged();
            }
        }
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

        public SaddleTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged();
            }
        }

        public SaddleEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Saddles.Include(i => i.BaseValve).SingleOrDefault(i => i.Id == id);
            CastJournal = db.SaddleJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            SheetJournal = db.SaddleJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШЛ").OrderBy(x => x.PointId).ToList(); //TODO: говнокод
            CompactJournal = db.SaddleJournals.Where(i => i.DetailId == SelectedItem.Id && i.EntityTCP.ProductType.ShortName == "ЗШК").OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Saddles.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.MetalMaterials.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<SaddleTCP>().ToList();
        }
    }
}
