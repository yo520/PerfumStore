using PerfumeStore.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        // Nullable for custom perfumes
        public int? ProductId { get; set; }

        public SaleItemType ItemType { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        // Navigation Properties
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
        public virtual CustomPerfumeDetail? CustomPerfumeDetail { get; set; }
    }
}
