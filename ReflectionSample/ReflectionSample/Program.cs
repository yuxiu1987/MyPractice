using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;

/// <summary>
/// 解析XML表并自动将数据赋值给对象
/// </summary>
namespace ReflectionSample
{
    class Program
    {       


        static void Main(string[] args)
        {
            XmlNodeList nodelist;
            List<SampleClass> list = new List<SampleClass>();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("SeatClass.xml");
            XmlElement root = xmldoc.DocumentElement;//获取根
            nodelist = root.ChildNodes;

            for(int i=0;i<nodelist.Count;i++)
            {
                list.Add(new SampleClass());
            }

            for(int i =0; i<nodelist.Count ; i++)
            {
                list[i] = AutoAssignMethod.AutoAssign(list[i], nodelist[i]) as SampleClass;
            }

            SampleClass spobj = new SampleClass();
            object obj = spobj;
            Type type = obj.GetType();
            Console.WriteLine(type.Name);
            Console.WriteLine(obj.GetType().Name);

            double abc = 1.5;
            Console.WriteLine(abc.GetType().Name);
            

            foreach(var item in list)
            {
                Console.WriteLine(item.SeatName);
                Console.WriteLine(item.Length);
                Console.WriteLine(item.Width);
            }
            Console.ReadKey();
        }
    }

    class SampleClass
    {
        public string SeatName { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }

    static class AutoAssignMethod
    {
        //自动赋值方法
        public static object AutoAssign(object instance, XmlNode node)
        {
            Type type = instance.GetType();
            var properties = type.GetProperties();         

            foreach(XmlNode nodeitem in node)
            {
                //从属性列表中选出与节点名相同的项
                var findedproperty = (from item in properties
                         where item.Name == nodeitem.Name
                         select item).ToList()[0] as PropertyInfo;
                //根据属性数据类型执行相应赋值操作
                switch (findedproperty.PropertyType.Name)
                {
                    //如果是Int32型，执行数据转换后赋值
                    case "Int32":
                                findedproperty.SetValue(instance, Convert.ToInt32(nodeitem.InnerText));
                                break;

                    //字符串型，直接赋值
                    case "String":
                                findedproperty.SetValue(instance, nodeitem.InnerText);
                                break;
                }
            }
            return instance;
        }
    }
}
