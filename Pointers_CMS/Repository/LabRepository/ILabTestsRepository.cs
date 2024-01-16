using Microsoft.AspNetCore.Mvc;
using Pointers_CMS.ViewModel.LabTechniciamVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.LabRepository
{


    public interface ILabTestsRepository
 


    {
        Task<List<LabTestsVM>> GetLabTestPrescriptions();
    }
}
