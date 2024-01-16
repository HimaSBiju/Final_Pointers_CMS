using Pointers_CMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.A_Repository
{
    public interface A_IMedicineRepository
    {
        Task<List<Medicines>> GetAllTblMedicines();
        Task<int> AddMedicine(Medicines medicine);
        Task UpdateMedicine(Medicines medicine);
        Task<Medicines> GetMedicineById(long? id);

    }
}
