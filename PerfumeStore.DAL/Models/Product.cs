using PerfumeStore.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.ServerSentEvents;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string BarcodeNumber { get; set; }

        [MaxLength(500)]
        public string BarcodeImageUrl { get; set; }

        public ProductType ProductType { get; set; }

        public decimal BasePrice { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // For liquid products - price per mg
        public decimal? PricePerMg { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }
        public virtual ICollection<CustomPerfumeDetail> LiquidUsages { get; set; }
        public virtual ICollection<CustomPerfumeDetail> BottleUsages { get; set; }
    }
}
