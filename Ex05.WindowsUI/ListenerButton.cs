using System.Drawing;
using System.Windows.Forms;
using Ex05.CheckersLogic;

namespace Ex05.WindowsUI
{
    public class ListenerButton : Button
    {
        private const int k_Size = 50;
        private CheckersLogic.Point m_Position = null;

        public ListenerButton(Box i_Box)
        {
            m_Position = i_Box.Position;
            initializeButton(i_Box);
            i_Box.BoxChanged += button_BoxChanged;
            i_Box.ShowHint += button_NotifyHint;
        }

        public CheckersLogic.Point Position
        {
            get { return m_Position; }
        }

        private void button_NotifyHint(Box i_BoxChanged)
        {
            BackColor = Color.LightGoldenrodYellow;
        }

        private void button_BoxChanged(Box i_BoxChanged)                      
        {
            BackColor = Color.Empty;

            if (i_BoxChanged.Checker != null)
            {
                if (i_BoxChanged.Checker.Kind == eType.X)
                {
                    BackgroundImage = Properties.Resources.BlackChecker;
                }
                else if (i_BoxChanged.Checker.Kind == eType.O)
                {
                    BackgroundImage = Properties.Resources.RedChecker;
                }
                else if (i_BoxChanged.Checker.Kind == eType.K)
                {
                    BackgroundImage = Properties.Resources.KingBlack;
                }
                else if (i_BoxChanged.Checker.Kind == eType.U)
                {
                    BackgroundImage = Properties.Resources.KingRed;
                }
            }
            else
            {
                BackgroundImage = null;
            }
        }

        private void initializeButton(Box i_Box)                    
        {
            Size = new System.Drawing.Size(k_Size, k_Size);
            Location = new System.Drawing.Point((i_Box.Position.Y * k_Size) + k_Size, (i_Box.Position.X * k_Size) + k_Size);
            if (i_Box.Checker != null)
            {
                if (i_Box.Checker.Kind == eType.X)
                {
                    BackgroundImage = Properties.Resources.BlackChecker;
                }
                else if (i_Box.Checker.Kind == eType.O)
                {
                    BackgroundImage = Properties.Resources.RedChecker;
                }
            }

            BackgroundImageLayout = ImageLayout.Stretch;
            TabIndex = (i_Box.Position.X * k_Size) + i_Box.Position.Y;
            Enabled = i_Box.IsActive;
            if (!i_Box.IsActive) 
            {                   
                BackColor = Color.Gray;
            }
        }
    }
}