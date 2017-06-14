using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Worker workerobject = new Worker();

            //将DoWork方法的引用作为构造函数参数传递给thread的实例
            Thread workerThread = new Thread(workerobject.DoWork);

            workerThread.Start();//线程实例需要调用start方法以开始一个新的线程

            while (!workerThread.IsAlive) ;//无限循环，workerThread.IsAlive不为true时，循环一直持续下去，以保证程序结束前进程能够被执行

            Thread.Sleep(10);//休眠主线程,保证辅助线程在主线程结束前能够执行若干次

            workerobject.RequestStop();//通知辅助线程停止

            workerThread.Join();//主函数调用workerThread的Join()方法，阻塞当前线程，直到对象的线程结束

            Console.WriteLine("main thread: Worker thread has terminated.");

            Console.ReadKey();

        }
    }

    class Worker
    {
        private volatile bool _Shouldstop;

        public void DoWork()
        {
            int i = 1;
            while(!_Shouldstop)
            {
                Console.WriteLine("worker thread : working!"+" "+i);
                i++;
            }
            Console.WriteLine("worker thread : terminating gracefully!");
        }

        public void RequestStop()
        {
            _Shouldstop = true;
        }
    }
}
