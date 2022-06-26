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
            
            while (menu != 2)
            {
                Console.Clear();
                Console.WriteLine("Deseja visualizar: ");
                Console.WriteLine("1 - Funcionarios");
                Console.WriteLine("2 - Tarefas");
                Console.Write("Opção: ");
                var decision = int.Parse(Console.ReadLine());
                var menuEmployee = 1;
                var menuRecord = 1;

                if (decision == 1)
                {
                    while (menuEmployee != 2) 
                    {
                        Console.Clear();
                        Console.WriteLine("############ FUNCIONÁRIO ###############");
                        Console.WriteLine(" ");
                        Console.WriteLine("Digite a opção de que deseja realizar: ");
                        Console.WriteLine("1 - Cadastrar Funcionário");
                        Console.WriteLine("2 - Editar Funcinário");
                        Console.WriteLine("3 - Remover Funcionário");
                        Console.WriteLine("4 - Retornar");
                        var option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            var op1 = "s";
                            while (op1 == "s")
                            {
                                Console.Clear();
                                Console.Write("Digite o nome do funcionário: ");
                                var name = Console.ReadLine();
                                Console.Write("Digite o CPF do funcionário: ");
                                var cpf = Console.ReadLine();
                                Console.Write("Digite a data de nascimento do funcionário: ");
                                var date = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Console.WriteLine("Cadastrando funcionário ...");
                                employeeService.AddRegister(
                                    new Employee
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = name,
                                        CPF = cpf,
                                        BithDate = date
                                    });
                                Console.WriteLine();
                                Console.Write("Deseja realizar outro cadastro? s/n ");
                                op1 = Console.ReadLine();
                            }
                        }
                        if (option == 2)
                        {
                            var op2 = "s";
                            while (op2 != "n")
                            {
                                Console.Clear();
                                Console.Write("Digite o CPF do funcionário que deseja editar: ");
                                var cpf = Console.ReadLine();
                                Console.WriteLine("Buscando funcionário...");
                                var employee = employeeService.SearchForCPF(cpf);
                                Console.Clear();
                                Console.WriteLine("Informações atuais do funcionário:");
                                Console.WriteLine($"Nome: {employee.Name}");
                                Console.WriteLine($"CPF: {employee.CPF}");
                                Console.WriteLine($"Data de Nascimento: {employee.BithDate}");
                                Console.WriteLine();    
                                                            
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
                                Console.Write("Deseja realizar outra edição? s/n ");
                                op2 = Console.ReadLine();
                            }
                        }
                        if (option == 3)
                        {
                            var op3 = "s";
                            while (op3 != "n")
                            {
                                Console.Clear();
                                Console.Write("Digite o CPF do funcionário que deseja remover: ");
                                var cpf = Console.ReadLine();
                                Console.WriteLine("Buscando funcionário...");
                                var employee = employeeService.SearchForCPF(cpf);
                                Console.Clear();
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
                                    op3 = "n";
                                }
                                else
                                {
                                    op3 = "n";
                                }
                            }
                        }
                        if (option == 4)
                        {
                            menuEmployee = 2;
                            menu = 1;
                        }
                        else
                        {
                            Console.WriteLine("Opção Inválida!");
                            menuEmployee = 1;
                        }
                    }
                    
                }
                if (decision == 2)
                {
                    while (menuRecord != 2)
                    {
                        Console.Clear();
                        Console.WriteLine("############ TAREFAS ###############");
                        Console.WriteLine(" ");
                        Console.WriteLine("Digite a opção de que deseja realizar: ");
                        Console.WriteLine("1 - Cadastrar Tarefa");
                        Console.WriteLine("2 - Editar Tarefa");
                        Console.WriteLine("3 - Remover Tarefa");
                        Console.WriteLine("4 - Retornar");
                        Console.WriteLine("Opção: ");
                        var option = int.Parse(Console.ReadLine());

                        if (option == 1)
                        {
                            var end = "s";
                            while (end != "n")
                            {

                                Console.Clear();
                                Console.Write("Digite o CPF do funcinário da tarefa: ");
                                var cpf = Console.ReadLine();
                                var employee = employeeService.SearchForCPF(cpf);
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
                                        Begin = begin,
                                        EmployeeId = employee.Id
                                    });

                                Console.Write("Deseja encerrar realizar outro cadastro?? s/n ");
                                end = Console.ReadLine();
                            }
                        }
                        if (option == 2)
                        {
                            var end = "n";
                            Console.Clear();
                            Console.Write("Digite o código da tarefa que deseja editar: ");
                            var code = int.Parse(Console.ReadLine());
                            var record = recordService.SearchForCode(code);
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
                                    Console.Write("Digite o Código da tarefa: ");
                                    var codeNew = int.Parse(Console.ReadLine());
                                    record.Code = codeNew;

                                    recordService.UpdateRegister(record);
                                }
                                if (n == 2)
                                {
                                    Console.Write("Digite a nova descrição da tarefa: ");
                                    var task = Console.ReadLine();
                                    record.Task = task;

                                    recordService.UpdateRegister(record);
                                }
                                if (n == 3)
                                {
                                    Console.Write("Digite a nova data de inicio da tarefa: ");
                                    var date = DateTime.Parse(Console.ReadLine());
                                    record.Begin = date;
                                    recordService.UpdateRegister(record);
                                }
                                if (n == 4)
                                {
                                    Console.Write("Digite a nova data de inicio da tarefa: ");
                                    var date = DateTime.Parse(Console.ReadLine());
                                    record.End = date;
                                    recordService.UpdateRegister(record);
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
                            Console.Write("Digite o codigo da tarefa que deseja remover: ");
                            var code = int.Parse(Console.ReadLine());
                            var record = recordService.SearchForCode(code);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Informações atuais da tarefa:");
                            Console.WriteLine($"Código: {record.Code}");
                            Console.WriteLine($"Tarefa: {record.Task}");
                            Console.WriteLine($"Data Início: {record.Begin}");
                            Console.WriteLine($"Data Fim: {record.End}");
                            Console.WriteLine();
                            Console.Write("Confirma a remoção? s/n: ");
                            var confirm = Console.ReadLine();

                            if (confirm == "s")
                            {
                                recordService.RemoveRegister(record.Id);
                            }
                            else
                            {
                                Console.WriteLine("Retornando ao menu principal....");
                            }
                        }
                        if (option == 4)
                        {
                            menuRecord = 2;
                            menu = 1;
                        }
                        else
                        {
                            Console.WriteLine("Opção Inválida!");
                            menuRecord = 1;
                        }
                    }
                }
            }
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