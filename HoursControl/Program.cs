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


            Console.WriteLine("Deseja visualizar: ");
            Console.WriteLine("1 - Funcionarios: ");
            Console.WriteLine("2 - Registros: ");
            var opcao = int.Parse(Console.ReadLine());
            
            if(opcao == 1)
            {
                Console.WriteLine("############ FUNCIONÁRIO ###############");
                Console.WriteLine(" ");
                Console.WriteLine("Digite a opção de que deseja realizar: ");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Editar Funcinário");
                Console.WriteLine("3 - Remover Funcionário");
                opcao = int.Parse(Console.ReadLine());

                if(opcao == 1)
                {
                    Console.WriteLine("Digite a ");
                }

            }



            Console.Write("Digite o CPF do funcionario que deseja cadastrar a tarefa: ");
            var employeeCPF = Console.ReadLine();

            var employe = employeeService.SerchForCPF(employeeCPF);

            Console.WriteLine("Informações do funcionário:");
            Console.WriteLine($"Nome: {employe.Name}");
            Console.WriteLine($"CPF: {employe.CPF}");
            Console.WriteLine($"Data de Nascimento: {employe.BithDate}");
            //Console.Write("Confirma o inicio do registro?");
            //confirma = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Digite o codigo da tarefa: ");
            var code = int.Parse(Console.ReadLine());
            Console.WriteLine("Descreva a tarefa que será realizada: ");
            var task = Console.ReadLine();
            Console.WriteLine("Digite a data do início da tarefa (dd/mm/yyyy hh:mm): ");
            var begin = DateTime.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine("Cadastrando tarefa...");
            recordService.AddRegister(new Record
            {
                Id = Guid.NewGuid(),
                Code = code,
                Task = task,
                Begin = begin,
                EmployeeId = employe.Id
            });

            //employeeService.AddRegister(
            //    new Employee
            //    {
            //        Id = Guid.NewGuid(),
            //        CPF = "10722258917",
            //        Name = "Gabriel Palma Lacroce",
            //        BithDate = DateTime.Now
        //});

            //recordService.AddRegister(
            //   new Record
            //   {
            //       Id = Guid.NewGuid(),
            //       Task = "testes realizados",
            //       Time = DateTime.Now
            //   });



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