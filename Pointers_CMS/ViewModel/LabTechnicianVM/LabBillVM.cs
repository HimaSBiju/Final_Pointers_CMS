using System;

namespace Pointers_CMS.ViewModel.LabTechnicianVM
{
  public class LabBillVM
  {

    public int BillId { get; set; }
    public DateTime? BillDate { get; set; }
    public decimal? TotalAmount { get; set; }
    public int? ReportId { get; set; }
    public int? AppointmentId { get; set; }
    public int? TestId { get; set; }
    public int PatientId { get; set; }
    public int Price {  get; set; }
   
    public string PatientName { get; set; }


    public string TestName { get; set; }
  }
}
