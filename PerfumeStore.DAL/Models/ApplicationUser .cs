using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PerfumeStore.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName {  get; set; }
        public decimal salary {  get; set; }
        public string address { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public  ICollection<Sale> Sales { get; set; }
        public  ICollection<StockMovement> StockMovements { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
