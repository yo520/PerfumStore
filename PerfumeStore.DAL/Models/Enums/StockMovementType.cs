using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeStore.DAL.Models.Enums
{
    public enum StockMovementType
    {
        Sale = 1,
        Purchase = 2,
        Transfer = 3,
        Adjustment = 4,
        Return = 5
    }
}
