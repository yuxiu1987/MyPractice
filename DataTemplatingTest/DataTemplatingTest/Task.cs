using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplatingTest
{
    public class Task
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }

        public TaskType type { get; set; }
        
        public enum TaskType :int { Home = 1 , Office}

        //通过重写Tostring方法，让ListBox显示出Name的实际内容
        //Listbox默认情况下是直接调用集合元素的Tostring()方法
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
