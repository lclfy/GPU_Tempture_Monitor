using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Main : Skin_Mac
    {
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }

            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware)
                    subHardware.Accept(this);
            }

            public void VisitSensor(ISensor sensor) { }

            public void VisitParameter(IParameter parameter) { }
        }

        //元数据
        public SenserMornitorData senserMonitorData;

        public int errorCount = -1;

        public Main()
        {
            senserMonitorData = new SenserMornitorData();
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            save();
            base.OnClosing(e);
            Application.Exit();
        }

        private void save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Save();
            if (config.AppSettings.Settings["processName"] == null)
            {
                KeyValueConfigurationElement _k = new KeyValueConfigurationElement("processName", senserMonitorData.processName);
                config.AppSettings.Settings.Add(_k);
            }
            else
            {
                config.AppSettings.Settings["processName"].Value = senserMonitorData.processName;
            }
            if (config.AppSettings.Settings["highTemp"] == null)
            {
                KeyValueConfigurationElement _k = new KeyValueConfigurationElement("highTemp", senserMonitorData.HighTempDegrees.ToString());
                config.AppSettings.Settings.Add(_k);
            }
            else
            {
                config.AppSettings.Settings["highTemp"].Value = senserMonitorData.HighTempDegrees.ToString();
            }
            config.Save();
            ConfigurationManager.RefreshSection("highTemp");
            ConfigurationManager.RefreshSection("processName");
        }

        //
        private void load()
        {
            string processName = ConfigurationManager.AppSettings["processName"];
            if (processName == null)
            {
                processName = "";
            }
            int highTemp;
            int.TryParse(ConfigurationManager.AppSettings["highTemp"], out highTemp);
            if(highTemp <= 0)
            {
                highTemp = 90;
            }
            processName_tb.Text = processName.Split('.')[0];
            highTemp_tb.Text = highTemp.ToString();
            senserMonitorData.processName = processName;
            senserMonitorData.HighTempDegrees = highTemp;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            load();
            timer1.Interval = 1500;  //定时器时间间隔
            timer1.Start();   //定时器开始工作

            //表格初始化
            GPUList_lv.View = View.Details;
            string[] informationTitle = new string[] { "ID", "设备名称", "温度" };
            this.GPUList_lv.BeginUpdate();
            for (int i = 0; i < 3; i++)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = informationTitle[i];   //设置列标题 
                if (i == 0 || i == 2)
                {
                    ch.Width = 55;
                }
                else if (i == 1)
                {
                    ch.Width = 250;
                }
                this.GPUList_lv.Columns.Add(ch);    //将列头添加到ListView控件。
            }

            this.GPUList_lv.EndUpdate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateSenserData();
            UpdateList();
            string result = ConfirmTemptures();
            if (result.Length != 0)
            {
                errorCount++;
                timer1.Interval = 10000;  //定时器时间间隔
                timer1.Start();   //定时器开始工作
                if(errorCount == 0)
                {
                    DialogResult msg = new DialogResult();
                    msg = MessageBox.Show("该设备温度过高：\n" + result + "\n尝试关闭程序：" + senserMonitorData.processName, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if(msg == DialogResult.OK)
                    {
                        timer1.Stop();
                    }
                }
                else if(errorCount > 0)
                {
                    autoShutdown();
                }

            }
            
        }

        private void UpdateSenserData()
        {
                time_lbl.Text = DateTime.Now.ToString();
                UpdateVisitor updateVisitor = new UpdateVisitor();
                Computer computer = new Computer();
                computer.CPUEnabled = true;
                computer.GPUEnabled = true;
                computer.Open();
                computer.Accept(updateVisitor);

                foreach (IHardware hardware in computer.Hardware)
                {
                    int ii = 0;
                }
            List<string> GPUNames = new List<string>();
            List<float> GPUTemps = new List<float>();
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    //查找硬件类型为CPU
                    if(computer.Hardware[i].HardwareType == HardwareType.CPU ||
                    computer.Hardware[i].HardwareType == HardwareType.GpuNvidia||
                    computer.Hardware[i].HardwareType == HardwareType.GpuAti)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        //找到温度传感器
                        if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                            {
                                senserMonitorData.CPUName = computer.Hardware[i].Name;
                                senserMonitorData.CPUtemp = (float)computer.Hardware[i].Sensors[j].Value;
                            }
                        }
                            //NV
                            if (computer.Hardware[i].HardwareType == HardwareType.GpuNvidia)
                            {
                                    if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                                    {
                                        string nvName = computer.Hardware[i].Name;
                                        float _nvTemp = (float)computer.Hardware[i].Sensors[j].Value;
                                        GPUNames.Add(nvName);
                                        GPUTemps.Add(_nvTemp);
                                    }
                            }
                            //AMD
                            if (computer.Hardware[i].HardwareType == HardwareType.GpuAti)
                            {
                                    if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature && computer.Hardware[i].Sensors[j].Name.Contains("Hot Spot"))
                                    {
                                        string amdName = computer.Hardware[i].Name;
                                        float _amdTemp = (float)computer.Hardware[i].Sensors[j].Value;
                                        GPUNames.Add(amdName);
                                        GPUTemps.Add(_amdTemp);
                                    }
                            }
                    }
                }
                senserMonitorData.GPUName = GPUNames;
                senserMonitorData.GPUtemp = GPUTemps;

                }
        }

        private void UpdateList()
        {
            /*
            GPUList_lv.LargeImageList = imageList1;
            imageList1.ImageSize = new Size(70, 50);
            GPUList_lv.Items.Add("NVIDIA");
            GPUList_lv.Items.Add("AMD");
            GPUList_lv.Items[0].ImageIndex = 0;
            GPUList_lv.Items[1].ImageIndex = 1;
            */

            this.GPUList_lv.BeginUpdate();
            GPUList_lv.Items.Clear();
            ListViewItem lviCPU = new ListViewItem();
            lviCPU.SubItems[0].Text = "CPU";
            lviCPU.SubItems.Add(senserMonitorData.CPUName);
            lviCPU.SubItems.Add(senserMonitorData.CPUtemp.ToString() + "℃");
            GPUList_lv.Items.Add(lviCPU);
            List<string> GPUname = senserMonitorData.GPUName;
            List<float> GPUTemp = senserMonitorData.GPUtemp;
            for(int i = 0; i < GPUname.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = (i + 1).ToString();
                lvi.SubItems.Add(GPUname[i]);
                lvi.SubItems.Add(GPUTemp[i].ToString()+"℃");
                this.GPUList_lv.Items.Add(lvi);
            }
            this.GPUList_lv.EndUpdate();
        }

        private string ConfirmTemptures()
        {
            if(senserMonitorData.CPUtemp >= senserMonitorData.HighTempDegrees)
            {
                if (taskkills())
                {
                    return "CPU："+ senserMonitorData.CPUtemp.ToString() +"℃";
                }
            }
            for(int i = 0; i < senserMonitorData.GPUtemp.Count; i++)
            {
                if(senserMonitorData.GPUtemp[i] >= senserMonitorData.HighTempDegrees)
                {
                    if (taskkills())
                    {
                        return senserMonitorData.GPUName[i] + "：" + senserMonitorData.GPUtemp[i] + "℃";
                    }
                }
            }
            return "";
        }

        //杀进程
        private bool taskkills()
        {
            //获得进程对象，以用来操作  
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程   
            try
            {
                //获得需要杀死的进程名  
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(senserMonitorData.processName))
                {
                    //立即杀死进程 
                    thisproc.Kill();
                }
            }
            catch (Exception Exc)
            {
                return false;
            }
            return true;
        }

        //如果杀进程温度还高，60秒自动关机
        private void autoShutdown()
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            myProcess.StandardInput.WriteLine("shutdown -s -t 60");
            DialogResult msg = new DialogResult();
                msg = MessageBox.Show("由于设备温度过高，系统即将在60秒内自动关机，点击按钮以取消关机", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (msg == DialogResult.Yes)
                {
                System.Diagnostics.Process myProcess1 = new System.Diagnostics.Process();
                myProcess1.StartInfo.FileName = "cmd.exe";
                myProcess1.StartInfo.UseShellExecute = false;
                myProcess1.StartInfo.RedirectStandardInput = true;
                myProcess1.StartInfo.RedirectStandardOutput = true;
                myProcess1.StartInfo.RedirectStandardError = true;
                myProcess1.StartInfo.CreateNoWindow = true;
                myProcess1.Start();
                myProcess1.StandardInput.WriteLine("shutdown -a");
                timer1.Stop();
            }
            return;
            }

        //温度框只能输入数字
        private void highTemp_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string processName = processName_tb.Text.ToString();
            int highTemp = -1;
            int.TryParse(highTemp_tb.Text.ToString(), out highTemp);
            if(highTemp > 110)
            {
                highTemp = 110;
                highTemp_tb.Text = "110";
            }
            if(highTemp < 0)
            {
                highTemp = 0;
                highTemp_tb.Text = "0";
            }
            senserMonitorData.processName = processName;
            senserMonitorData.HighTempDegrees = highTemp;
            errorCount = -1;
            timer1.Interval = 1500;  //定时器时间间隔
            timer1.Start();
            save();
        }

        private void killProcess_btn_Click(object sender, EventArgs e)
        {
            taskkills();
        }
    }
}
