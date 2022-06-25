namespace HoursControl.Application.Model
{
    public class Record
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public string Task { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
