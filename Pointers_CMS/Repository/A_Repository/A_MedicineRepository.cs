using Microsoft.EntityFrameworkCore;
using Pointers_CMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.A_Repository
{
    public class A_MedicineRepository : A_IMedicineRepository
    {
        private readonly DB_CMSContext _Context;
        public A_MedicineRepository(DB_CMSContext context)
        {
            _Context = context;
        }

        //Get all employees
        #region get all Medicine
        public async Task<List<Medicines>> GetAllTblMedicines()
        {
            if (_Context != null)
            {
                return await _Context.Medicines.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add a Medicine
        public async Task<int> AddMedicine(Medicines medicine)
        {
            if (_Context != null)
            {
                await _Context.Medicines.AddAsync(medicine);
                await _Context.SaveChangesAsync();  // commit the transction
                return (int)medicine.MedicineId;
            }
            return 0;
        }
        #endregion


        #region Update Medicine
        public async Task UpdateMedicine(Medicines medicine)
        {
            if (_Context != null)
            {
                _Context.Entry(medicine).State = EntityState.Modified;
                _Context.Medicines.Update(medicine);
                await _Context.SaveChangesAsync();
            }
        }
        #endregion



        #region GetMedicineById
        public async Task<Medicines> GetMedicineById(long? id)
        {
            if (_Context != null)
            {
                var medicine = await _Context.Medicines.FindAsync(id);   //primary key
                return medicine;
            }
            return null;
        }
        #endregion

    }
}
