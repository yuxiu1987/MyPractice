using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 计时器测试，线程模式
/// </summary>
namespace ThreadTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTimer myTimer = new MyTimer(); 

            //创建新线程，新线程运行CountTime方法。
            Thread TimeThread = new Thread(myTimer.CountTime);
            TimeThread.Start();

            //主线程挂起10秒
            Thread.Sleep(10000);
            myTimer.StopTimer();

            Console.ReadKey();
        }
    }

    class MyTimer
    {
        public volatile bool StopFlag = true;
        public int i = 0;
        public void CountTime()
        {
            while (StopFlag == true)
            {
                // System.Timers.Timer timer = new System.Timers.Timer(1000);

                //此线程每挂起500ms后，i++，因为开在新的线程中，因此不影响其他任务执行
                Thread.Sleep(500);
                i++;
                Console.WriteLine("+" + i + "s");
            }            
        }

        public void StopTimer()
        {
            StopFlag = false;
            i = 0;
        }
    }
}
