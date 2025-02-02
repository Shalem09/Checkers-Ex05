using System.Windows.Forms;

namespace CheckersWindowsApp
{
    internal class ExtendedButton : Button
    {
        public char m_PlayerSymbol { get; private set; }

        public void SetSymbol(char i_Symbol)
        {
            m_PlayerSymbol = i_Symbol;
        }
    }
}
