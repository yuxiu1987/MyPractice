using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessBasedOnTimelineTest
{
    class Class1
    {
    }

    public class AirlinerEvent
    {
        public string EventName { get; set; }

        public delegate void ThisEventProcessHandle();
    }
}
