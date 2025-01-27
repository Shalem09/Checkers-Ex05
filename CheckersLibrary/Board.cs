using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersLibrary
{
    public class Board
    {
        public ePieceType[,] Grid { get; private set; }

        public void SetBoard(int i_Size)
        {
            if (i_Size < 6 || i_Size > 10 || i_Size % 2 != 0)
            {
                throw new ArgumentException("Board size must be 6, 8 or 10.");
            }

            Grid = new ePieceType[i_Size, i_Size];
            initializeGrid();
        }

        private void initializeGrid()
        {
            int rows = Grid.GetLength(0);
            int cols = Grid.GetLength(1);

            int playerRows = rows == 6 ? 2 : rows == 8 ? 3 : 4;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row < playerRows && (row + col) % 2 == 1)
                    {
                        Grid[row, col] = ePieceType.O;
                    }
                    else if (row >= rows - playerRows && (row + col) % 2 == 1)
                    {
                        Grid[row, col] = ePieceType.X;
                    }
                    else
                    {
                        Grid[row, col] = ePieceType.None;
                    }
                }
            }
        }

        public ePieceType GetPieceAt(int i_Row, int i_Col)
        {
            return Grid[i_Row, i_Col];
        }

        public void SetPieceAt(int i_Row, int i_Col, ePieceType i_PieceType)
        {
            Grid[i_Row, i_Col] = i_PieceType;
        }
    }
}