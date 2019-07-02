using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public partial class ExitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelLeave = new System.Windows.Forms.Label();
            labelStay = new System.Windows.Forms.Label();
            newRound = new System.Windows.Forms.PictureBox();
            no = new System.Windows.Forms.PictureBox();
            yes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(newRound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(yes)).BeginInit();
            SuspendLayout();
            // 
            // labelLeave
            // 
            labelLeave.AutoSize = true;
            labelLeave.Font = new System.Drawing.Font("Aharoni", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelLeave.Location = new System.Drawing.Point(293, 117);
            labelLeave.Name = "labelLeave";
            labelLeave.Size = new System.Drawing.Size(90, 28);
            labelLeave.TabIndex = 4;
            labelLeave.Text = "Leave";
            // 
            // labelStay
            // 
            labelStay.AutoSize = true;
            labelStay.Font = new System.Drawing.Font("Aharoni", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelStay.Location = new System.Drawing.Point(41, 117);
            labelStay.Name = "labelStay";
            labelStay.Size = new System.Drawing.Size(71, 28);
            labelStay.TabIndex = 5;
            labelStay.Text = "Stay";
            // 
            // newRound
            // 
            newRound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            newRound.Image = Properties.Resources.NewRound;
            newRound.Location = new System.Drawing.Point(151, 21);
            newRound.Name = "newRound";
            newRound.Size = new System.Drawing.Size(113, 93);
            newRound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            newRound.TabIndex = 3;
            newRound.TabStop = false;
            newRound.Click += new System.EventHandler(newRound_Click);
            // 
            // no
            // 
            no.Image = Properties.Resources.No;
            no.Location = new System.Drawing.Point(286, 21);
            no.Name = "no";
            no.Size = new System.Drawing.Size(110, 93);
            no.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            no.TabIndex = 2;
            no.TabStop = false;
            no.Click += new System.EventHandler(no_Click);
            // 
            // yes
            // 
            yes.Image = Properties.Resources.Yes;
            yes.Location = new System.Drawing.Point(26, 21);
            yes.Name = "yes";
            yes.Size = new System.Drawing.Size(110, 93);
            yes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            yes.TabIndex = 0;
            yes.TabStop = false;
            yes.Click += new System.EventHandler(yes_Click);
            // 
            // ExitForm
            // 
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(421, 155);
            Controls.Add(labelStay);
            Controls.Add(labelLeave);
            Controls.Add(newRound);
            Controls.Add(no);
            Controls.Add(yes);
            Icon = Properties.Resources.Icon;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitForm";
            Text = "Damka";
            ((System.ComponentModel.ISupportInitialize)(newRound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(yes)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox yes;
        private PictureBox no;
        private PictureBox newRound;
        private Label labelLeave;
        private Label labelStay;
    }
}