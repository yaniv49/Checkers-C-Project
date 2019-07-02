using System;
using System.Windows.Forms;
using System.Drawing;
using Ex05.CheckersLogic;

namespace Ex05.WindowsUI
{
    public class GameForm : Form
    {
        private readonly Game r_Game;
        private GameSettings m_FormSettings;
        private ExitForm m_ExitForm;
        private Label labelPlayer1;
        private Label labelPlayer2;
        private Button fromButton;
        private eStatus m_Status;
        private Step m_Step;
        private CheckersLogic.Point m_From;
        private CheckersLogic.Point m_To;
        private bool m_ComputerMode;
        private bool m_IsFromButtonClicked;
        private string player1Name;
        private string player2Name;
        private string m_WinMessege;
        private int m_BoardSize;
        private int player1Location;
        private int player2Location;

        public GameForm()
        {
            Load += GameForm_Load;
            FormClosing += GameForm_FormClosing;
            r_Game = new Game();
            m_FormSettings = new GameSettings();
            m_ComputerMode = false;
            player1Name = string.Empty; 
            player2Name = string.Empty;
            labelPlayer1 = new Label();
            labelPlayer2 = new Label();
            fromButton = null;
            m_Step = null;
            m_BoardSize = 0;
            m_IsFromButtonClicked = false;
        }

        private void GameForm_Load(object sender, EventArgs e)                 
        {
            if (m_FormSettings.ShowDialog() == DialogResult.OK)
            {
                m_BoardSize = m_FormSettings.GetSize();
                player1Name = m_FormSettings.player1Name;
                player2Name = m_FormSettings.player2Name;
                m_ComputerMode = !m_FormSettings.player2CheckBoxCheck; 
            }
            else                                                           
            {
                m_BoardSize = 6;
                player1Name = "Player 1";
                player2Name = "[Computer]";
                m_ComputerMode = true;
            }

            r_Game.InitGame(m_BoardSize, player1Name, player2Name, m_ComputerMode);
            r_Game.ResetGame();            
            InitializeComponent();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!r_Game.GameOver)
            {
                m_ExitForm = new ExitForm(r_Game);
                switch (m_ExitForm.ShowDialog())
                {
                    case DialogResult.Yes:                      
                        e.Cancel = true;
                        break;
                    case DialogResult.No:                      
                        break;
                    case DialogResult.OK:
                        e.Cancel = true;
                        r_Game.ResetGame();
                        break;
                    default:                               
                        e.Cancel = true;                    
                        break;                              
                }
            }
        }

        private void InitializeComponent()
        {
            ////
            //// GameForm
            ////
            Icon = Properties.Resources.Icon;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            getLocationsAndSizes();
            CenterToScreen();
            Size = new Size(Width, Height);
            Text = "Damka";
            ////
            //// labelPlayer1
            ////
            labelPlayer1.Location = new System.Drawing.Point(player1Location, 15);
            labelPlayer1.Size = new Size(100, 20);
            labelPlayer1.Text = string.Format(@"{0} : {1}", player1Name, r_Game.Player1.CalcScore() - r_Game.Player2.CalcScore());
            labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Bold);
            Controls.Add(labelPlayer1);
            ////
            //// labelPlayer2
            ////
            labelPlayer2.Location = new System.Drawing.Point(player2Location, 15);
            labelPlayer2.Size = new Size(100, 20);
            labelPlayer2.Text = string.Format(@"{0} : {1}", player2Name, r_Game.Player2.CalcScore() - r_Game.Player1.CalcScore());
            labelPlayer2.ForeColor = Color.Red;                                                     
            Controls.Add(labelPlayer2);

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    Box box = r_Game.Board.board[i, j];
                    ListenerButton specialButton = new ListenerButton(box);
                    specialButton.Click += new System.EventHandler(button_Click);
                    Controls.Add(specialButton);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!r_Game.GameOver)
            {
                ListenerButton buttonClicked = sender as ListenerButton;
                buttonClicked.Click -= new System.EventHandler(button_Click);
                buttonClicked.Click += new System.EventHandler(button_SecondClick);
                if (!m_IsFromButtonClicked)
                {
                    buttonClicked.BackColor = Color.LightBlue;
                    m_From = buttonClicked.Position;
                    fromButton = buttonClicked;
                    m_IsFromButtonClicked = true;
                }
                else
                {
                    m_To = buttonClicked.Position;
                    m_Step = new Step(m_From, m_To);
                    m_IsFromButtonClicked = false;
                    buttonClicked.PerformClick();
                    fromButton.PerformClick();

                    m_Status = r_Game.TakeAction(m_Step);
                    checkStatus();
                    checkValidSteps();
                }
            }
            else
            {
                checkValidSteps();
            }
        }

        private void button_SecondClick(object sender, EventArgs e)
        {
            ListenerButton buttonClicked = sender as ListenerButton;
            m_IsFromButtonClicked = false;
            buttonClicked.BackColor = Color.Empty;
            buttonClicked.Click -= new System.EventHandler(button_SecondClick);
            buttonClicked.Click += new System.EventHandler(button_Click);
        }

        private void checkValidSteps()
        {
            if (r_Game.CurrentPlayer.ValidSteps())
            {
                if (r_Game.ComputerTurn())
                {
                    m_Status = r_Game.TakeAction(m_Step);
                    checkStatus();
                    checkValidSteps();
                }
            }
            else if (r_Game.CurrentPlayer.Opponent.ValidSteps())
            {
                r_Game.GameOver = true;
                updateScores();
                showScores();
                showWinMessege();
            }
            else
            {
                showTieMessege();
            }
        }

        private void checkStatus()
        {
            if (m_Status == eStatus.wrongInput)
            {
                MessageBox.Show(Messages.s_WrongStep, "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (m_Status == eStatus.endTurn)
            {
                r_Game.CurrentPlayer = r_Game.CurrentPlayer.Opponent;

                if (r_Game.CurrentPlayer == r_Game.Player1)
                {
                    labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Bold);
                    labelPlayer2.Font = new Font(labelPlayer1.Font, FontStyle.Regular);
                }
                else
                {
                    labelPlayer1.Font = new Font(labelPlayer1.Font, FontStyle.Regular);
                    labelPlayer2.Font = new Font(labelPlayer1.Font, FontStyle.Bold);
                }
            }
        }

        private void updateScores()
        {
            r_Game.CurrentPlayer.Opponent.Score += r_Game.CurrentPlayer.Opponent.CalcScore() - r_Game.CurrentPlayer.CalcScore();
        }

        private void showTieMessege()
        {
            switch (MessageBox.Show(Messages.s_Tie, "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    r_Game.ResetGame();
                    break;
                default:
                    Close();
                    break;
            }
        }

        // $G$ CSS-999 (-5) you should have used constant here.( [Computer], Damka)
        private void showWinMessege()
        {
            if (r_Game.CurrentPlayer.Opponent.Name == "[Computer]")
            {
                m_WinMessege = Messages.s_ComputerWin;
            }
            else
            {
                m_WinMessege = string.Format(Messages.s_Win, r_Game.CurrentPlayer.Opponent.Name);
            }

            switch (MessageBox.Show(m_WinMessege, "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    r_Game.ResetGame();
                    break;
                default:
                    Close();
                    break;
            }
        }

        private void showScores()
        {
            labelPlayer1.Text = string.Format(@"{0} : {1}", player1Name, r_Game.Player1.Score);
            labelPlayer2.Text = string.Format(@"{0} : {1}", player2Name, r_Game.Player2.Score);
        }

        private void getLocationsAndSizes()
        {
            if (m_BoardSize == 6)
            {
                player1Location = 100;
                player2Location = 250;
                Width = 415;
                Height = 400;
            }
            else if (m_BoardSize == 8)
            {
                player1Location = 150;
                player2Location = 300;
                Width = 515;
                Height = 500;
            }
            else if (m_BoardSize == 10)
            {
                player1Location = 200;
                player2Location = 350;
                Width = 615;
                Height = 600;
            }
        }
    }
}