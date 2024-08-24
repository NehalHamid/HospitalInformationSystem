using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class FinanceDTO
    {
        public decimal? TotalCost { get; set; }

        public decimal? TotalRevenues { get; set; }

        public decimal? NetProfit { get; set; }

        public string? DetailedCosts { get; set; }

        public string? DetailedRevenues { get; set; }

        public DateOnly? ScheduleDate { get; set; }
    }
}
