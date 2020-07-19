using System;
using System.Threading;
using System.Threading.Tasks;

namespace TAP_Practice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // ex01 : 製作披薩
            //Console.WriteLine("開始進行製作披薩...");
            //var cts = new CancellationTokenSource();
            //try
            //{
            //    // 同時發起
            //    var task1 = Task.Run(async () => { await DoWork("烤箱預熱", 15, cts); }, cts.Token);
            //    var task2 = Task.Run(async () => { await DoWork("製作麵團", 3, cts); }, cts.Token);
            //    var task3 = Task.Run(async () => { await DoWork("發麵", 8, cts); }, cts.Token);
            //    var task4 = Task.Run(async () => { await DoWork("準備醬料", 2, cts); }, cts.Token);
            //    var task5 = Task.Run(async () => { await DoWork("準備配料", 2, cts); }, cts.Token);
            //    var task6 = Task.Run(async () => { await DoWork("製作披薩餅皮與醬料", 3, cts); }, cts.Token);
            //    // 等上面全部作完
            //    await task2;
            //    cts.Cancel();
            //    await task1;
            //    await task3;
            //    await task4;
            //    await task5;
            //    await task6;
            //    // 再開始最後一個流程
            //    Console.WriteLine($"===開始烤披薩===");
            //    var task7 = Task.Run(async () => { await DoWork("烤製披薩", 6, cts); }, cts.Token);
            //    await task7;
            //}
            //catch (OperationCanceledException e)
            //{
            //    Console.WriteLine("Task Canceled");
            //}

            // ex02 : 煮飯
            Console.WriteLine("開始進行煮飯...");
            var cts = new CancellationTokenSource();
            try
            {
                for (var i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"Round {i}");

                    var task1 = Task.Run(async () =>
                    {
                        Console.WriteLine($"TaskId:{Task.CurrentId}");
                        await DoWork("買菜", 5, cts);
                    }, cts.Token);
                    var task2 = Task.Run(async () =>
                    {
                        Console.WriteLine($"TaskId:{Task.CurrentId}");
                        await DoWork("買蛋", 4, cts);
                    }, cts.Token);
                    var task3 = Task.Run(async () =>
                    {
                        Console.WriteLine($"TaskId:{Task.CurrentId}");
                        await DoWork("買米", 2, cts);
                        await DoWork("煮飯", 2, cts);
                    }, cts.Token);

                    // 中途取消task,要再await之前
                    if (i == 3)
                    {
                        cts.Cancel();
                    }

                    await task1;
                    await task2;
                    await task3;

                    await DoWork("炒飯", 3, cts);
                }
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine("Task Canceled");
            }

            // todo : 中途噴錯處理 https://csharpkh.blogspot.com/2018/08/TAP-Task-Asynchronous-Synchronous-Exception.html
        }

        private static async Task DoWork(string workName, int workSecondTime, CancellationTokenSource cts)
        {
            if (cts.Token.IsCancellationRequested)
            {
                cts.Token.ThrowIfCancellationRequested();
            }
            await Task.Delay(workSecondTime * 1000);
            Console.WriteLine($"{workName} finish - 花費 {workSecondTime} 秒");
        }
    }
}
