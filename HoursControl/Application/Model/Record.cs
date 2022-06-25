namespace HoursControl.Application.Model
{
    public class Record
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public string Task { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
