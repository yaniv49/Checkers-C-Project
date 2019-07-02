namespace Ex05.CheckersLogic
{
    public class Box
    {
        public event BoxChangedDelegate BoxChanged;

        public event HintDelegate ShowHint;

        private Point m_Position;
        private Checker m_Checker;
        private bool m_IsActive;

        public Box(Point i_Position)
        {
            m_Position = i_Position;
            m_Checker = null;
            m_IsActive = false;
        }

        public Point Position
        {
            get { return m_Position; }
        }

        public bool IsActive
        {
            get { return m_IsActive; }
            set { m_IsActive = value; }
        }

        public Checker Checker
        {
            get { return m_Checker; }
            set { m_Checker = value; }
        }

        public override string ToString()
        {
            return m_Checker.ToString();
        }

        public void NotifyAboutChange()
        {
            if(m_IsActive && BoxChanged != null)
            {
                BoxChanged.Invoke(this);
            }
        }

        public void NotifyHint()
        {
            if(m_IsActive && ShowHint != null)
            {
                ShowHint.Invoke(this);
            }
        }
    }
}