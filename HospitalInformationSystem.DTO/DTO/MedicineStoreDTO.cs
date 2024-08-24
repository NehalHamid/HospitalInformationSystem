using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.DTO.DTO
{
    public class MedicineStoreDTO
    {
        public DateOnly ProductionDate { get; set; }

        public DateOnly ExpiringDate { get; set; }

        public DateOnly Expiry { get; set; }

        public DateOnly DateOfReceipt { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
