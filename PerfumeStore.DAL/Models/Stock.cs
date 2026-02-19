using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int BranchId { get; set; }

        // For liquid products in mg, for others in units
        public decimal Quantity { get; set; }

        public decimal MinimumLevel { get; set; } = 0;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual Product Product { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
