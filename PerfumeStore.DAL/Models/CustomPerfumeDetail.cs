using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class CustomPerfumeDetail
    {
        public int Id { get; set; }

        public int SaleItemId { get; set; }

        public int LiquidProductId { get; set; }

        public decimal QuantityInMg { get; set; }

        public int BottleProductId { get; set; }

        public bool HasAlcohol { get; set; }

        public decimal AlcoholPrice { get; set; } = 0;

        public decimal LiquidPrice { get; set; }

        public decimal BottlePrice { get; set; }

        public decimal TotalPrice { get; set; }

        // Navigation Properties
        public virtual SaleItem SaleItem { get; set; }
        public virtual Product LiquidProduct { get; set; }
        public virtual Product BottleProduct { get; set; }
    }
}
