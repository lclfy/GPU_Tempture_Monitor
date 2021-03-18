using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class SenserMornitorData
    {
        //挖矿程序进程名称
        public string processName { get; set; }
        public int HighTempDegrees { get; set; }

        public string CPUName { get; set; }
        public float CPUtemp { get; set; }
        public List<string> GPUName { get; set; }
        public List<float> GPUtemp { get; set; }

        public SenserMornitorData()
        {
            processName = "";
            HighTempDegrees = -1;
            CPUName = "";
            CPUtemp = -1;
            GPUName = new List<string>();
            GPUtemp = new List<float>();
        }
        
    }
}
