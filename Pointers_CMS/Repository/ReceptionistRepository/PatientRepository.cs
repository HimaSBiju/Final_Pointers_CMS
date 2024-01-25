using Pointers_CMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Pointers_CMS.Repository.ReceptionistRepository

{
    public class PatientRepository : IPatientRepository
    {

        //Data fields
        private readonly DB_CMSContext _dbContext;

        public PatientRepository(DB_CMSContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region
        //Listing All Patients 


        public async Task<List<Patients>> GetAllPatient()
        {
            if (_dbContext != null)
            {
                return await _dbContext.Patients.Where(p => p.PatientStatus == "ACTIVE").ToListAsync();
            }
            return null;
        }
           
        


        #endregion


        #region Add a Patient

        public async Task<int> AddPatient(Patients pa)
        {
            if (_dbContext != null)
            {
                await _dbContext.Patients.AddAsync(pa);
                // for commiting the transaction
                await _dbContext.SaveChangesAsync();

                return pa.PatientId;
            }

            return 0;
        }

        #endregion

        #region Updating the Patient

        public async Task<Patients> UpdatePatient(Patients pa)
        {
            if (_dbContext != null)
            {
                _dbContext.Entry(pa).State = EntityState.Modified; // to modifying the values
                _dbContext.Patients.Update(pa);
                await _dbContext.SaveChangesAsync();
            }
            return null;
        }

        #endregion

        // get Patient by name and phone number



        #region Get patient by name and phone number

        public async Task<Patients> GetPatientByPhoneNumberAndName(long phoneNumber, string name)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(p =>
                  p.PhNo.ToString() == phoneNumber.ToString() && p.PatientName == name);
        }

        #endregion

        //Disable patient 

        #region Disable Patient Status
        public async Task<Patients> DisableStatus(int? paitientId)
        {
            var patient = await _dbContext.Patients.FindAsync(paitientId);
            if (patient != null)
            {
                patient.PatientStatus = "INACTIVE";
                await _dbContext.SaveChangesAsync();
            }
            return patient;
        }
        #endregion



        #region Get All Disabled Patient Records
        public async Task<List<Patients>> GetAllDisabledPatients()
        {
            if (_dbContext != null)
            {
                return await _dbContext.Patients.Where(p => p.PatientStatus == "INACTIVE").ToListAsync();
            }
            return null;
        }
        #endregion

        #region Enable Patient Status
        public async Task<Patients> EnableStatus(int? paitientId)
        {
            var patient = await _dbContext.Patients.FindAsync(paitientId);
            if (patient != null)
            {
                patient.PatientStatus = "ACTIVE";
                await _dbContext.SaveChangesAsync();
            }
            return patient;
        }
        #endregion

        #region GetPatientById
        public async Task<Patients> GetPatientById(int? id)
        {
            if (_dbContext != null)
            {
                var medicine = await _dbContext.Patients.FindAsync(id);   //primary key
                return medicine;
            }
            return null;
        }
        #endregion

    }

}


