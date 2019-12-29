using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Materials;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using Supervision.ViewModels.EntityViewModels.Materials;
using Supervision.Views.EntityViews.DetailViews.ReverseShutter;
using Supervision.Views.EntityViews.MaterialViews;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels.ReverseShutter
{
    public class ReverseShutterDetailEditVM<TEntity, TEntityTCP, TEntityJournal> : BasePropertyChanged
        where TEntity : ReverseShutterDetail, new()
        where TEntityTCP : BaseTCP
        where TEntityJournal : BaseJournal<TEntity, TEntityTCP>, new()
    {

        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        private IEnumerable<MetalMaterial> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<TEntityTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<TEntityJournal> journal;
        private readonly BaseTable parentEntity;
        private TEntity selectedItem;
        private TEntityTCP selectedTCPPoint;

        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;
        private ICommand editMaterial;

        public TEntity SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public IEnumerable<TEntityJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<TEntityTCP> Points
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
                        if (parentEntity is ReverseShutterDetail)
                        {
                            var wn = new ReverseShutterDetailView();
                            var vm = new ReverseShutterDetailVM<TEntity, TEntityTCP, TEntityJournal>();
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
                RaisePropertyChanged("Materials");
            }
        }
        public IEnumerable<string> Drawings
        {
            get => drawings;
            set
            {
                drawings = value;
                RaisePropertyChanged("Drawings");
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

        public TEntityTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged("SelectedTCPPoint");
            }
        }

        public ReverseShutterDetailEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Set<TEntity>().Include(i => i.ReverseShutter).SingleOrDefault(i => i.Id == id);
            Journal = db.Set<TEntityJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Drawings = db.Set<TEntity>().Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Materials = db.MetalMaterials.ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.Set<TEntityTCP>().ToList();
        }
    }
}
