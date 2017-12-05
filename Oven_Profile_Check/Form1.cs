using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oven_Profile_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string T1_Oven_IP = "10.185.110.12";
        private static string T5_Oven_IP = "10.185.126.2";
        private static string T3_Oven137_IP = "10.185.56.137";
        private static string T3_Oven102_IP = "10.185.56.102";

        private void Form1_Load(object sender, EventArgs e)
        {
            GetFileCount(T1_Oven_IP);
            GetFileCount(T5_Oven_IP);
            GetFileCount(T3_Oven137_IP);
            GetFileCount(T3_Oven102_IP);
            Schedule.Start();
        }

        private void GetFileCount(string Host)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(@"\\" + Host + @"\c$\TempProfileBackup");
                FileInfo[] files = di.GetFiles();
                int fileCount = files.Length;
                label1.Text += Host + " ： " + fileCount.ToString();
                label1.Text += "\n\n";
            }
            catch (Exception ex)
            {
                label1.Text += Host + " ： ";
                label1.Text += "\n\n";
            }

        }

        private void Schedule_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            label1.Text = "";
            Schedule.Stop();
            GetFileCount(T1_Oven_IP);
            GetFileCount(T5_Oven_IP);
            GetFileCount(T3_Oven137_IP);
            GetFileCount(T3_Oven102_IP);
            Schedule.Start();

        }
    }
}
