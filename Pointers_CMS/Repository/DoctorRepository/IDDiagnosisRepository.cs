using Pointers_CMS.ViewModel.DoctorVM;
using System.Threading.Tasks;

namespace Pointers_CMS.Repository.DoctorRepository
{
    public interface IDDiagnosisRepository
    {
        Task<int?> FillDiagForm(DiagnosisVM diagnosisVM);
    }
}