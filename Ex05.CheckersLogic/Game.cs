namespace Ex05.CheckersLogic
{
    public class Game
    {
        private int m_Size;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private bool m_GameOver;
        private Board m_Board;

        public Player Player1
        {
            get { return m_Player1; }
        }
        
        public Player Player2
        {
            get { return m_Player2; }
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }

        public bool GameOver
        {
            get { return m_GameOver; }
            set { m_GameOver = value; }
        }

        public Board Board
        {
            get { return m_Board; }
        }

        public void InitGame(int i_Size, string i_Player1Name, string i_Player2Name, bool i_ComputerMode)
        {
            this.m_Size = i_Size;
            m_Board = new Board(i_Size);
            m_Player1 = new Player(i_Size, i_Player1Name, eType.X, m_Board);
            m_Player2 = new Player(i_Size, i_Player2Name, eType.O, m_Board);
            m_Player1.Opponent = m_Player2;
            m_Player2.Opponent = m_Player1;
            m_Player2.ComputerMode = i_ComputerMode;
        }

        public void ResetGame()
        {
            m_Player1.Reset();
            m_Player2.Reset();
            Board.ResetBoard(m_Player1, m_Player2);
            m_CurrentPlayer = m_Player1;
            m_GameOver = false;
        }

        public bool ComputerTurn()
        {
            return CurrentPlayer.ComputerMode;
        }

        public eStatus TakeAction(Step i_Step)
        {
            return CurrentPlayer.Play(i_Step);
        }

        public eStatus CheckRetireOption()
        {
            return CurrentPlayer.CalcScore() < CurrentPlayer.Opponent.CalcScore() ? eStatus.quit : eStatus.cannotQuit;
        }
    }
}