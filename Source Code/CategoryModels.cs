using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NetsmartzOnlineStore.Models
{
    public class CategoryModels
    {
        public int CategoryID_PK { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Nullable<int> MinPriceRange { get; set; }
        public Nullable<int> MaxPriceRange { get; set; }
        public Nullable<int> DisplayOrder { get; set; }

        public class CategoryDisplayModel
        {
            public int CategoryID_PK { get; set; }
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }
            public Nullable<int> MinPriceRange { get; set; }
            public Nullable<int> MaxPriceRange { get; set; }
            public Nullable<int> DisplayOrder { get; set; }
            public int ProductCount { get; set; }
        }
    }
}