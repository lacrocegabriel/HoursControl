using HoursControl.Application.Interfaces.Repository;
using HoursControl.Application.Interfaces.Service;
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

        public Record SerchRegister(Guid id)
        {
            return _recordRepository.SerchRegister(id);
        }
        public Record SerchForCode(int code)
        {
            return _recordRepository.SerchForCode(code);
        }
        

        public void AddRegister(Record record)
        {
            _recordRepository.AddRegister(record);
        }

        public void RemoveRegister(Guid id)
        {
            _recordRepository.RemoveRegister(id);
        }

        public void UpdateRegister(Record record)
        {
            _recordRepository.UpdateRegister(record);
        }
    }
}
