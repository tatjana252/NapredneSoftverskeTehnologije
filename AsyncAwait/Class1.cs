using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Program
    {
        public async static Task Main()
        {
            //Task<int> t = Test1();

            Console.WriteLine("Main");
            //int a = await t;

            int a = await TestAsync();
            Console.WriteLine(a);
            Thread.Sleep(2000);
        }

        public async static Task<int> TestAsync()
        {
            for(int i = 0; i< 10; i++)
            {
                Console.WriteLine("Test1");
                //Thread.Sleep(500);
                await Task.Delay(500);
            }
            return 10;
        }

        public async static Task Test2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Test2");
               // Thread.Sleep(500);
                 await Task.Delay(500);
            }
        }
    }
}
