using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client.EvalServiceReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a factory
            ///////////////////////////////////////////////////
            
            // factory by name
            ChannelFactory<IEvalService> factory1 = new ChannelFactory<IEvalService>("BasicHttpBinding_IEvalService");

            // factory by endpoint
            ChannelFactory<IEvalService> factory2 = new ChannelFactory<IEvalService>(new WSHttpBinding(), "http://localhost:8080/evals/wsconfig");

            // channel - basic, hidden IClientChannel
            ///////////////////////////////////////////////////
            IEvalService channel1 = factory1.CreateChannel();

            try
            {
                channel1.GetEvals();

                Eval eval = new Eval();
                eval.Submitter = "Jay";
                eval.Timesent = DateTime.Now;
                eval.Comments = "One eval to rule them alll!!!!!!!!!";

                channel1.SubmitEval(eval);
                channel1.SubmitEval(eval);

                Console.ReadLine();

                ((IClientChannel)channel1).Close();
            }
            catch (Exception)
            {
                ((IClientChannel)channel1).Abort();
            }

            // channel client - integrated IClientChannel
            ///////////////////////////////////////////////////
            ChannelFactory<IEvalServiceChannel> factory3 = new ChannelFactory<IEvalServiceChannel>("BasicHttpBinding_IEvalService");

            IEvalServiceChannel channel2 = factory3.CreateChannel();

            try
            {
                Eval[] evals = channel2.GetEvals();
                Console.WriteLine("Number of evals: {0}", evals.Length);

                Console.ReadLine();

                channel2.Close();
            }
            catch (Exception)
            {
                channel2.Abort();
            }

            // proxy client
            ///////////////////////////////////////////////////
            EvalServiceClient client1 = new EvalServiceClient("BasicHttpBinding_IEvalService");

            try
            {
                Eval[] evals = client1.GetEvals();
                Console.WriteLine("Number of evals: {0}", evals.Length);

                Console.ReadLine();

                client1.Close();
            }
            catch (Exception)
            {
                client1.Abort();
            }
        }
    }
}
