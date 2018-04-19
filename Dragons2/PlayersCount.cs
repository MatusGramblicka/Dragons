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
            this.form1 = form1;
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
    }
}
