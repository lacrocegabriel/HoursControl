using HoursControl.Application.Interfaces;
using HoursControl.Application.Model;
using Microsoft.EntityFrameworkCore;

namespace HoursControl.Application.Repository
{
    public class RecordRepository : IRecordRepository
    {
        ApplicationContext context = new ApplicationContext();

        public async void SerchRegister(Guid id)
        {
            //context.Record.AsNoTracking()
            //.FirstOrDefaultAsync(f => f.Id == id);

        }

        public void AddRegister(Record record)
        {
            context.Add(record);
            context.SaveChanges();
        }

        public void RemoveRegister(Record record)
        {
            context.Remove(record);
            context.SaveChanges();
        }

       public void UpdateRegister(Record record)
        {
            context.Update(record);
            context.SaveChanges();
        }

    }
}
