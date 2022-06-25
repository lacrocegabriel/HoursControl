using HoursControl.Application.Interfaces.Repository;
using HoursControl.Application.Interfaces.Service;
using HoursControl.Application.Model;
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
            var employeeService = serviceProvider.GetService<IEmployeeService>();

            employeeService.AddRegister(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CPF = "10722258917",
                    Name = "Gabriel Palma Lacroce",
                    BithDate = DateTime.Now
                });



        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRecordRepository, RecordRepository>()
                .AddScoped<IRecordService, RecordService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>();
                
        }

    }
}