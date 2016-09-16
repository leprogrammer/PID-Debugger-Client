using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using PID_Debugger_Client;
using System.Windows;


namespace Tcp_Client
{
    class MyTcpClient
    {
        public static void test()
        {
            
        }
        public void Window1()
        {
            InitializeComponent();

            TextBlock tb = new TextBlock();
            tb.Text = "test";

            tb.MouseEnter += new MouseEventHandler(tb_MouseEnter);
            tb.MouseLeave += new MouseEventHandler(tb_MouseLeave);

            MainStackPanel.Children.Add(tb); 
        }

        void tb_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Background = new SolidColorBrush(Colors.Transparent);
            tb.Text = "test";
        }

        void tb_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            tb.Background = new SolidColorBrush(Colors.Orange);
            tb.Text += " - this should be in a popup bubble.";
        }
    }
}