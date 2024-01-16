using Pointers_CMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DPharmacistRepository
{
    public interface IPmedicineRepository
    {
        Task<List<Medicines>> GetAllMedicine();
        Task<Medicines> GetDetailsById(long? id);

        Task<List<Medicines>> SearchMedicineByName(string name);

        //ViewModel

    }
}
