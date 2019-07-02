using System;
using System.Windows.Forms;
using Ex05.CheckersLogic;

namespace Ex05.WindowsUI
{
    public partial class ExitForm : Form
    {
        private readonly Game r_Game;

        public ExitForm(Game i_Game)
        {
            this.r_Game = i_Game;
            InitializeComponent();
            updateForm();
        }

        private void no_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void newRound_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void updateForm()
        {
            if (r_Game.CheckRetireOption() == eStatus.cannotQuit)
            {
                newRound.Visible = false;
            }
            else
            {
                newRound.Visible = true;
            }
        }
    }
}