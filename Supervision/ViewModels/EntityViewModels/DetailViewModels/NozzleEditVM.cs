using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using DevExpress.Mvvm;
using Supervision.Views.EntityViews.DetailViews;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities.Materials;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public class NozzleEditVM : BasePropertyChanged
    {
        private readonly DataContext db;
        private IEnumerable<string> journalNumbers;
        //private IEnumerable<string> materials;
        private IEnumerable<string> drawings;
        private IEnumerable<string> thickness;
        private IEnumerable<string> thicknessJoin;
        private IEnumerable<string> diameter;
        private IEnumerable<NozzleTCP> points;
        private IEnumerable<Inspector> inspectors;
        private IEnumerable<NozzleJournal> journal;
        private readonly BaseTable parentEntity;
        private NozzleTCP selectedTCPPoint;
        private IEnumerable<MetalMaterial> materials;

        private Nozzle selectedItem;
        private ICommand saveItem;
        private ICommand closeWindow;
        private ICommand addOperation;

        public Nozzle SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }
        public IEnumerable<MetalMaterial> Materials
        {
            get => materials;
            set
            {
                materials = value;
                RaisePropertyChanged("Material");
            }
        }

        public IEnumerable<NozzleJournal> Journal
        {
            get => journal;
            set
            {
                journal = value;
                RaisePropertyChanged("Journal");
            }
        }
        public IEnumerable<NozzleTCP> Points
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
                            db.Nozzles.Update(SelectedItem);
                            db.SaveChanges();
                            if (Journal != null)
                            {
                                foreach (var i in Journal)
                                {
                                    i.DetailNumber = SelectedItem.Number;
                                    i.DetailDrawing = SelectedItem.Drawing;
                                }

                                db.NozzleJournals.UpdateRange(Journal);
                            }
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
                        if (parentEntity is Nozzle)
                        {
                            var wn = new NozzleView();
                            var vm = new NozzleVM();
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
                            var item = new NozzleJournal()
                            {
                                DetailDrawing = SelectedItem.Drawing,
                                DetailNumber = SelectedItem.Number,
                                DetailName = SelectedItem.Name,
                                DetailId = SelectedItem.Id,
                                Point = SelectedTCPPoint.Point,
                                Description = SelectedTCPPoint.Description,
                                PointId = SelectedTCPPoint.Id,
                            };
                            db.NozzleJournals.Add(item);
                            db.SaveChanges();
                            Journal = db.NozzleJournals.Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
                        }
                    }));
            }
        }

        //public IEnumerable<string> Materials
        //{
        //    get => materials;
        //    set
        //    {
        //        materials = value;
        //        RaisePropertyChanged("Materials");
        //    }
        //}
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

        public IEnumerable<string> Thickness
        {
            get => thickness;
            set
            {
                thickness = value;
                RaisePropertyChanged("Thickness");
            }
        }

        public IEnumerable<string> ThicknessJoin
        {
            get => thicknessJoin;
            set
            {
                thicknessJoin = value;
                RaisePropertyChanged("ThicknessJoin");
            }
        }

        public IEnumerable<string> Diameter
        {
            get => diameter;
            set
            {
                diameter = value;
                RaisePropertyChanged("Diameter");
            }
        }

        public NozzleTCP SelectedTCPPoint
        {
            get => selectedTCPPoint;
            set
            {
                selectedTCPPoint = value;
                RaisePropertyChanged("SelectedTCPPoint");
            }
        }

        public NozzleEditVM(int id, BaseTable entity)
        {
            parentEntity = entity;
            db = new DataContext();
            SelectedItem = db.Nozzles.Include(i => i.CastingCase).Include(i => i.MetalMaterial).SingleOrDefault(i => i.Id == id);
            Journal = db.Set<NozzleJournal>().Where(i => i.DetailId == SelectedItem.Id).OrderBy(x => x.PointId).ToList();
            JournalNumbers = db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToList();
            Materials = db.MetalMaterials.ToList();
            //Materials = db.Nozzles.Select(d => d.Material).Distinct().OrderBy(x => x).ToList();
            Drawings = db.Nozzles.Select(s => s.Drawing).Distinct().OrderBy(x => x).ToList();
            Thickness = db.Nozzles.Select(t => t.Thickness).Distinct().OrderBy(x => x).ToList();
            ThicknessJoin = db.Nozzles.Select(t => t.ThicknessJoin).Distinct().OrderBy(x => x).ToList();
            Diameter = db.Nozzles.Select(d => d.Diameter).Distinct().OrderBy(x => x).ToList();
            Inspectors = db.Inspectors.OrderBy(i => i.Name).ToList();
            Points = db.NozzleTCPs.ToList();
        }
    }
}
