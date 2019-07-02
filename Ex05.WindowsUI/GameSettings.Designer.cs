using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public partial class GameSettings : Form
    {
        private Label boardSizeLabel;
        private Label player1Label;
        private Label player2Label;
        private Label playersLabel;
        private Button doneButton;
        private RadioButton sizeButton6x6;
        private RadioButton sizeButton8x8;
        private RadioButton sizeButton10x10;
        private TextBox player1NameTextBox;
        private TextBox player2NameTextBox;
        private CheckBox player2CheckBox;

        private void InitializeComponent()
        {
            sizeButton6x6 = new System.Windows.Forms.RadioButton();
            sizeButton8x8 = new System.Windows.Forms.RadioButton();
            sizeButton10x10 = new System.Windows.Forms.RadioButton();
            player1NameTextBox = new System.Windows.Forms.TextBox();
            player2NameTextBox = new System.Windows.Forms.TextBox();
            boardSizeLabel = new System.Windows.Forms.Label();
            player1Label = new System.Windows.Forms.Label();
            player2Label = new System.Windows.Forms.Label();
            player2CheckBox = new System.Windows.Forms.CheckBox();
            doneButton = new System.Windows.Forms.Button();
            playersLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            //// 
            //// sizeButton6x6
            //// 
            sizeButton6x6.AutoSize = true;
            sizeButton6x6.Location = new System.Drawing.Point(43, 60);
            sizeButton6x6.Name = "sizeButton6x6";
            sizeButton6x6.Size = new System.Drawing.Size(51, 21);
            sizeButton6x6.TabIndex = 0;
            sizeButton6x6.TabStop = true;
            sizeButton6x6.Text = "6x6";
            sizeButton6x6.UseVisualStyleBackColor = true;
            //// 
            //// sizeButton8x8
            //// 
            sizeButton8x8.AutoSize = true;
            sizeButton8x8.Location = new System.Drawing.Point(113, 60);
            sizeButton8x8.Name = "sizeButton8x8";
            sizeButton8x8.Size = new System.Drawing.Size(51, 21);
            sizeButton8x8.TabIndex = 1;
            sizeButton8x8.TabStop = true;
            sizeButton8x8.Text = "8x8";
            sizeButton8x8.UseVisualStyleBackColor = true;
            //// 
            //// sizeButton10x10
            //// 
            sizeButton10x10.AutoSize = true;
            sizeButton10x10.Location = new System.Drawing.Point(178, 60);
            sizeButton10x10.Name = "sizeButton10x10";
            sizeButton10x10.Size = new System.Drawing.Size(67, 21);
            sizeButton10x10.TabIndex = 2;
            sizeButton10x10.TabStop = true;
            sizeButton10x10.Text = "10x10";
            sizeButton10x10.UseVisualStyleBackColor = true;
            //// 
            //// player1NameTextBox
            //// 
            player1NameTextBox.Location = new System.Drawing.Point(133, 133);
            player1NameTextBox.Name = "player1NameTextBox";
            player1NameTextBox.Size = new System.Drawing.Size(120, 22);
            player1NameTextBox.TabIndex = 3;
            //// 
            //// player2NameTextBox
            //// 
            player2NameTextBox.Location = new System.Drawing.Point(133, 172);
            player2NameTextBox.Name = "player2NameTextBox";
            player2NameTextBox.ReadOnly = true;
            player2NameTextBox.Size = new System.Drawing.Size(119, 22);
            player2NameTextBox.TabIndex = 4;
            player2NameTextBox.Text = "[Computer]";
            //// 
            //// boardSizeLabel
            //// 
            boardSizeLabel.AutoSize = true;
            boardSizeLabel.Location = new System.Drawing.Point(23, 28);
            boardSizeLabel.Name = "boardSizeLabel";
            boardSizeLabel.Size = new System.Drawing.Size(81, 17);
            boardSizeLabel.TabIndex = 5;
            boardSizeLabel.Text = "Board Size:";
            //// 
            //// player1Label
            //// 
            player1Label.AutoSize = true;
            player1Label.Location = new System.Drawing.Point(63, 136);
            player1Label.Name = "player1Label";
            player1Label.Size = new System.Drawing.Size(64, 17);
            player1Label.TabIndex = 6;
            player1Label.Text = "player 1:";
            //// 
            //// player2Label
            //// 
            player2Label.AutoSize = true;
            player2Label.Location = new System.Drawing.Point(64, 173);
            player2Label.Name = "player2Label";
            player2Label.Size = new System.Drawing.Size(64, 17);
            player2Label.TabIndex = 7;
            player2Label.Text = "player 2:";
            //// 
            //// player2CheckBox
            //// 
            player2CheckBox.AutoSize = true;
            player2CheckBox.Location = new System.Drawing.Point(43, 172);
            player2CheckBox.Name = "player2CheckBox";
            player2CheckBox.Size = new System.Drawing.Size(18, 17);
            player2CheckBox.TabIndex = 8;
            player2CheckBox.UseVisualStyleBackColor = true;
            player2CheckBox.CheckedChanged += new System.EventHandler(player2CheckBox_CheckedChanged);
            //// 
            //// doneButton
            //// 
            doneButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            doneButton.Location = new System.Drawing.Point(178, 213);
            doneButton.Name = "doneButton";
            doneButton.Size = new System.Drawing.Size(75, 23);
            doneButton.TabIndex = 9;
            doneButton.Text = "Done";
            doneButton.UseVisualStyleBackColor = true;
            doneButton.Click += new System.EventHandler(doneButton_Click);
            //// 
            //// playersLabel
            //// 
            playersLabel.AutoSize = true;
            playersLabel.Location = new System.Drawing.Point(23, 100);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new System.Drawing.Size(59, 17);
            playersLabel.TabIndex = 10;
            playersLabel.Text = "players:";
            //// 
            //// GameSettings
            //// 
            ClientSize = new System.Drawing.Size(282, 253);
            Controls.Add(playersLabel);
            Controls.Add(doneButton);
            Controls.Add(player2CheckBox);
            Controls.Add(player2Label);
            Controls.Add(player1Label);
            Controls.Add(boardSizeLabel);
            Controls.Add(player2NameTextBox);
            Controls.Add(player1NameTextBox);
            Controls.Add(sizeButton10x10);
            Controls.Add(sizeButton8x8);
            Controls.Add(sizeButton6x6);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Icon = Properties.Resources.Icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GameSettings";
            Text = "Game Setting";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}