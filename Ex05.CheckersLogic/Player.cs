using System.Collections.Generic;

namespace Ex05.CheckersLogic
{
    public class Player
    {
        private List<Checker> m_Checkers;
        private string m_Name;
        private eType m_Kind;
        private int m_Score;
        private int m_Maximumm_Checkers;
        private bool m_ComputerMode; 
        private Checker m_Specific;
        private Step m_HintSimpleStep;
        private Step m_HintEatStep;
        private Player m_Opponent;
        private Board m_Board;

        public Player(int i_SizeOfBoard, string i_Name, eType i_Kind, Board i_Board)
        {
            m_Maximumm_Checkers = ((i_SizeOfBoard / 2) * (i_SizeOfBoard / 2)) - 1;
            m_Kind = i_Kind;
            m_Name = i_Name;
            m_ComputerMode = false;
            m_Score = 0;
            m_Board = i_Board;

            Reset();
        }

        public void Reset()
        {
            m_Checkers = new List<Checker>(m_Maximumm_Checkers);
            m_Specific = null;
            m_HintSimpleStep = null;
            m_HintEatStep = null;
        }

        public List<Checker> Checkers
        {
            get { return m_Checkers; }
        }

        public eType Kind
        {
            get { return m_Kind; }
        }

        public string Name
        {
            get { return m_Name;  }
            set { m_Name = value; }
        }

        public bool ComputerMode
        {
            get { return m_ComputerMode; }
            set { m_ComputerMode = value; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public Player Opponent
        {
            get { return m_Opponent; }
            set { m_Opponent = value; }
        }

        public Step HintEatStep
        {
            get { return m_HintEatStep; }
        }

        public bool ValidSteps()
        {
            return playerCanMove() != null || playerCanEat() != null;
        }

        public int CalcScore()
        {
            int score = 0;
            foreach (Checker current in m_Checkers)
            {
                if (current.Kind == m_Kind)
                {
                    score++;
                }
                else
                {
                    score += 4;
                }
            }

            return score;
        }

        public eStatus Play(Step i_Step)
        {
            m_HintSimpleStep = playerCanMove();
            m_HintEatStep = playerCanEat();
            eStatus status;

            if (m_Specific != null)
            {
                m_HintEatStep = m_Specific.CanEat(m_Board);
                status = mustEat(i_Step);
            }
            else if (m_HintEatStep != null)
            {
                status = mustEat(i_Step);
            }
            else
            {
                status = regularStep(i_Step);
            }

            return status;
        }

        private eStatus regularStep(Step i_Step)
        {
            eStatus status;

            if (m_ComputerMode)
            {
                m_HintSimpleStep.MakeSimpleStep(m_Board);
                status = eStatus.endTurn;
            }
            else if (!i_Step.IsSimpleStep(m_Kind, m_Board))
            {
                status = eStatus.wrongInput;
            }
            else
            {
                i_Step.MakeSimpleStep(m_Board);
                status = eStatus.endTurn;
            }

            return status;
        }

        private eStatus mustEat(Step i_Step)
        {
            eStatus status;

            if (m_ComputerMode)
            {
                m_Specific = m_HintEatStep.MakeEatStep(m_Opponent, m_Board);
                status = checkMoreEat();
            }
            else if (!i_Step.IsEatStep(m_Board))
            {
                m_HintEatStep.NotifyHint(m_Board);
                status = eStatus.mustEat;
            }
            else if (m_Specific != null && !m_Specific.Position.Equals(i_Step.From))
            {
                m_HintEatStep.NotifyHint(m_Board);
                status = eStatus.mustEat;
            }
            else
            {
                m_Specific = i_Step.MakeEatStep(m_Opponent, m_Board);
                m_HintEatStep.NotifyChanged(m_Board);
                status = checkMoreEat();
            }

            return status;
        }

        private eStatus checkMoreEat()
        {
            eStatus status = eStatus.endTurn;

            if (m_Specific != null)
            {
                Step nextStep = m_Specific.CanEat(m_Board);
                if (nextStep != null)
                {
                    status = eStatus.oneMoreTurn;
                }
                else
                {
                    m_Specific = null;
                }
            }

            return status;
        }

        private Step playerCanMove()
        {
            Step simpleStep = null;

            foreach (Checker current in m_Checkers)
            {
                simpleStep = current.CanMove(m_Kind, m_Board);
                if (simpleStep != null)
                {
                    break;
                }
            }

            return simpleStep;
        }

        private Step playerCanEat()
        {
            Step eatStep = null;

            foreach (Checker current in m_Checkers)
            {
                eatStep = current.CanEat(m_Board);
                if (eatStep != null)
                {
                    break;
                }
            }

            return eatStep;
        }
    }
}