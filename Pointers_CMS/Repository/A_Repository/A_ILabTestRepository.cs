using Pointers_CMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.A_Repository
{
    public interface A_ILabTestRepository
    {
        Task<List<LabTests>> GetAllTblLabTests();

        Task<int> AddLabtest(LabTests lab);

        Task UpdateLabTest(LabTests lab);

        Task<LabTests> GetLabById(int? id);


    }
}
