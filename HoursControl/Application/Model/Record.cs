namespace HoursControl.Application
{
    public class Record
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public string Task { get; set; }

        public Record(Guid id,DateTime time, string task)
        {
            Id = id;
            Time = time;
            Task = task;
        }
    }
}
