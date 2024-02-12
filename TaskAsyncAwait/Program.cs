using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncAwait
{
    internal class Program
    {
        public static async Task Cooking()
        {
            Console.WriteLine("Cooking Start..");
            await Task.Delay(3000);
            Console.WriteLine("Cooking Complete");
        }
        public static async Task Eating()
        {
            Console.WriteLine("Eating Start..");
            await Task.Delay(2000);
            Console.WriteLine("Eating Complete");
        }
        public async static Task<string> Azan()
        {
            Console.WriteLine("Azan Start..");
            await Task.Delay(2000);
            Console.WriteLine("Azan Complete");

            return "Azan Complete.";
        }
        public static async Task Salat(string azan)
        {
            Console.WriteLine($"{azan} --Salat Start..");
            await Task.Delay(2000);
            Console.WriteLine("Salat Complete");
        }
        static void  Main(string[] args)
        {
            async void StartAllTask()
            {
                Console.WriteLine("Start All Task..");

                Task azanSalat = AzanSalat();
                Task cooking = Cooking();
                Task eating = Eating();


                await Task.WhenAll(azanSalat, cooking, eating);
                Console.WriteLine("End All Task.");
            }
            StartAllTask();


            Console.ReadKey();
        }

        private static async Task AzanSalat()
        {
            string azan = await Azan();
            await Salat(azan);
        }
    }
}
