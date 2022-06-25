using HoursControl.Application.Model;

namespace HoursControl.Application.Interfaces.Repository
{
    public interface IRecordRepository
    {
        Record SerchRegister(Guid id);
        void AddRegister(Record record);
        void UpdateRegister(Record record);
        void RemoveRegister(Guid id);

    }
}
