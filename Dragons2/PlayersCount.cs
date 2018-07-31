using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dragons2
{
    public partial class PlayersCount : Form
    {
        public Form1 form1;

        public PlayersCount(Form1 form1)
        {
            InitializeComponent();

            UnvisibleComponents();

            groupBox1.Visible = false;
            button1.Visible = false;
            btnHost.Visible = false;
            btnJoin.Visible = false;

            this.form1 = form1;

            ClientSize = new Size(217, 201);
        }

        private void PlayersCount_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int playersCount = 0;

            if (radioButton1.Checked || radioButton2.Checked)
                playersCount = 2;
            if (radioButton3.Checked)
                playersCount = 3;
            if (radioButton4.Checked)
                playersCount = 4;
            if (radioButton5.Checked)
                playersCount = 5;

            form1.NumberOfPlayers = playersCount;

            form1.UpgradeNumberOfPlayersLabel(playersCount);

            Close();
        }

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            ClientSize = new Size(300, 300);

            btnSinglePlayer.Visible = false;
            btnMultiplayer.Visible = false;
            btnHost.Visible = true;
            btnJoin.Visible = true;
        }

        private void VisibleComponents()
        {
            btnMultiplayer.Visible = false;
            label1.Visible = true;
            txtName.Visible = true;
            txtClientConsole.Visible = true;
            txtMessage.Visible = true;
            txtServerConsole.Visible = true;
            dataGridView1.Visible = true;

            btnSinglePlayer.Visible = false;
        }

        private void UnvisibleComponents()
        {
            label1.Visible = false;
            txtName.Visible = false;
            txtClientConsole.Visible = false;
            txtMessage.Visible = false;
            btnSendMessages.Visible = false;
            btnConncetUser.Visible = false;
            txtServerConsole.Visible = false;
            dataGridView1.Visible = false;
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            ClientSize = new Size(300, 300);

            groupBox1.Visible = true;
            button1.Visible = true;
            btnSinglePlayer.Visible = false;
            btnMultiplayer.Visible = false;
            btnHost.Visible = false;
            btnJoin.Visible = false;
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            ClientSize = new Size(533, 534);

            groupBox1.Visible = false;
            button1.Visible = false;
            btnHost.Visible = false;
            btnJoin.Visible = false;

            VisibleComponents();

            //serverSocket.Start();
            //txtServerConsole.Text = "Chat Server Started ....";

            //backgroundWorker1.RunWorkerAsync(true);
        }
    }
}
