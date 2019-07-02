namespace Ex05.CheckersLogic
{
    public class Checker
    {
        private static int s_Id = 0;
        private Point m_Position;
        private eType m_Kind;
        public int m_Id;

        public Checker(eType i_Kind)
        {
            m_Kind = i_Kind;
            m_Id = ++s_Id;
        }

        public override string ToString()
        {
            return m_Kind.ToString();
        }

        public eType Kind
        {
            get { return m_Kind; }
            set { m_Kind = value; }
        }

        public Point Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        
        public bool Equals(Checker i_Checker)
        {
            return m_Id == i_Checker.m_Id;
        }

        public void MaybeKing(Board i_Board)
        {
            if (m_Kind == eType.X && m_Position.X == 0)
            {
                m_Kind = eType.K;
            }
            else if (m_Kind == eType.O && m_Position.X == i_Board.Size - 1)
            {
                m_Kind = eType.U;
            }
        }

        public Step CanMove(eType i_Kind, Board i_Board)
        {
            Step simpleStep = null;
            Step check = null;

            if (m_Position.UpLeft().FoundOn(i_Board) &&
                (check = new Step(m_Position, m_Position.UpLeft())).IsSimpleStep(i_Kind, i_Board))
            {
                simpleStep = check;
            }
            else if (m_Position.UpRight().FoundOn(i_Board) &&
                (check = new Step(m_Position, m_Position.UpRight())).IsSimpleStep(i_Kind, i_Board))
            {
                simpleStep = check;
            }
            else if (m_Position.DownLeft().FoundOn(i_Board) &&
                (check = new Step(m_Position, m_Position.DownLeft())).IsSimpleStep(i_Kind, i_Board))
            {
                simpleStep = check;
            }
            else if (m_Position.DownRight().FoundOn(i_Board) &&
                (check = new Step(m_Position, m_Position.DownRight())).IsSimpleStep(i_Kind, i_Board))
            {
                simpleStep = check;
            }

            return simpleStep;
        }

        public Step CanEat(Board i_Board)
        {
            Step eatStep = null;

            if (CanEatLeftUp(m_Position.UpLeft().UpLeft(), i_Board))
            {
                eatStep = new Step(m_Position, m_Position.UpLeft().UpLeft());
            }
            else if (CanEatRightUp(m_Position.UpRight().UpRight(), i_Board))
            {
                eatStep = new Step(m_Position, m_Position.UpRight().UpRight());
            }
            else if (CanEatLeftDown(m_Position.DownLeft().DownLeft(), i_Board))
            {
                eatStep = new Step(m_Position, m_Position.DownLeft().DownLeft());
            }
            else if (CanEatRightDown(m_Position.DownRight().DownRight(), i_Board))
            {
                eatStep = new Step(m_Position, m_Position.DownRight().DownRight());
            }

            return eatStep;
        }
        
        public bool CanEatLeftUp(Point i_NextTo, Board i_Board)
        {
            Point leftUp = m_Position.UpLeft();
            return leftUp.UpLeft().Equals(i_NextTo) && canEatUp(leftUp, i_NextTo, i_Board);
        }

        public bool CanEatRightUp(Point i_NextTo, Board i_Board)
        {
            Point rightUp = m_Position.UpRight();
            return rightUp.UpRight().Equals(i_NextTo) && canEatUp(rightUp, i_NextTo, i_Board);
        }

        public bool CanEatLeftDown(Point i_NextTo, Board i_Board)
        {
            Point leftDown = m_Position.DownLeft();
            return leftDown.DownLeft().Equals(i_NextTo) && canEatDown(leftDown, i_NextTo, i_Board);
        }

        public bool CanEatRightDown(Point i_NextTo, Board i_Board)
        {
            Point rightDown = m_Position.DownRight();
            return rightDown.DownRight().Equals(i_NextTo) && canEatDown(rightDown, i_NextTo, i_Board);
        }

        private bool canEatUp(Point i_Up, Point i_NextTo, Board i_Board)
        {
            Box[,] board = i_Board.board;
            bool isPossibleToEatUp = false;

            if (i_Up.FoundOn(i_Board) && i_NextTo.FoundOn(i_Board) && board[i_Up.X, i_Up.Y].Checker != null && board[i_NextTo.X, i_NextTo.Y].Checker == null)
            {
                Checker forEat = board[i_Up.X, i_Up.Y].Checker;
                if ((m_Kind == eType.X || m_Kind == eType.K) && (forEat.m_Kind == eType.O || forEat.m_Kind == eType.U))
                {
                    isPossibleToEatUp = true;
                }
                else if (m_Kind == eType.U && (forEat.m_Kind == eType.X || forEat.m_Kind == eType.K))
                {
                    isPossibleToEatUp = true;
                }
            }

            return isPossibleToEatUp;
        }

        private bool canEatDown(Point i_Down, Point i_NextTo, Board i_Board)
        {
            Box[,] board = i_Board.board;
            bool isPossibleToEatDown = false;

            if (i_Down.FoundOn(i_Board) && i_NextTo.FoundOn(i_Board) && board[i_Down.X, i_Down.Y].Checker != null && board[i_NextTo.X, i_NextTo.Y].Checker == null)
            {
                Checker forEat = board[i_Down.X, i_Down.Y].Checker;
                if ((m_Kind == eType.O || m_Kind == eType.U) && (forEat.m_Kind == eType.X || forEat.m_Kind == eType.K))
                {
                    isPossibleToEatDown = true;
                }
                else if (m_Kind == eType.K && (forEat.m_Kind == eType.O || forEat.m_Kind == eType.U))
                {
                    isPossibleToEatDown = true;
                }
            }

            return isPossibleToEatDown;
        }
    }
}