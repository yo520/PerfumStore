using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.ServerSentEvents;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SaleNumber { get; set; }

        public int BranchId { get; set; }

        public string EmployeeId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal DiscountAmount { get; set; } = 0;

        public decimal NetAmount { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsVoided { get; set; } = false;

        [MaxLength(200)]
        public string? Notes { get; set; }

        // Navigation Properties
        public virtual Branch Branch { get; set; }
        public virtual ApplicationUser Employee { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }
    }
}
