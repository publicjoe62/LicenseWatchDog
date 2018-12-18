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
            Console.WriteLine("Press ESC tp stop");
            while (!Console.KeyAvailable)
            {
                mc.ExecTask();
                Console.WriteLine("sleep start main task");
                Thread.Sleep(1000);
                Console.WriteLine("sleep end main task");
            }
            Console.WriteLine("License Watch Dog Manager :: end app");

        }

        private void ExecTask()
        {
            Task taskA = Task.Run(() => LicenseTask());

            try
            {
                Console.WriteLine("taskA Status: {0}", taskA.Status);
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
            Console.WriteLine("Execute LicenseTask :: start");
            Console.WriteLine("current tasl {0}", Thread.CurrentThread.ToString());
            Task.Sleep(3000);
            Console.WriteLine("Execute LicenseTask :: end");
        }

    }
}
