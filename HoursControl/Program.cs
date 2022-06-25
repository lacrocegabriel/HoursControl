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

            var menu = 1;


            Console.WriteLine("Deseja visualizar: ");
            Console.WriteLine("1 - Funcionarios");
            Console.WriteLine("2 - Tarefas");
            Console.Write("Opção: ");
            var decision = int.Parse(Console.ReadLine());

            if (decision == 1)
            {
                Console.Clear();
                Console.WriteLine("############ FUNCIONÁRIO ###############");
                Console.WriteLine(" ");
                Console.WriteLine("Digite a opção de que deseja realizar: ");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Editar Funcinário");
                Console.WriteLine("3 - Remover Funcionário");
                //Console.WriteLine("4 - Retornar");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Clear();
                    Console.Write("Digite o nome do funcionário: ");
                    var name = Console.ReadLine();
                    Console.Write("Digite o CPF do funcionário: ");
                    var cpf = Console.ReadLine();
                    Console.Write("Digite a data de nascimento do funcionário: ");
                    var date = DateTime.Parse(Console.ReadLine());

                    employeeService.AddRegister(
                        new Employee
                        {
                            Id = Guid.NewGuid(),
                            Name = name,
                            CPF = cpf,
                            BithDate = date
                        });
                }
                if (option == 2)
                {
                    var end = "n";
                    Console.Clear();
                    Console.Write("Digite o CPF do funcionário que deseja editar: ");
                    var cpf = Console.ReadLine();
                    var employee = employeeService.SerchForCPF(cpf);
                    Console.WriteLine();
                    Console.WriteLine("Informações atuais do funcionário:");
                    Console.WriteLine($"Nome: {employee.Name}");
                    Console.WriteLine($"CPF: {employee.CPF}");
                    Console.WriteLine($"Data de Nascimento: {employee.BithDate}");
                    Console.WriteLine();

                    while (end != "s")
                    {
                        Console.WriteLine("Qual informação deseja alterar? ");
                        Console.WriteLine("1 - Nome");
                        Console.WriteLine("2 - CPF");
                        Console.WriteLine("3 - Data Nascimento");
                        var n = int.Parse(Console.ReadLine());

                        if (n == 1)
                        {
                            Console.Write("Digite o nome do funcionário: ");
                            var name = Console.ReadLine();
                            employee.Name = name;

                            employeeService.UpdateRegister(employee);
                        }
                        if (n == 2)
                        {
                            Console.Write("Digite o CPF do funcionário: ");
                            cpf = Console.ReadLine();
                            employee.CPF = cpf;
                            employeeService.UpdateRegister(employee);
                        }
                        if (n == 3)
                        {
                            Console.Write("Digite a data de nascimento do funcionário: ");
                            var date = DateTime.Parse(Console.ReadLine());
                            employee.BithDate = date;
                            employeeService.UpdateRegister(employee);
                        }
                        else
                        {
                            Console.WriteLine("Opção Inválida");
                            end = "n";
                        }
                        Console.Write("Deseja encerrar a edição? s/n ");
                        end = Console.ReadLine();
                    }
                }
                if (option == 3)
                {
                    Console.Clear();
                    Console.Write("Digite o CPF do funcionário que deseja remover: ");
                    var cpf = Console.ReadLine();
                    var employee = employeeService.SerchForCPF(cpf);
                    Console.WriteLine();
                    Console.WriteLine("Informações atuais do funcionário:");
                    Console.WriteLine($"Nome: {employee.Name}");
                    Console.WriteLine($"CPF: {employee.CPF}");
                    Console.WriteLine($"Data de Nascimento: {employee.BithDate}");
                    Console.WriteLine();
                    Console.Write("Confirma a remoção? s/n: ");
                    var confirm = Console.ReadLine();

                    if (confirm == "s")
                    {
                        employeeService.RemoveRegister(employee.Id);
                    }
                    else
                    {
                        Console.WriteLine("Retornando ao menu principal....");
                    }
                }
            }
            if (decision == 2)
            {
                Console.Clear();
                Console.WriteLine("############ TAREFAS ###############");
                Console.WriteLine(" ");
                Console.WriteLine("Digite a opção de que deseja realizar: ");
                Console.WriteLine("1 - Cadastrar Tarefa");
                Console.WriteLine("2 - Editar Tarefa");
                Console.WriteLine("3 - Remover Tarefa");
                Console.WriteLine("Opção: ");
                //Console.WriteLine("4 - Retornar");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.Clear();
                    Console.Write("Digite o CPF do funcinário da tarefa: ");
                    var cpf = Console.ReadLine();
                    var employee = employeeService.SerchForCPF(cpf);
                    Console.WriteLine();
                    Console.WriteLine("Informações do funcionário:");
                    Console.WriteLine($"Nome: {employee.Name}");
                    Console.WriteLine($"CPF: {employee.CPF}");
                    Console.WriteLine($"Data de Nascimento: {employee.BithDate}");
                    Console.WriteLine();
                    Console.WriteLine("Digite o codigo da tarefa: ");
                    var code = int.Parse(Console.ReadLine());
                    Console.WriteLine("Descreva a tarefa que será realizada: ");
                    var task = Console.ReadLine();
                    Console.WriteLine("Digite a data do início da tarefa (dd/mm/yyyy hh:mm): ");
                    var begin = DateTime.Parse(Console.ReadLine());

                    recordService.AddRegister(
                        new Record
                        {
                            Id = Guid.NewGuid(),
                            Task = task,
                            Code = code,
                            Begin = begin
                        });
                }
                if (option == 2)
                {
                    var end = "n";
                    Console.Clear();
                    Console.Write("Digite o código da tarefa que deseja editar: ");
                    var code = int.Parse(Console.ReadLine());
                    var record = recordService.SerchForCode(code);
                    Console.WriteLine();
                    Console.WriteLine("Informações atuais da tarefa:");
                    Console.WriteLine($"Código: {record.Code}");
                    Console.WriteLine($"Tarefa: {record.Task}");
                    Console.WriteLine($"Data Início: {record.Begin}");
                    Console.WriteLine($"Data Fim: {record.End}");
                    Console.WriteLine();

                    while (end != "s")
                    {
                        Console.WriteLine("Qual informação deseja alterar? ");
                        Console.WriteLine("1 - Código");
                        Console.WriteLine("2 - Tarefa");
                        Console.WriteLine("3 - Data Início");
                        Console.WriteLine("4 - Data Fim");
                        var n = int.Parse(Console.ReadLine());

                        if (n == 1)
                        {
                            Console.Write("Digite o nome do funcionário: ");
                            var name = Console.ReadLine();
                            employee.Name = name;

                            employeeService.UpdateRegister(employee);
                        }
                        if (n == 2)
                        {
                            Console.Write("Digite o CPF do funcionário: ");
                            cpf = Console.ReadLine();
                            employee.CPF = cpf;
                            employeeService.UpdateRegister(employee);
                        }
                        if (n == 3)
                        {
                            Console.Write("Digite a data de nascimento do funcionário: ");
                            var date = DateTime.Parse(Console.ReadLine());
                            employee.BithDate = date;
                            employeeService.UpdateRegister(employee);
                        }
                        else
                        {
                            Console.WriteLine("Opção Inválida");
                            end = "n";
                        }
                        Console.Write("Deseja encerrar a edição? s/n ");
                        end = Console.ReadLine();
                    }
                }
                if (option == 3)
                {
                    Console.Clear();
                    Console.Write("Digite o CPF do funcionário que deseja remover: ");
                    var cpf = Console.ReadLine();
                    var employee = employeeService.SerchForCPF(cpf);
                    Console.WriteLine();
                    Console.WriteLine("Informações atuais do funcionário:");
                    Console.WriteLine($"Nome: {employee.Name}");
                    Console.WriteLine($"CPF: {employee.CPF}");
                    Console.WriteLine($"Data de Nascimento: {employee.BithDate}");
                    Console.WriteLine();
                    Console.Write("Confirma a remoção? s/n: ");
                    var confirm = Console.ReadLine();

                    if (confirm == "s")
                    {
                        employeeService.RemoveRegister(employee.Id);
                    }
                    else
                    {
                        Console.WriteLine("Retornando ao menu principal....");
                    }
                }
            }






            //Console.Write("Digite o CPF do funcionario que deseja cadastrar a tarefa: ");
            //var employeeCPF = Console.ReadLine();

            //var employe = employeeService.SerchForCPF(employeeCPF);

            //Console.WriteLine("Informações do funcionário:");
            //Console.WriteLine($"Nome: {employe.Name}");
            //Console.WriteLine($"CPF: {employe.CPF}");
            //Console.WriteLine($"Data de Nascimento: {employe.BithDate}");
            ////Console.Write("Confirma o inicio do registro?");
            ////confirma = Console.ReadLine();
            //Console.WriteLine(" ");
            //Console.WriteLine("Digite o codigo da tarefa: ");
            //var code = int.Parse(Console.ReadLine());
            //Console.WriteLine("Descreva a tarefa que será realizada: ");
            //var task = Console.ReadLine();
            //Console.WriteLine("Digite a data do início da tarefa (dd/mm/yyyy hh:mm): ");
            //var begin = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine(" ");
            //Console.WriteLine("Cadastrando tarefa...");
            //recordService.AddRegister(new Record
            //{
            //    Id = Guid.NewGuid(),
            //    Code = code,
            //    Task = task,
            //    Begin = begin,
            //    EmployeeId = employe.Id
            //});

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