namespace Presentation.Areas.Educator.Models.ViewModels
{
    public class AbsencesViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string SchoolHourDescription { get; set; }
        public DateTime? AbsenceDate { get; set; }
        public string SubjectWhichHasAbsences { get; set; }

    }
}
