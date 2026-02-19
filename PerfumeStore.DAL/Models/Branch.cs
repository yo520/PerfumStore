using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class Branch
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<ApplicationUser> Employees { get; set; }  // ADD THIS
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }
    }
}
