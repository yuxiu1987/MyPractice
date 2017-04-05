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

            Type type = typeof(SampleClass);
            var properties = type.GetProperties();

            for(int i=0;i<nodelist.Count;i++)
            {
                foreach (var property in properties)
                {
                    //根据属性数据类型执行相应赋值操作
                    switch(property.PropertyType.Name)
                    {
                        //如果是Int32型，执行数据转换后赋值
                        case "Int32":
                            foreach (XmlNode item in nodelist[i])
                            {
                                if (property.Name == item.Name)
                                {
                                    property.SetValue(list[i], Convert.ToInt32(item.InnerText));
                                    break;
                                }
                            }
                            break;
                        //字符串型，直接赋值
                        case "String":
                            foreach (XmlNode item in nodelist[i])
                            {
                                if (property.Name == item.Name)
                                {
                                    property.SetValue(list[i], item.InnerText);
                                    break;
                                }
                            }
                            break;
                    }
                }
            }

            SampleClass spobj = new SampleClass();
            object obj = spobj;

            Console.WriteLine(obj.GetType().Name);

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
}
