using DesignPatterns.Decorator.Decorator_App;
using DesignPatterns.Decorator.RepositoryDecorator;
using System;

namespace DesignPatterns.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Basics of Decorator Pattern
            Console.WriteLine("AppDatagram");
            AppDatagram appDatagram = new AppDatagram();
            appDatagram.Send();

            Console.WriteLine("\nUseTCP");
            Console.WriteLine("****************");
            UseTCP useTCP = new UseTCP(appDatagram);
            useTCP.Send();

            Console.WriteLine("\nUseUDP");
            Console.WriteLine("****************");
            UseUDP useUDP = new UseUDP(appDatagram);
            useUDP.Send();
            #endregion


            Console.WriteLine(
                "\n" +
                "---------------------------------------------------------------\n" +
                "---------------------------------------------------------------\n" +
                "---------------------------------------------------------------\n" +
                "---------------------------------------------------------------\n");


            #region Decorator Pattern in Repository Pattern
            Console.WriteLine("Repository");
            Repository<Employee> repository = new Repository<Employee>();
            repository.Get(3);
            repository.GetAll();
            repository.Add(new Employee());
            repository.Delete(new Employee());
            repository.Update(new Employee());

            Console.WriteLine("\nSecurityRepositoryDecorator");
            Console.WriteLine("****************");
            SecurityRepositoryDecorator<Employee> securityRepositoryDecorator = new SecurityRepositoryDecorator<Employee>(repository);
            securityRepositoryDecorator.Get(3);
            securityRepositoryDecorator.GetAll();
            securityRepositoryDecorator.Add(new Employee());
            securityRepositoryDecorator.Delete(new Employee());
            securityRepositoryDecorator.Update(new Employee());

            Console.WriteLine("\nLoggingRepositoryDecorator");
            Console.WriteLine("****************");
            LoggingRepositoryDecorator<Employee> loggingRepositoryDecorator = new LoggingRepositoryDecorator<Employee>(repository);
            loggingRepositoryDecorator.Get(3);
            loggingRepositoryDecorator.GetAll();
            loggingRepositoryDecorator.Add(new Employee());
            loggingRepositoryDecorator.Delete(new Employee());
            loggingRepositoryDecorator.Update(new Employee());

            Console.WriteLine("\nSendCRMRepositoryDecorator");
            Console.WriteLine("****************");
            SendCRMRepositoryDecorator<Employee> sendCRMRepositoryDecorator = new SendCRMRepositoryDecorator<Employee>(repository);
            sendCRMRepositoryDecorator.Get(3);
            sendCRMRepositoryDecorator.GetAll();
            sendCRMRepositoryDecorator.Add(new Employee());
            sendCRMRepositoryDecorator.Delete(new Employee());
            sendCRMRepositoryDecorator.Update(new Employee());

            Console.WriteLine("\nSendMailRepositoryDecorator");
            Console.WriteLine("****************");
            SendMailRepositoryDecorator<Employee> sendMailRepositoryDecorator = new SendMailRepositoryDecorator<Employee>(repository);
            sendMailRepositoryDecorator.Get(3);
            sendMailRepositoryDecorator.GetAll();
            sendMailRepositoryDecorator.Add(new Employee());
            sendMailRepositoryDecorator.Delete(new Employee());
            sendMailRepositoryDecorator.Update(new Employee());
            #endregion
        }
    }
}
