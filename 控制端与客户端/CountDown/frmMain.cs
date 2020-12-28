using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CountDown
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            iPV4ToolStripMenuItem.Text = "IPV4:" + Common.GetClientLocalIPv4Address();
            Thread thread = new Thread(TCPServer);
            thread.Start();
        }

        #region 窗体移动及大小改变

        Point currentPosition = new Point(0, 0);

        bool isDown = false;

        private void lbCountDown_Resize(object sender, EventArgs e)
        {
            Size = lbCountDown.Size;
        }

        private void lbCountDown_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            currentPosition = MousePosition;
        }

        private void lbCountDown_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                Left += MousePosition.X - currentPosition.X;
                Top += MousePosition.Y - currentPosition.Y;
                currentPosition = MousePosition;
            }
        }

        private void lbCountDown_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }

        #endregion

        #region 计时操作

        DateTime EndTime = new DateTime();

        TimeSpan TotalCount = new TimeSpan(0, 3, 0);

        bool Ready = false;

        bool ShowWarning = true;

        bool ShowStop = true;

        SoundPlayer WarningSound = new SoundPlayer(Properties.Resources.WarningSound);

        SoundPlayer StopSound = new SoundPlayer(Properties.Resources.StopSound);  

        private void TimerRefresh_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = EndTime - DateTime.Now;
            if (ts.TotalSeconds < 0)
            {
                TimerRefresh.Enabled = false;
                ts = new TimeSpan(0, 0, 0);
                if(ShowStop) StopSound.Play();
            }
            else if (Ready && ts.TotalSeconds <= 31)
            {
                if (ShowWarning) WarningSound.Play();
                Ready = false;
            }
            lbCountDown.Text = ts.Minutes.ToString("00:") + ts.Seconds.ToString("00");
        }

        #endregion

        #region 用户操作

        private void 开始计时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!TimerRefresh.Enabled)
            {
                EndTime = DateTime.Now.Add(TotalCount);
                TimerRefresh.Enabled = true;
                Ready = true;
            }
        }

        private void 停止计时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerRefresh.Enabled = false;
            lbCountDown.Text = TotalCount.Minutes.ToString("00:") + TotalCount.Seconds.ToString("00");
        }

        private void SetTotalTime(TimeSpan sp)
        {
            TotalCount = sp;
        }

        private void SetShowWarning(bool Show)
        {
            ShowWarning = Show;
        }

        private void SetShowStop(bool Show)
        {
            ShowStop = Show;
        }

        #endregion

        #region TCP连接

        //客户端连接对象
        Socket client;

        List<string> CMD = new List<string> { };

        private void TCPServer()
        {
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 18459);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEnd);
            socket.Listen(10);
            lbCountDown.Invoke(new MethodInvoker(delegate { lbCountDown.Text = "Waiting for a client..."; }));
            client = socket.Accept();
            IPEndPoint ipEndClient = (IPEndPoint)client.RemoteEndPoint;
            lbCountDown.Invoke(new MethodInvoker(delegate { lbCountDown.Text = "Connect with " + ipEndClient.Address + " at port " + ipEndClient.Port; }));
            while (true)
            {
                data = new byte[1024];
                try { recv = client.Receive(data); }
                catch { break; }
                if (recv == 0)
                    break;
                CMD.Add(Encoding.ASCII.GetString(data, 0, recv));
            }
            lbCountDown.Invoke(new MethodInvoker(delegate { lbCountDown.Text = "Disconnect form ipEndClient.Address"; }));
            try
            {
                client.Close();
                socket.Close();
            }
            catch { }
            Thread thread = new Thread(TCPServer);
            thread.Start();
        }

        #endregion

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TimerSys_Tick(object sender, EventArgs e)
        {
            TopMost = true;
            if (CMD.Count > 0)
            {
                string TMP = CMD[0];
                string[] Command = TMP.Split(':');
                CMD.RemoveAt(0);
                try
                {
                    switch (Command[0].ToUpper())
                    {
                        case "RUN":
                            开始计时ToolStripMenuItem_Click(null, null);
                            break;
                        case "STOP":
                            停止计时ToolStripMenuItem_Click(null, null);
                            break;
                        case "TOTALTIME":
                            TotalCount = new TimeSpan(0, 0, Convert.ToInt32(Command[1]));
                            break;
                        case "SHOWWARNING":
                            ShowWarning = Convert.ToBoolean(Command[1]);
                            break;
                        case "SHOWSTOP":
                            ShowStop = Convert.ToBoolean(Command[1]);
                            break;
                        case "FONTSIZE":
                            lbCountDown.Font = new Font(lbCountDown.Font.FontFamily, Convert.ToInt16(Command[1]), FontStyle.Regular);
                            break;
                        case "FONTCOLOR":
                            string[] C = Command[1].Split(',');
                            int R = Convert.ToInt16(C[0]);
                            int G = Convert.ToInt16(C[1]);
                            int B = Convert.ToInt16(C[2]);
                            lbCountDown.ForeColor = Color.FromArgb(R, G, B);
                            if (R < 2) R += 1;
                            else R -= 1;
                            TransparencyKey = Color.FromArgb(R, G, B);
                            BackColor = Color.FromArgb(R, G, B);
                            break;
                    }
                    byte[] data = Encoding.ASCII.GetBytes(TMP + "\r\n");
                    client.Send(data, data.Length, SocketFlags.None);
                }
                catch (Exception Ex)
                {
                    lbCountDown.Text = Ex.Message;
                }
                
            }

        }

        private void lbCountDown_TextChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(lbCountDown.Text + "\r\n");
                client.Send(data, data.Length, SocketFlags.None);
            }
            catch { }
        }
    }
}
