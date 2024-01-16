using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pointers_CMS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.A_Repository
{
    public class A_LabTestRepository : A_ILabTestRepository
    {
        private readonly DB_CMSContext _Context;
        public A_LabTestRepository(DB_CMSContext context)
        {
            _Context = context;
        }

        #region get all Labtests
        public async Task<List<LabTests>> GetAllTblLabTests()
        {
            if (_Context != null)
            {
                return await _Context.LabTests.ToListAsync();
            }
            return null;
        }
        #endregion


        #region Add a Labtests
        public async Task<int> AddLabtest(LabTests lab)
        {
            if (_Context != null)
            {
                await _Context.LabTests.AddAsync(lab);
                await _Context.SaveChangesAsync();  // commit the transction
                return lab.TestId;
            }
            return 0;
        }
        #endregion


        #region Update Lab
        public async Task UpdateLabTest(LabTests lab)
        {
            if (_Context != null)
            {
                _Context.Entry(lab).State = EntityState.Modified;
                _Context.LabTests.Update(lab);
                await _Context.SaveChangesAsync();
            }
        }
        #endregion


        #region GetLabById
        public async Task<LabTests> GetLabById(int? id)
        {
            if (_Context != null)
            {
                var employee = await _Context.LabTests.FindAsync(id);   //primary key
                return employee;
            }
            return null;
        }
        #endregion



    }
}
