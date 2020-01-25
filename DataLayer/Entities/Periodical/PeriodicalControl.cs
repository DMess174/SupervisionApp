﻿using DataLayer.Journals.Periodical;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Periodical
{
    public abstract class PeriodicalControl : BaseTable
    {
        public string Name { get; set; }
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
