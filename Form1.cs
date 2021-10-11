using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Console = LMSA.InControlConsole.Console;
namespace LMSA
{
    public partial class Form1 : Form
    {
        Paths PlatformPaths = new Paths();
        string RomPath;
        bool ValidRom;
        FlashReader GlobalReader;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Verify();
            label1.Text = string.Format("Device: {0}", "none");
        }
        void Verify()
        {
            for (int i = 0; i < PlatformPaths.Path.Count; i++)
            {
                if (!File.Exists(PlatformPaths.Path[i]))
                {
                    MessageBox.Show(this, string.Format("The native binary {0} is missing,\nthe program will not be able to run correctly,\nit will have any breaks and failures", PlatformPaths.Path[i].Replace("Resources/Google/", "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidRom)
            {
                FlashDevice FD = new FlashDevice(PlatformPaths.Path[3]);
                progressBar1.Maximum = GlobalReader.RomFiles.Count;
                for (int i = 0; i < GlobalReader.RomFiles.Count; i++)
                {
                    progressBar1.Value = i + 1;
                    label3.Text = string.Format("Flashing: {0}", GlobalReader.RomPartitions[i]);
                    Console.WriteLine("rel@fireflash", string.Format("flashing {0} partition...", GlobalReader.RomPartitions[i]), ref ConsoleTextBox);
                    FD.FlashImage(GlobalReader.RomPartitions[i], RomPath + "/" + GlobalReader.RomFiles[i]);
                    if(i == GlobalReader.RomFiles.Count - 1)
                    {
                        MessageBox.Show(this, "Flash Finished!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } else
            {
                MessageBox.Show(this, "Select a valid ROM", "Missing ROM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                if (!File.Exists(folderBrowserDialog1.SelectedPath + "/flashfile.xml"))
                {
                    ValidRom = false;
                    progressBar1.Value = 0;
                    MessageBox.Show(this, "Invalid ROM", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    RomPath = folderBrowserDialog1.SelectedPath;
                    ValidRom = true;
                    
                    OnSelectedRom();
                }
            }
        }
        void OnSelectedRom()
        {
            progressBar1.Value = 0;
            ConsoleTextBox.Text = "";
            label3.Text = "";
            FlashReader FR = new FlashReader(RomPath);
            Console.WriteLine("rel@lmsa", "rom loaded for: " + FR.DeviceName,ref ConsoleTextBox);
            label1.Text = string.Format("Device: {0}", FR.DeviceName);
            listView1.Items.Clear();
            for (int i = 0; i < FR.RomFiles.Count; i++)
            {
                listView1.Items.Add(FR.RomFiles[i]).SubItems.Add(FileUtils.GetFileSize(RomPath + "/" + FR.RomFiles[i]).ToString() + "MB");
            }
            Console.WriteLine("rel@lmsa", string.Format("{0} partitions loaded", FR.RomFiles.Count), ref ConsoleTextBox);
            GlobalReader = FR;
        }
    }
}
