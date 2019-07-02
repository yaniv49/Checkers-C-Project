namespace Ex05.CheckersLogic
{
    public class Board
    {
        private readonly int r_Size;
        private Box[,] m_Board;

        public Board(int i_Size)
        {
            r_Size = i_Size;
            m_Board = new Box[i_Size, i_Size];
            InitBoard();
        }

        public int Size
        {
            get { return r_Size; }
        }

        public Box[,] board
        {
            get { return m_Board; }
        }

        public void InitBoard()
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    Point point = new Point(i, j);
                    m_Board[i, j] = new Box(point);
                }
            }
        }

        public void ResetBoard(Player i_player1, Player i_player2)
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    Point point = new Point(i, j);
                    Box box = m_Board[i, j];

                    if ((i % 2 != 0 && j % 2 == 0) || (i % 2 == 0 && j % 2 != 0))
                    {
                        box.IsActive = true;

                        if (i < (r_Size / 2) - 1)
                        {
                            box.Checker = new Checker(eType.O);
                            box.Checker.Position = point;
                            i_player2.Checkers.Add(box.Checker);
                        }
                        else if(i > (r_Size / 2))
                        {
                            box.Checker = new Checker(eType.X);
                            box.Checker.Position = point;
                            i_player1.Checkers.Add(box.Checker);
                        }
                        else
                        {
                            box.Checker = null;
                        }
                    }

                    m_Board[i, j].NotifyAboutChange();
                }
            }
        }
    }
}