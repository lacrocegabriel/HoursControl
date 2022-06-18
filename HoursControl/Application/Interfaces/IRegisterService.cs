﻿using HoursControl.Application.Objects;

namespace HoursControl.Application.Interfaces
{
    public interface IRecordService
    {
        void SerchRegister(Guid id);
        void AddRegister(Record record);
        void RemoveRegister(Guid id);
        void UpdateRegister(Record record);
    }
}
