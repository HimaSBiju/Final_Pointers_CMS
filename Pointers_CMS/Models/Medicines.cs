using System;
using System.Collections.Generic;

namespace Pointers_CMS.Models
{
    public partial class Medicines
    {
        public Medicines()
        {
            MedicinePrescriptions = new HashSet<MedicinePrescriptions>();
        }

        public long MedicineId { get; set; }
        public string MedicineCode { get; set; }
        public string MedicineName { get; set; }
        public string GenericName { get; set; }
        public string CompanyName { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ICollection<MedicinePrescriptions> MedicinePrescriptions { get; set; }
    }
}
