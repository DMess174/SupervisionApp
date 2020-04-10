using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Materials
{
    public class WeldingMaterial : BaseTable
    {
        public WeldingMaterial()
        {
        }

        public WeldingMaterial(WeldingMaterial material)
        {
            Name = material.Name;
            Certificate = material.Certificate;
            Batch = material.Batch;
            Status = material.Status;
            Comment = material.Comment;
        }

        public string Name { get; set; }
        public string Certificate { get; set; }
        public string Batch { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

        [NotMapped] 
        public string FullName => string.Format($"{Batch}/{Name}");

        public ObservableCollection<WeldingMaterialJournal> WeldingMaterialJournals { get; set; }
    }
}
