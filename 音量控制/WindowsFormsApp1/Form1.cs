using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreAudioApi;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        //[DllImport("user32.dll")]
        //public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


        //public void SetVol()
        //{
        //    p = Process.GetCurrentProcess();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        SendMessageW(p.Handle, WM_APPCOMMAND, p.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
        //    }
        //}

        //private Process p;
        //private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        //private const int APPCOMMAND_VOLUME_UP = 0x0a0000;
        //private const int APPCOMMAND_VOLUME_DOWN = 0x090000;
        //private const int WM_APPCOMMAND = 0x319;

        public void SetVol(double arg)
        {
            device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)arg/100;
        }

        private MMDevice device;
        private MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SetVol();


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            SetVol(trackBar1.Value);
        }
    }
}
