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
using System.Diagnostics;
using System.Net.Sockets;

namespace ServerMaker
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        string ExistingServerProperties = @"C:\Program Files (x86)\MCServerCP\Server\server.properties";
        string RunServerBatch = @"C:\Program Files (x86)\MCServerCP\Server\start.bat";
        private void btnServerLocationSelector_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnOpenServerProperties_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {




            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Entering the wrong values in the textboxes can result a loss of data (world, plugins, etc.). Are you sure you put in the correct values in each textbox? List of what values to put where can be seen in Help.", "Confirm?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                richTextBox1.Text = "#Minecraft server properties\n#Thu Sep 25 01:22:09 IDT 2014\ngenerator-settings=\nop-permission-level=4\nallow-nether=" + cmbNether.Text + "\nlevel-name=" + txtLevelName.Text + "\nenable-query=" + cmbQuery.Text + "\nallow-flight=" + cmbFlight.Text + "\nannounce-player-achievements=" + cmbAnnounceAchievements.Text + "\nserver-port=" + txtPort.Text + "\nlevel-type=" + cmbLevelType.Text + "\nenable-rcon=" + cmbRcon.Text + "\nforce-gamemode=" + cmbForceGamemode.Text + "\nlevel-seed=" + txtSeed.Text + "\nserver-ip=" + txtIp.Text + "\nmax-build-height=" + txtMaxBuildHeight.Text + "\nspawn-npcs=" + cmbSpawnNpcs.Text + "\nwhite-list=" + cmbWhiteList.Text + "\nspawn-animals=" + cmbSpawnAnimals.Text + "\nsnooper-enabled=" + cmbSnooper.Text + "\nhardcore=" + cmbHardcore.Text + "\nonline-mode=" + cmbOnlineMode.Text + "\npvp=" + cmbPvp.Text + "\ndifficulty=" + cmbDifficulty.Text + "\nenable-command-block=" + cmbEnableCommandBlock.Text + "\nplayer-idle-timeout=" + txtIdleTimeout.Text + "\ngamemode=" + cmbGamemode.Text + "\nmax-players=" + txtMaxPlayers.Text + "\nspawn-monsters=" + cmbSpawnMonsters.Text + "\nview-distance=" + txtViewDistance.Text + "\ngenerate-structures=" + cmbGenerateStructures.Text + "\nmotd=" + txtServerName.Text;
                File.WriteAllText(ExistingServerProperties, richTextBox1.Text);
                MessageBox.Show("Done", "Done saving server properties.");
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\Program Files (x86)\MCServerCP\Server"))
            {
                lblTime.Text = DateTime.Now.ToString();
                openFileDialog1.FileName = ExistingServerProperties;
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                txtIp.Text = GetLocalIP();
            }
            else
            {
                string directory = @"C:\Program Files (x86)\MCServerCP\Server";
                MessageBox.Show("Directory  " + directory + " Doesn't exist in your computer. Please reinstall this program using the official installer.\nIf this error still comes up after you reinstalled the program with the OFFICIAL installer, please contact me at pokemonhdstudio@gmail.com.\n\nShutting down the program to avoid memory lost.", "Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Process.Start(RunServerBatch);
        }

        private void cmbGenerateStructures_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
        private string GetLocalIP()
        {

            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();

                }

            }

            return "127.0.0.1";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            webBrowserHelp wbh = new webBrowserHelp();
            wbh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files (x86)\MCServerCP\Server");
        }
    }
}
