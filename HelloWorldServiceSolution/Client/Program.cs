using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.HelloWorldServiceReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldClient client = new HelloWorldClient("BasicHttpBinding_IHelloWorld");
            Name person = new Name();
            person.First = "Jay";
            person.Last = "Lars";
            Console.WriteLine(client.SayHello(person));
            Console.ReadLine();
        }
    }
}
