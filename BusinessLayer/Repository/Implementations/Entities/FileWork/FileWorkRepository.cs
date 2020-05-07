using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
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
            if (entity is Specification)
            {
                db.SpecificationWithFiles.Add(new SpecificationWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is BaseAssemblyUnit)
            {
                db.BaseAssemblyUnitWithFiles.Add(new BaseAssemblyUnitWithFile(entity.Id, file));
                SaveChanges();
            }
            if (entity is AssemblyUnitSealing)
            {
                db.AssemblyUnitSealsWithFiles.Add(new AssemblyUnitSealsWithFile(entity.Id, file));
                SaveChanges();
            }
            //TODO: Закончить метод
        }
    }
}
