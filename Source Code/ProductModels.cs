using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetsmartzOnlineStore.Models
{
    public class ProductModels
    {
        public int ProductID_PK { get; set; }
        public int CategoryID_FK { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<DateTime> ExpiryDate{ get; set; }

        public class ProductModelsDisplay
        {
            public int ProductID_PK { get; set; }
            public int CategoryID_FK { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public Nullable<int> ProductQuantity { get; set; }
            public Nullable<double> ProductPrice { get; set; }
            public Nullable<int> Discount { get; set; }
            public Nullable<DateTime> ExpiryDate { get; set; }
        }
    }
}