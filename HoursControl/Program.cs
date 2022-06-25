using HoursControl.Application;
using HoursControl.Application.Interfaces;
using HoursControl.Application.Repository;
using HoursControl.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HoursControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var recordService = serviceProvider.GetService<IRecordService>();

            //Console.Write("Enter the date and time of registration: ");
            //DateTime record = DateTime.Parse(Console.ReadLine());
            //Console.Write("Enter the task to be performed: ");
            //var task = Console.ReadLine();

            //Record record1 = new Record(Guid.NewGuid(), record, task);

            Guid guid = Guid.Parse("12933A55-B335-451A-9B3B-AEF1103F6A86");

            recordService.SerchRegister(guid);

        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRecordRepository, RecordRepository>()
                .AddScoped<IRecordService, RecordService>();
        }

    }
}