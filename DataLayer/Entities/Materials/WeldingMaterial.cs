using DataLayer.Journals.Materials;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Materials
{
    public class WeldingMaterial : BaseTable
    {
        public string Name { get; set; }
        public string Certificate { get; set; }
        public string Batch { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }

        [NotMapped] 
        public string FullName => string.Format($"{Batch}/{Name}");

        public IEnumerable<WeldingMaterialJournal> WeldingMaterialJournals { get; set; }
    }
}
