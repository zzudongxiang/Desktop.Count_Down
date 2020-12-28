using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CountDown_Control_
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string ipv4 = "127.0.0.1";

        bool connected = false;

        Socket socket;

        private void TCPClient()
        {
            byte[] data = new byte[1024];
            string stringData;
            IPAddress ip = IPAddress.Parse(ipv4);
            IPEndPoint ipEnd = new IPEndPoint(ip, 18459);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int recv = 0;
            try
            {
                socket.Connect(ipEnd);
                recv = socket.Receive(data);
            }
            catch (SocketException Ex)
            {
                MessageBox.Show(Ex.Message, "Fail to connect server");
                connected = true;
                button1.Invoke(new MethodInvoker(delegate { button1_Click(null, null); }));
                return;
            }

            stringData = Encoding.ASCII.GetString(data, 0, recv);
            label3.Invoke(new MethodInvoker(delegate { label3.Text = stringData; }));
            while (true)
            {
                if (!connected)
                {
                    break;
                }
                data = new byte[1024];
                try { recv = socket.Receive(data); }
                catch { break; }
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                label3.Invoke(new MethodInvoker(delegate { label3.Text = stringData; }));
            }
            label3.Invoke(new MethodInvoker(delegate { label3.Text = "disconnect from server"; }));
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                connected = true;
                button1.Invoke(new MethodInvoker(delegate { button1_Click(null, null); }));
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (connected)
            {
                textBox1.Enabled = true;
                connected = false;
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch { }
                button1.Text = "连接";
            }
            else
            {
                connected = true;
                textBox1.Enabled = false;
                button1.Text = "断开";
                Thread thread = new Thread(TCPClient);
                thread.Start();
            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            if (label3.Text.Replace("\r", "").Replace("\n", "").Length != 5) 
                textBox5.AppendText(label3.Text.Replace("\r\n","") + "\r\n");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ipv4 = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Run");
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Stop");
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("ShowWarning:" + checkBox1.Checked);
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("ShowStop:" + checkBox2.Checked);
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("TotalTime:" + textBox3.Text);
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("FontSize:" + textBox4.Text);
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void label8_BackColorChanged(object sender, EventArgs e)
        {
            try
            {
                if (connected)
                {
                    byte[] data = Encoding.ASCII.GetBytes("FontColor:" + label8.BackColor.R + "," + label8.BackColor.G + "," + label8.BackColor.B);
                    socket.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                label8.BackColor = dialog.Color;
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
