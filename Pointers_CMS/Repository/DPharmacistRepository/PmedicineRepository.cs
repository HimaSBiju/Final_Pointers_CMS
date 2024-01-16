using Microsoft.EntityFrameworkCore;
using Pointers_CMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DPharmacistRepository
{
    public class PmedicineRepository: IPmedicineRepository
    {
        private readonly DB_CMSContext _Context;

        public PmedicineRepository(DB_CMSContext context)
        {
            _Context = context;
        }

        #region Get all Details
        public async Task<List<Medicines>> GetAllMedicine()
        {
            if (_Context != null)
            {
                return await _Context.Medicines.ToListAsync();
            }
            return null;
        }
        #endregion

        public async Task<Medicines> GetDetailsById(long? id)
        {
            if (_Context != null)
            {
                var med = await _Context.Medicines.FindAsync(id);   //primary key
                return med;
            }
            return null;
        }

        public Task<Medicines> GetDetailsById(int? id)
        {
            throw new System.NotImplementedException();
        }


        #region Search Medicine By Name
        public async Task<List<Medicines>> SearchMedicineByName(string name)
        {
            if (_Context != null)
            {
                return await _Context.Medicines
                    .Where(m => m.MedicineName.Contains(name))
                    .ToListAsync();
            }
            return null;
        }
        #endregion

        //Task<List<Medicines>> IPmedicineRepository.GetAllMedicine()
        //{
        //    throw new System.NotImplementedException();
        //}

        //Task<Medicines> IPmedicineRepository.GetDetailsById(int? id)
        //{
        //    throw new System.NotImplementedException();
        //}

    }
}
