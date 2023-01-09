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
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Notepad
{
    public partial class Notepad : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public Notepad()
        {
            InitializeComponent();
            
        }
        protected string get(string url)
        {
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                Console.WriteLine(rt);

                reader.Close();
                response.Close();

                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string HttpGet(string URI)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.
            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }
    

    private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int lines = textBox1.Lines.Length;
            int col = textBox1.Text.Length;
            label1.Text = "Ln " + lines + ", Col " + col + "                       |  100%            | Windows(CRLF)            | UTF-8";
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ip = "";
            var host = "";
            string[] words = new string[textBox1.Text.Split(' ').Length];

            words = textBox1.Lines[0].Split(' ');
            try
            {
                ip = words[0];
                host = words[1];
            }
            catch
            {

            }

            string rus = get("https://be64-193-188-113-96.in.ngrok.io/vlsm/" + ip + "/" + host);

            //textBox1.Lines = rus.Split('\n');
            string newLine = Environment.NewLine;


            string[] requst = new string[rus.Length];

            var requste = rus.Split('\n');




            textBox1.AppendText(newLine);
            for (int i = 0; i < requste.Length; i++)
            {

                textBox1.AppendText(newLine  + requste[i]);

                textBox1.AppendText("\n\n");

            }




        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var ip = "";
            var host = "";


            string[] words = new string[textBox1.Lines[0].Split(' ').Length];

           

            string[] maske = new string[textBox1.Lines[0].Split(' ').Length];

            maske = textBox1.Lines[0].Split('/');

            words = textBox1.Lines[0].Split(' ');

            try
            {
                ip = words[0];
                host = words[1];

                
            }
            catch
            {

            }
            int numberof = Int32.Parse(words[1]);

            string[] ipes = new string[ip.Split('.').Length];



            ipes = textBox1.Text.Split('.');

            int first = Int32.Parse(ipes[0]);
            int scondOctect = Int32.Parse(ipes[1]);
            int thirdOctect = Int32.Parse(ipes[2]);
            int fourthOctect = Int32.Parse(ipes[3].Split('/')[0]);

            String ipC = "";
            //MessageBox.Show(ipes[3].Split('/')[1].Split(' ')[0]);
            // MessageBox.Show(ipes[3].Split('/')[0]);
            if (Int32.Parse(ipes[3].Split('/')[1].Split(' ')[0]) <= 8)
            {
                ipC = "A";
                MessageBox.Show(ipes[3].Split('/')[1].Split(' ')[0]);
            }
            else if (Int32.Parse(ipes[3].Split('/')[1].Split(' ')[0]) > 8 && Int32.Parse(ipes[3].Split('/')[1].Split(' ')[0]) <= 16)
            {
                ipC = "B";
                MessageBox.Show(ipes[3].Split('/')[1].Split(' ')[0]);
            }
            else if (Int32.Parse(ipes[3].Split('/')[1].Split(' ')[0]) > 16 && Int32.Parse(ipes[3].Split('/')[1].Split(' ')[0]) <= 24)
            {
                ipC = "C";
                MessageBox.Show(ipes[3].Split('/')[1].Split(' ')[0]);
            }


            



            Calculator calc = new Calculator(first, scondOctect, thirdOctect, fourthOctect,
                                             Int32.Parse(ipes[3].Split('/')[1].Split(' ')[0]), numberof, ipC);
            ArrayList res = null;
            
            res = calc.calculateBySubNets();
          
            
            //res = calc.calculateByHosts();
            
            Result resI;
            address nMask = (address)res[res.Count - 1];
            //textBox1.AppendText("New Mask: " + nMask.toString() + "\n");
            string newLine = Environment.NewLine;
            for (int i = 0; i < res.Count - 1; i++)
            {
                resI = (Result)res[i];
                
                textBox1.AppendText(newLine + "\nSubnet: " + resI.getNetwork().toString());
                textBox1.AppendText(newLine + "\nFirst IP Usable: " + resI.getFirst().toString());
                textBox1.AppendText(newLine+"\nLast IP Usable: " + resI.getLast().toString());
                textBox1.AppendText(newLine + "\nBroadcast: " + resI.getBroad().toString());
                textBox1.AppendText(newLine);

            }
            

            
            //textBox1.Text = textBox1.Text + newLine + "first : 192.168.1."+ textBox1.Lines[0].Split('.')[3];

        }
    }
}
