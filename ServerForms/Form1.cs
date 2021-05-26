using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ServerForms
{
    public partial class Form1 : Form
    {
        TcpClient   klient;
        int         port = 12345;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(tbxIPAdress.Text);
            klient = new TcpClient();
            klient.NoDelay = true;
            klient.Connect(address, port);

            if (klient.Connected)
            {
                byte[] utData = Encoding.Unicode.GetBytes(rtbMessage.Text);
                klient.GetStream().Write(utData, 0, utData.Length);
                klient.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
