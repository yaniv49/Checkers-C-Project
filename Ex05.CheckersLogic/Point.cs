namespace Ex05.CheckersLogic
{
    public class Point
    {
        private int m_X;
        private int m_Y;

        public Point(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }

        public int X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        public int Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        public bool Equals(Point other)
        {
            return m_X == other.m_X && m_Y == other.m_Y;
        }

        public Point DownLeft()
        {
            return new Point(m_X + 1, m_Y - 1);
        }

        public Point DownRight()
        {
            return new Point(m_X + 1, m_Y + 1);
        }

        public Point UpLeft()
        {
            return new Point(m_X - 1, m_Y - 1);
        }

        public Point UpRight()
        {
            return new Point(m_X - 1, m_Y + 1);
        }

        public bool FoundOn(Board board)
        {
            return m_X >= 0 && m_X < board.Size && m_Y >= 0 && m_Y < board.Size;
        }
    }
}