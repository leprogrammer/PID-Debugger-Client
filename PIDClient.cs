/**Created by Tejas Prasad
 * Summer 2012
 * Updated September 2016
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace PID_Debugger_Client
{
    public partial class PIDDashboard : Form
    {
        private string[,] pidArray;

        public PIDDashboard()
        {
            InitializeComponent();
            pidArray = new string[6, 3];
            for(int i = 0; i < 6; i++)
                for(int j = 0; j < 3; j++)
                    pidArray[i, j] = "0";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void establishconnection_Click(object sender, EventArgs e)
        {
            int connectionRequestCount = 0;
            bool connectionAccepted = false;
            establishconnection.Hide();
            string mystring = "";
            int count = 0;

            for (int rows = 0; rows < 5; rows++)
                for (int columns = 0; columns < 3; columns++){
                    if (count > 0)
                        mystring = string.Concat(mystring, ",");

                    mystring = string.Concat(mystring, pidArray[rows, columns]);
                    count++;
                }

            do
            {
                try
                {
                    int port = 11779;
                    TcpClient client = new TcpClient("127.0.0.1", port);
                    
                    // Translate the passed message into ASCII and store it as a Byte Array.
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    writer.Write(mystring);
                    writer.Flush();

                    networkMessages.Show();
                    networkMessages.Text = "Sent: " + mystring;
                    serverMessages.Show();

                    // Close everything.
                    writer.Close();
                    client.Close();
                    connectionAccepted = true;
                }
                catch (ArgumentNullException a)
                {
                    errorMessages.Show();
                    errorMessages.Text = "ArgumentNullException: " + a;
                    connectionRequestCount++;
                }
                catch (SocketException s)
                {
                    errorMessages.Show();
                    errorMessages.Text = "SocketException: " + s;
                    connectionRequestCount++;
                }

            } while (!connectionAccepted && connectionRequestCount < 5);
            establishconnection.Show();
        }

        private void inputdata_Click(object sender, EventArgs e)
        {
            Pinput1.Text = pidArray[0, 0];
            Iinput1.Text = pidArray[0, 1];
            Dinput1.Text = pidArray[0, 2];
            Pinput2.Text = pidArray[1, 0];
            Iinput2.Text = pidArray[1, 1];
            Dinput2.Text = pidArray[1, 2];
            Pinput3.Text = pidArray[2, 0];
            Iinput3.Text = pidArray[2, 1];
            Dinput3.Text = pidArray[2, 2];
            Pinput4.Text = pidArray[3, 0];
            Iinput4.Text = pidArray[3, 1];
            Dinput4.Text = pidArray[3, 2];
            Pinput4.Text = pidArray[4, 0];
            Iinput4.Text = pidArray[4, 1];
            Dinput4.Text = pidArray[4, 2];
            Pinput5.Text = pidArray[5, 0];
            Iinput5.Text = pidArray[5, 1];
            Dinput5.Text = pidArray[5, 2];
            clientMessages.Show();
            clientMessages.Text = "Input Values Changed";
        }

        private void changeChannel_ValueChanged(object sender, EventArgs e)
        {
            Pvalue1.Clear();
            Ivalue1.Clear();
            Dvalue1.Clear();
        }

        private void setArray_Click(object sender, EventArgs e)
        {
            int pidArrayValue = (int)changeChannel.Value - 1;
            pidArray[pidArrayValue, 0] = (Pvalue1.Text == "") ? "0" : Pvalue1.Text;
            pidArray[pidArrayValue, 1] = (Ivalue1.Text == "") ? "0" : Ivalue1.Text;
            pidArray[pidArrayValue, 2] = (Dvalue1.Text == "") ? "0" : Dvalue1.Text;
            switch (pidArrayValue)
            {
                case 0:
                    Pinput1.Text = pidArray[0, 0];
                    Iinput1.Text = pidArray[0, 1];
                    Dinput1.Text = pidArray[0, 2];
                    break;
                case 1:
                    Pinput2.Text = pidArray[1, 0];
                    Iinput2.Text = pidArray[1, 1];
                    Dinput2.Text = pidArray[1, 2];
                    break;
                case 2:
                    Pinput3.Text = pidArray[2, 0];
                    Iinput3.Text = pidArray[2, 1];
                    Dinput3.Text = pidArray[2, 2];
                    break;
                case 3:
                    Pinput4.Text = pidArray[3, 0];
                    Iinput4.Text = pidArray[3, 1];
                    Dinput4.Text = pidArray[3, 2];
                    break;
                case 4:
                    Pinput4.Text = pidArray[4, 0];
                    Iinput4.Text = pidArray[4, 1];
                    Dinput4.Text = pidArray[4, 2];
                    break;
                case 5:
                    Pinput5.Text = pidArray[5, 0];
                    Iinput5.Text = pidArray[5, 1];
                    Dinput5.Text = pidArray[5, 2];
                    break;
                default:
                    break;
            }
            clientMessages.Show();
            clientMessages.Text = "Value set for channel " + (changeChannel.Value);
        }

        private void clearMessages_Click(object sender, EventArgs e)
        {
            serverMessages.Hide();
            networkMessages.Hide();
            clientMessages.Hide();
            errorMessages.Hide();
            errorMessages.Text = "Messages";
            clientMessages.Text = "Messages";
            serverMessages.Text = "Messages";
            networkMessages.Text = "Messages";
        }
    }
}