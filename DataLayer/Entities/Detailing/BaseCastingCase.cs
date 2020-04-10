﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class BaseCastingCase : BaseDetail
    {
        public ObservableCollection<Nozzle> Nozzles { get; set; }

        public BaseCastingCase() : base()
        {
        }
        public BaseCastingCase(BaseCastingCase castingCase) : base(castingCase)
        {

        }
    }
}
