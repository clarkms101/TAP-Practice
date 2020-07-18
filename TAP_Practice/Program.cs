using System;
using System.Threading;
using System.Threading.Tasks;

namespace TAP_Practice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("開始進行製作披薩...");

            // 同時發起
            var task1 = Task.Run(async () => { await DoWork("烤箱預熱", 15); });
            var task2 = Task.Run(async () => { await DoWork("製作麵團", 3); });
            var task3 = Task.Run(async () => { await DoWork("發麵", 8); });
            var task4 = Task.Run(async () => { await DoWork("準備醬料", 2); });
            var task5 = Task.Run(async () => { await DoWork("準備配料", 2); });
            var task6 = Task.Run(async () => { await DoWork("製作披薩餅皮與醬料", 3); });

            // 等上面全部作完
            await task1;
            await task2;
            await task3;
            await task4;
            await task5;
            await task6;

            // 再開始最後一個流程
            Console.WriteLine($"===開始烤披薩===");
            var task7 = Task.Run(async () => { await DoWork("烤製披薩", 6); });
            await task7;
        }

        private static async Task DoWork(string workName, int workSecondTime)
        {
            Console.WriteLine($"{workName} start - 預計 {workSecondTime} 秒 - {Task.CurrentId}");
            await Task.Delay(workSecondTime * 1000);
            Console.WriteLine($"{workName} finish - 花費 {workSecondTime} 秒");
        }
    }
}
