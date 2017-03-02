using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XmlCopy
{
    /// <summary>
    /// 根据第一个城市表中的国家代码，从国家表中按顺序取出国家名
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {


            XmlDocument city = new XmlDocument();
            city.Load("Cities.xml");
            XmlElement cityroot = city.DocumentElement;
            XmlNodeList citylist = cityroot.ChildNodes;

            XmlDocument country = new XmlDocument();
            country.Load("country.xml");
            XmlElement countryroot = country.DocumentElement;
            XmlNodeList countrylist = countryroot.ChildNodes;

            List<string> strlist = new List<string>();


            foreach (XmlNode xn in citylist)
            {
                bool insetflag = true;
                foreach (XmlNode xnc in countrylist)
                {
                    if (xn["Country"].InnerText == xnc["code"].InnerText)
                    {
                        strlist.Add(xnc["name1"].InnerText);
                        insetflag = true;
                        break;
                    }
                    else { insetflag = false; }
                }
                if (insetflag == false)
                {
                    strlist.Add(xn["Country"].InnerText);
                }

            }

            string[] strarray = new string[strlist.Count];
            for (int i = 0; i < strarray.Length; i++)
            {
                strarray[i] = strlist[i];
                Console.WriteLine(strarray[i]);
            }
            Console.ReadLine();

            File.WriteAllLines("123.txt", strarray);



        }
    }
}
