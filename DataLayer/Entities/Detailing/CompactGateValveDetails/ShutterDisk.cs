using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class ShutterDisk : BaseEntity
    {
        public ShutterDisk()
        {
            Name = "Диск затвора";
        }
        public ShutterDisk(ShutterDisk disk) : base(disk)
        {
            MetalMaterialId = disk.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? ShutterId { get; set; }
        public Shutter Shutter{ get; set; }

        public ObservableCollection<ShutterDiskJournal> ShutterDiskJournals{ get; set; }
    }
}
