using System;
using System.Threading;
using System.Threading.Tasks;

namespace LicenseWatchDog
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            MainClass mc = new MainClass();

            Console.WriteLine("License Watch Dog Manager :: start app");
            mc.ExecTask();
            Console.WriteLine("License Watch Dog Manager :: end app");

        }

        private void ExecTask()
        {
            Task taskA = Task.Run(() => LicenseTask());
            Console.WriteLine("taskA Status: {0}", taskA.Status);
            try
            {
                taskA.Wait();
                Console.WriteLine("taskA Status: {0}", taskA.Status);
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA");
            }
        }

        private void LicenseTask()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
        }

    }
}
