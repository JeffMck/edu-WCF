using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary;

namespace ConsoleHostConfig
{
    class Program
    {
        private static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EvalService));

            //host.AddServiceEndpoint(typeof(IEvalService), new BasicHttpBinding(), "http://localhost:8080/evals/basic");
            //host.AddServiceEndpoint(typeof(IEvalService), new WSHttpBinding(), "http://localhost:8080/evals/ws");
            //host.AddServiceEndpoint(typeof (IEvalService), new NetTcpBinding(), "net.tcp://localhost:8081/evals");

            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadLine();
                host.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                host.Abort();
            }

            Console.ReadLine();
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("{0} is up and running with these endpoints:", host.Description.ServiceType);
            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
}
