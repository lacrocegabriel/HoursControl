using HoursControl.Application.Interfaces.Repository;
using HoursControl.Application.Model;
using Microsoft.EntityFrameworkCore;

namespace HoursControl.Application.Repository
{
    public class RecordRepository : IRecordRepository
    {
        
        public Record SerchRegister(Guid id)
        {
            using var db = new ApplicationContext();
            var record = db.Records.FirstOrDefault(r => r.Id == id);
            return record;
        }

        public void AddRegister(Record record)
        {
            using var context = new ApplicationContext();
            context.Records.Add(record);
            context.SaveChanges();
        }

        public void RemoveRegister(Guid id)
        {
            using var db = new ApplicationContext();
            var record = db.Records.FirstOrDefault(r => r.Id == id);
            db.Records.Remove(record);
            db.SaveChanges();
        }

       public void UpdateRegister(Record record)
        {
            using var context = new ApplicationContext();
            context.Records.Update(record);
            context.SaveChanges();
        }

    }
}
