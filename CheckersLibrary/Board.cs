using System;

namespace CheckersLibrary
{
    public class Board
    {
        public ePieceType[,] m_Grid { get; private set; }

        public void SetBoard(int i_Size)
        {
            if (i_Size < 6 || i_Size > 10 || i_Size % 2 != 0)
            {
                throw new ArgumentException("Board size must be 6, 8 or 10.");
            }

            m_Grid = new ePieceType[i_Size, i_Size];
            initializeGrid();
        }

        private void initializeGrid()
        {
            int rows = m_Grid.GetLength(0);
            int cols = m_Grid.GetLength(1);

            int playerRows = rows == 6 ? 2 : rows == 8 ? 3 : 4;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {

                    //if (row == 0 && col == 9)
                    //{
                    //    m_Grid[row, col] = ePieceType.O;
                    //}
                    //else if (row == 2 && col == 7)
                    //{
                    //    m_Grid[row, col] = ePieceType.X;
                    //}
                    //else if (row == 3 && col == 6)
                    //{
                    //    m_Grid[row, col] = ePieceType.X;
                    //}
                    //else if (row == 5 && col == 4)
                    //{
                    //    m_Grid[row, col] = ePieceType.X;
                    //}
                    //else if (row == 7 && col == 2)
                    //{
                    //    m_Grid[row, col] = ePieceType.X;
                    //}
                    //else if (row == 9 && col == 8)
                    //{
                    //    m_Grid[row, col] = ePieceType.X;
                    //}
                    //else
                    //{
                    //    m_Grid[row, col] = ePieceType.None;
                    //}

                    if (row < playerRows && (row + col) % 2 == 1)
                    {
                        m_Grid[row, col] = ePieceType.O;
                    }
                    else if (row >= rows - playerRows && (row + col) % 2 == 1)
                    {
                        m_Grid[row, col] = ePieceType.X;
                    }
                    else
                    {
                        m_Grid[row, col] = ePieceType.None;
                    }
                }
            }
        }

        public ePieceType GetPieceAt(int i_Row, int i_Col)
        {
            return m_Grid[i_Row, i_Col];
        }

        public void SetPieceAt(int i_Row, int i_Col, ePieceType i_PieceType)
        {
            m_Grid[i_Row, i_Col] = i_PieceType;
        }
    }
}