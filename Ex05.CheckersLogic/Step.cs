namespace Ex05.CheckersLogic
{
    public class Step
    {
        private Point m_From;
        private Point m_To;

        public Step(Point i_From, Point i_To)
        {
            m_From = i_From;
            m_To = i_To;
        }

        public Point From
        {
            get { return m_From; }
            set { m_From = value; }
        }

        public Point To
        {
            get { return m_To; }
            set { m_To = value; }
        }

        public bool Equal(Step i_Other)
        {
            return m_From.Equals(i_Other.m_From) && m_To.Equals(i_Other.m_To);
        }

        public void MakeSimpleStep(Board i_Board)
        {
            Box[,] board = i_Board.board;
            board[m_To.X, m_To.Y].Checker = board[m_From.X, m_From.Y].Checker;
            board[m_To.X, m_To.Y].Checker.Position = m_To;
            board[m_From.X, m_From.Y].Checker = null;
            board[m_To.X, To.Y].Checker.MaybeKing(i_Board);

            NotifyChanged(i_Board);
        }

        public Checker MakeEatStep(Player i_Opponent, Board i_Board)
        {
            Box[,] board = i_Board.board;
            board[m_To.X, m_To.Y].Checker = board[m_From.X, m_From.Y].Checker;
            board[m_To.X, m_To.Y].Checker.Position = m_To;
            board[m_From.X, m_From.Y].Checker = null;

            Checker temp = null;

            if (m_To.X < m_From.X && m_To.Y < m_From.Y)
            {
                temp = board[m_From.X - 1, m_From.Y - 1].Checker;
                i_Opponent.Checkers.Remove(temp);
                board[m_From.X - 1, m_From.Y - 1].Checker = null;
                board[m_From.X - 1, m_From.Y - 1].NotifyAboutChange();
            }
            else if (m_To.X < m_From.X && m_To.Y > m_From.Y)
            {
                temp = board[m_From.X - 1, m_From.Y + 1].Checker;
                i_Opponent.Checkers.Remove(temp);
                board[m_From.X - 1, m_From.Y + 1].Checker = null;
                board[m_From.X - 1, m_From.Y + 1].NotifyAboutChange();
            }
            else if (m_To.X > m_From.X && m_To.Y < m_From.Y)
            {
                temp = board[m_From.X + 1, m_From.Y - 1].Checker;
                i_Opponent.Checkers.Remove(temp);
                board[m_From.X + 1, m_From.Y - 1].Checker = null;
                board[m_From.X + 1, m_From.Y - 1].NotifyAboutChange();
            }
            else if (m_To.X > m_From.X && m_To.Y > m_From.Y)
            {
                temp = board[m_From.X + 1, m_From.Y + 1].Checker;
                i_Opponent.Checkers.Remove(temp);
                board[m_From.X + 1, m_From.Y + 1].Checker = null;
                board[m_From.X + 1, m_From.Y + 1].NotifyAboutChange();
            }

            board[m_To.X, m_To.Y].Checker.MaybeKing(i_Board);
            NotifyChanged(i_Board);

            return board[m_To.X, m_To.Y].Checker;
        }

        public void NotifyChanged(Board i_Board)
        {
            Box[,] board = i_Board.board;
            board[m_From.X, m_From.Y].NotifyAboutChange();
            board[m_To.X, m_To.Y].NotifyAboutChange();
        }

        public void NotifyHint(Board i_Board)
        {
            Box[,] board = i_Board.board;
            board[m_From.X, m_From.Y].NotifyHint();
            board[m_To.X, m_To.Y].NotifyHint();
        }

        public bool IsSimpleStep(eType i_CurrentKind, Board i_Board)
        {
            Box[,] board = i_Board.board;
            bool o_valid = true;

            if (board[m_From.X, m_From.Y].Checker == null || board[m_To.X, m_To.Y].Checker != null)
            {
                o_valid = false;
            }
            else if (!m_From.DownLeft().Equals(m_To) && !m_From.DownRight().Equals(m_To) && !m_From.UpLeft().Equals(m_To) && !m_From.UpRight().Equals(m_To))
            {
                o_valid = false;
            }
            else if (i_CurrentKind == eType.O)
            {
                if (board[m_From.X, m_From.Y].Checker.Kind != eType.O && board[m_From.X, m_From.Y].Checker.Kind != eType.U)
                {
                    o_valid = false;
                }
                else if (board[m_From.X, m_From.Y].Checker.Kind == eType.O && m_From.X > m_To.X)
                {
                    o_valid = false;
                }
            }
            else if (i_CurrentKind == eType.X)
            {
                if (board[m_From.X, m_From.Y].Checker.Kind != eType.X && board[m_From.X, m_From.Y].Checker.Kind != eType.K)
                {
                    o_valid = false;
                }
                else if (board[m_From.X, m_From.Y].Checker.Kind == eType.X && m_From.X < m_To.X)
                {
                    o_valid = false;
                }
            }
            
            return o_valid;
        }
    
        public bool IsEatStep(Board i_Board)
        {
            Box[,] board = i_Board.board;
            bool o_Valid = true;

            if (board[m_From.X, m_From.Y].Checker == null || board[m_To.X, m_To.Y].Checker != null)
            {
                o_Valid = false;
            }
            else
            {
                o_Valid = board[m_From.X, m_From.Y].Checker.CanEatLeftUp(m_To, i_Board) ||
                board[m_From.X, m_From.Y].Checker.CanEatRightUp(m_To, i_Board) ||
                board[m_From.X, m_From.Y].Checker.CanEatLeftDown(m_To, i_Board) ||
                board[m_From.X, m_From.Y].Checker.CanEatRightDown(m_To, i_Board);
            }

            return o_Valid;
        }
    }
}