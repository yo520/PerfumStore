using PerfumeStore.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class StockMovement
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public StockMovementType MovementType { get; set; }

        public decimal QuantityChanged { get; set; }

        public decimal QuantityBefore { get; set; }

        public decimal QuantityAfter { get; set; }

        [MaxLength(50)]
        public string ReferenceType { get; set; }

        public int? ReferenceId { get; set; }

        public string EmployeeId { get; set; }

        [MaxLength(500)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual Branch Branch { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser Employee { get; set; }
    }
}
