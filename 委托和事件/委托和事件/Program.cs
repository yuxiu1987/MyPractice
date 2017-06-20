using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 练习场景，飞机制造商将某款飞机投入市场，数个航空公司对此事件做出反应
/// 在这个场景中，事件的订阅者，就是三个航空公司类。而事件的发布者，就是飞机制造商类。而事件的订阅者感兴趣的对象，其实就是飞机机型。而当飞机制造商抛出飞机服役事件之后，事件的订阅者就要对此做出反应。
/// </summary>
namespace 委托和事件
{
    class Program
    {
        static void Main(string[] args)
        {
            AirlinerFactory airfac = new AirlinerFactory { airliner = new Airliner { AirlinerName = "A320-200"} };//实例化飞机制造厂

            //实例化航空公司
            EasternAirline estAirline = new EasternAirline { AirlineName = "EasternAirline" };
            SouthernAirline souAirline = new SouthernAirline { AirlineName = "SouthernAirline" };
            NationalAirline natAirline = new NationalAirline { AirlineName = "NationalAirline" };

            
            

            airfac.AirlinerActiveEvent += new AirlinerFactory.AirlinerActiveEventHandler(estAirline.Receive);//航空公司对事件做出反应,实际就是给事件添加事件处理程序,相当于在事件响应列表上签到
            airfac.AirlinerActiveEvent += new AirlinerFactory.AirlinerActiveEventHandler(souAirline.Receive);
            airfac.AirlinerActiveEvent += new AirlinerFactory.AirlinerActiveEventHandler(natAirline.Receive);

            airfac.AirlinerActive();//飞机服役,方法执行，同时触发飞机服役事件,事件必须在接收者注册后才能触发

            Console.ReadKey();



        }

        /// <summary>
        /// 事件订阅者真正感兴趣的类，机型，也就是e，因此按照规范从EventArgs继承
        /// </summary>
        public class Airliner : EventArgs
        {
            public string AirlinerName { get; set; }
        }

        public class AirlinerFactory
        {
            public Airliner airliner { get; set; } = new Airliner();

            /// <summary>
            /// 声明委托，飞机服役.此委托没有返回类型，包含两个参数
            /// </summary>
            public delegate void AirlinerActiveEventHandler(object airfactory , Airliner e);

            /// <summary>
            /// 定义飞机服役事件,飞机服役方法调用时触发
            /// </summary>
            public event AirlinerActiveEventHandler AirlinerActiveEvent;//把委托声明为事件，也就是把委托给列表化了


            /// <summary>
            /// 飞机服役方法
            /// </summary>
            public void AirlinerActive()
            {
                airliner.AirlinerName = "A320-200";
                
                Console.WriteLine(airliner.AirlinerName + "已经服役");
                
                AirlinerActiveEvent(this , airliner);//在飞机服役方法中触发飞机服役事件，其实就是触发了一个委托列表
            }


        }

        /// <summary>
        /// 东方航空
        /// </summary>
        public class EasternAirline
        {
            public string AirlineName { get; set; }

            /// <summary>
            /// 注意EventArgs是事件所包含信息参数的基类，在此例中，航空公司感兴趣的是飞机制造商里的“机型”,所以“机型”类继承自EventArgs
            /// 前面的sender表示发布信息的类，也就是飞机制造商，后面的e，就是航空公司感兴趣的事件所包含的参数，也就是机型
            /// 同理，如果是鼠标点击事件，那么sender就是被点击的控件，而e就是鼠标点击的信息，比如，是左键还是右键还是中键，鼠标的位置
            /// 如果是按键事件，那e就包含了键盘可以触发的所有信息
            /// </summary>
            public void Receive(object sender , Airliner e)//也就是说，这个Receive方法，其实就是飞机服役事件的处理程序
            {
                Console.WriteLine(AirlineName+"对"+e.AirlinerName+"没有兴趣");
            }
        }

        /// <summary>
        /// 南方航空
        /// </summary>
        public class SouthernAirline
        {
            public string AirlineName { get; set; }
            public void Receive(object sender, Airliner e)
            {
                Console.WriteLine(AirlineName + "对" + e.AirlinerName + "没有兴趣");
            }
        }

        /// <summary>
        /// 国家航空
        /// </summary>
        public class NationalAirline
        {
            public string AirlineName { get; set; }
            public void Receive(object sender, Airliner e)
            {
                Console.WriteLine(AirlineName + "对" + e.AirlinerName + "非常有兴趣");
            }
        }

        
    }
}
