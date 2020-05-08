using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.Files;
using System;

namespace BusinessLayer.Repository.Implementations.Entities.FileWork
{
    public class FileWorkRepository : Repository<ElectronicDocument>
    {
        public FileWorkRepository()
        {
        }

        public FileWorkRepository(DataContext context) : base(context)
        {
        }

        public ElectronicDocument Add(string number, FileType fileType, DateTime date, string filePath)
        {
            var file = new ElectronicDocument(number, fileType, date, filePath);
            table.Add(file);
            SaveChanges();
            return file;
        }

        public void AddFileToItem(BaseTable entity, ElectronicDocument file)
        {
            if (entity is BaseAssemblyUnit)
            {
                db.BaseAssemblyUnitWithFiles.Add(new BaseAssemblyUnitWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is BallValve)
            {
                db.BallValvesWithFiles.Add(new BallValvesWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is BaseAnticorrosiveCoating)
            {
                db.BaseAnticorrosiveCoatingWithFiles.Add(new BaseAnticorrosiveCoatingWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is AssemblyUnitSealing)
            {
                db.AssemblyUnitSealsWithFiles.Add(new AssemblyUnitSealsWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is BaseCastingCase)
            {
                db.BaseCastingCaseWithFiles.Add(new BaseCastingCaseWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is BaseValveCover)
            {
                db.BaseValveCoverWithFiles.Add(new BaseValveCoverWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is BronzeSleeveShutter)
            {
                db.BronzeSleeveShutterWithFiles.Add(new BronzeSleeveShutterWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CaseBottom)
            {
                db.CaseBottomWithFiles.Add(new CaseBottomWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CaseEdge)
            {
                db.CaseEdgeWithFiles.Add(new CaseEdgeWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CaseFlange)
            {
                db.CaseFlangeWithFiles.Add(new CaseFlangeWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ControlWeld)
            {
                db.ControlWeldWithFiles.Add(new ControlWeldWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CounterFlange)
            {
                db.CounterFlangeWithFiles.Add(new CounterFlangeWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CoverFlange)
            {
                db.CoverFlangeWithFiles.Add(new CoverFlangeWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CoverSealingRing)
            {
                db.CoverSealingRingWithFiles.Add(new CoverSealingRingWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is CoverSleeve)
            {
                db.CoverSleeveWithFiles.Add(new CoverSleeveWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is FrontalSaddleSealing)
            {
                db.FrontalSaddleSealingWithFiles.Add(new FrontalSaddleSealingWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is FrontWall)
            {
                db.FrontWallWithFiles.Add(new FrontWallWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Gate)
            {
                db.GateWithFiles.Add(new GateWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is MetalMaterial)
            {
                db.MetalMaterialWithFiles.Add(new MetalMaterialWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Nozzle)
            {
                db.NozzleWithFiles.Add(new NozzleWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is PID)
            {
                db.PIDWithFiles.Add(new PIDWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is RunningSleeve)
            {
                db.RunningSleeveWithFiles.Add(new RunningSleeveWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Saddle)
            {
                db.SaddleWithFiles.Add(new SaddleWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ScrewNut)
            {
                db.ScrewNutWithFiles.Add(new ScrewNutWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ScrewStud)
            {
                db.ScrewStudWithFiles.Add(new ScrewStudWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ShaftShutter)
            {
                db.ShaftShutterWithFiles.Add(new ShaftShutterWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ShearPin)
            {
                db.ShearPinWithFiles.Add(new ShearPinWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ShutterDisk)
            {
                db.ShutterDiskWithFiles.Add(new ShutterDiskWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is ShutterGuide)
            {
                db.ShutterGuideWithFiles.Add(new ShutterGuideWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Shutter)
            {
                db.ShutterWithFiles.Add(new ShutterWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is SideWall)
            {
                db.SideWallWithFiles.Add(new SideWallWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is SlamShutter)
            {
                db.SlamShutterWithFiles.Add(new SlamShutterWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Specification)
            {
                db.SpecificationWithFiles.Add(new SpecificationWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Spindle)
            {
                db.SpindleWithFiles.Add(new SpindleWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is Spring)
            {
                db.SpringWithFiles.Add(new SpringWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is SteelSleeveShutter)
            {
                db.SteelSleeveShutterWithFiles.Add(new SteelSleeveShutterWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is StubShutter)
            {
                db.StubShutterWithFiles.Add(new StubShutterWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is WeldGateValveCase)
            {
                db.WeldGateValveCaseWithFiles.Add(new WeldGateValveCaseWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is WeldingMaterial)
            {
                db.WeldingMaterialWithFiles.Add(new WeldingMaterialWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is WeldNozzle)
            {
                db.WeldNozzleWithFiles.Add(new WeldNozzleWithFile(entity.Id, file));
                SaveChanges();
            }
        }
    }
}
