using HoursControl.Application.Interfaces;
using HoursControl.Application.Model;

namespace HoursControl.Application.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        

        public RecordService(
                IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
           
        }

        public void SerchRegister(Guid id)
        {
            _recordRepository.SerchRegister(id);
        }

        public void AddRegister(Record record)
        {
            _recordRepository.AddRegister(record);
        }

        public void RemoveRegister(Record record)
        {
            _recordRepository.RemoveRegister(record);
        }

        public void UpdateRegister(Record record)
        {
            _recordRepository.UpdateRegister(record);
        }
    }
}
