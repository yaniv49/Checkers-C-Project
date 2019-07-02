using System;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        public string player1Name
        {
            get { return player1NameTextBox.Text; }
        }

        public string player2Name
        {
            get { return player1NameTextBox.Text; }
        }

        public bool player2CheckBoxCheck
        {
            get { return player2CheckBox.Checked; }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(player1NameTextBox.Text) || (player2CheckBox.Checked && string.IsNullOrEmpty(player2NameTextBox.Text)))
            {
                MessageBox.Show(Messages.s_NameEmpty, "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (player2CheckBox.Checked)
            {
                player2NameTextBox.ReadOnly = false;
                player2NameTextBox.ResetText();
            }
            else
            {
                player2NameTextBox.ReadOnly = true;
                player2NameTextBox.Text = "[Computer]";
            }
        }

        public int GetSize()
        {
            int size;
            if (sizeButton6x6.Checked)
            {
                size = 6;
            }
            else if (sizeButton8x8.Checked)
            {
                size = 8;
            }
            else
            {
                size = 10;
            }

            return size;
        }
    }
}