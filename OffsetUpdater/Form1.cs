using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OffsetUpdater
{
    public partial class Form1 : Form
    {
        //Config Directory
        public string confPath = Path.Combine(Environment.CurrentDirectory ,"offs.conf");
        public string tempPath = Path.Combine(Path.GetTempPath(), "offs.conf");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getFileInfo();
        }

        // get config file last modified date
        private void getFileInfo()
        {
            if (File.Exists(confPath))
            {
                DateTime modification = File.GetLastWriteTime(confPath);
                lbl_modDate.Text = modification.Date.ToString("MM/dd/yyyy");
            }
            else
            {
                MessageBox.Show("Config file not found , Press enter to create new config");
                if (!File.Exists(tempPath))
                {
                    File.Create(tempPath);
                }
                File.Create(confPath);
                Application.Restart();
            }
        }

        // Write the offsets to our config file.
        private void writeOffsets(string rawOffsets)
        {
            string[] temp = rawOffsets.Split();
            string offset = "";
            for (int i = 0; i < temp.Length; i++)
            {
                offset = offset + " " + temp[i];
            }
            temp = null;
            File.WriteAllText(confPath, offset);
            File.WriteAllText(tempPath, offset);
            lbl_stats.Text = "Done.";
            getFileInfo();
        }


        string offsetsURL = "https://raw.githubusercontent.com/newwide/Dota2-Overlay-OffsetUpdater/master/latest_offsets.txt";

        //Start updating offset from dataserver.
        private void button1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(offsetsURL);
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            Debug.WriteLine(content);
            writeOffsets(content);
        }

    }
}
