namespace CheckersLibrary
{
    public class Player
    {
        public string m_Name { get; private set; }
        public char m_Symbol { get; private set; }
        public int m_Score { get; private set; }

        public Player()
        {
            m_Score = 0;
        }

        public void SetSymbol(char i_Symbol)
        {
            m_Symbol = i_Symbol;
        }

        public void AddScore(int i_Score)
        {
            m_Score += i_Score;
        }

        public void SetName(string i_Name)
        {
            m_Name = char.ToUpper(i_Name[0]) + i_Name.Substring(1);
        }

    }
}

