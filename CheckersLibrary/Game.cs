using System;
using System.Collections.Generic;

namespace CheckersLibrary
{
    public class Game
    {
        public Board m_Board { get; set; }
        public List<Player> m_Players { get; private set; }
        public Player m_Quitter { get; private set; }
        public bool m_IsGameOver { get; private set; }
        private int m_BoardSize;

        public Game(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_Players = new List<Player>(2);
        }

        private void checkBackwardMoves(
        int i_Row,
        int i_Col,
        int i_RowDirection,
        List<int> i_FromPosition,
        List<List<int>> i_OptionalMoves)
        {
            int behindRow = i_Row - i_RowDirection;
            int leftCol = i_Col - 1;
            int rightCol = i_Col + 1;

            if (IsValidPosition(behindRow, leftCol)
                && m_Board.GetPieceAt(behindRow, leftCol) == ePieceType.None)
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindRow, leftCol,
                };

                i_OptionalMoves.Add(move);
            }

            if (IsValidPosition(behindRow, rightCol)
                && m_Board.GetPieceAt(behindRow, rightCol) == ePieceType.None)
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindRow, rightCol,
                };

                i_OptionalMoves.Add(move);
            }
        }

        private void checkBackwardEatMoves(int i_Row, int i_Col, int i_RowDirection,
            List<int> i_FromPosition, ePieceType i_OpponentPiece, ePieceType i_OpponentKing,
                   List<List<int>> i_OptionalEats)
        {
            int behindEatRow = i_Row - i_RowDirection;
            int behindLandRow = i_Row - (2 * i_RowDirection);
            int eatLeftCol = i_Col - 1;
            int eatRightCol = i_Col + 1;
            int landLeftCol = i_Col - 2;
            int landRightCol = i_Col + 2;

            if (isValidEatMove(behindEatRow, eatLeftCol, behindLandRow,
                landLeftCol, i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindLandRow, landLeftCol,
                };

                i_OptionalEats.Add(move);
            }

            if (isValidEatMove(behindEatRow, eatRightCol, behindLandRow,
                landRightCol, i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindLandRow, landRightCol,
                };

                i_OptionalEats.Add(move);
            }
        }

        private void initializePieceTypes(char i_Symbol, out ePieceType o_PlayerPiece,
            out ePieceType o_PlayerKing, out ePieceType o_OpponentPiece,
            out ePieceType o_OpponentKing, out int o_RowDirection)
        {
            if (i_Symbol == 'X' || i_Symbol == 'K')
            {
                o_PlayerPiece = ePieceType.X;
                o_PlayerKing = ePieceType.K;
                o_OpponentPiece = ePieceType.O;
                o_OpponentKing = ePieceType.U;
                o_RowDirection = -1;
            }
            else
            {
                o_PlayerPiece = ePieceType.O;
                o_PlayerKing = ePieceType.U;
                o_OpponentPiece = ePieceType.X;
                o_OpponentKing = ePieceType.K;
                o_RowDirection = 1;
            }
        }

        private bool isValidEatMove(int i_EatRow, int i_EatCol, int i_LandRow, int i_LandCol,
                            ePieceType i_OpponentPiece, ePieceType i_OpponentKing)
        {
            return IsValidPosition(i_EatRow, i_EatCol) &&
                   IsValidPosition(i_LandRow, i_LandCol) &&
                   (m_Board.GetPieceAt(i_EatRow, i_EatCol) == i_OpponentPiece ||
                    m_Board.GetPieceAt(i_EatRow, i_EatCol) == i_OpponentKing) &&
                   m_Board.GetPieceAt(i_LandRow, i_LandCol) == ePieceType.None;
        }

        private List<int> selectMove(List<List<int>> i_Moves)
        {
            Random random = new Random();
            int index = random.Next(i_Moves.Count);

            return i_Moves[index];
        }

        private void checkForwardEatMoves(int i_Row, int i_Col, int i_RowDirection,
            List<int> i_FromPosition, ePieceType i_OpponentPiece,
                  ePieceType i_OpponentKing, List<List<int>> i_OptionalEats)
        {
            int eatRow = i_Row + i_RowDirection;
            int landRow = i_Row + (2 * i_RowDirection);
            int eatLeftCol = i_Col - 1;
            int eatRightCol = i_Col + 1;
            int landLeftCol = i_Col - 2;
            int landRightCol = i_Col + 2;

            if (isValidEatMove(eatRow, eatLeftCol, landRow, landLeftCol,
                i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], landRow, landLeftCol,
                };

                i_OptionalEats.Add(move);
            }

            if (isValidEatMove(eatRow, eatRightCol, landRow, landRightCol,
                i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], landRow, landRightCol,
                };

                i_OptionalEats.Add(move);
            }
        }

        private void checkForwardMoves(
            int i_Row,
            int i_Col,
            int i_RowDirection,
            List<int> i_FromPosition,
            List<List<int>> i_OptionalMoves)
        {
            int nextRow = i_Row + i_RowDirection;
            int leftCol = i_Col - 1;
            int rightCol = i_Col + 1;

            if (IsValidPosition(nextRow, leftCol) && m_Board.GetPieceAt(nextRow, leftCol) == ePieceType.None)
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], nextRow, leftCol,
                };

                i_OptionalMoves.Add(move);
            }

            if (IsValidPosition(nextRow, rightCol) && m_Board.GetPieceAt(nextRow, rightCol) == ePieceType.None)
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], nextRow, rightCol,
                };

                i_OptionalMoves.Add(move);
            }
        }

        public void ChangeGameOverState(Player i_Quitter)
        {
            m_IsGameOver = !m_IsGameOver;
            m_Quitter = i_Quitter;
        }

        public void InitializeGame(string i_Player1Name, string i_Player2Name)
        {
            m_Board = new Board();
            m_Board.SetBoard(m_BoardSize);

            Player player1 = new Player();
            player1.SetName(i_Player1Name);
            player1.SetSymbol('X');

            Player player2 = new Player();
            player2.SetName(i_Player2Name);
            player2.SetSymbol('O');

            m_Players.Add(player1);
            m_Players.Add(player2);
            m_Quitter = null;
            m_IsGameOver = false;
        }

        public void RestartGame()
        {
            int boardSize = m_Board.m_Grid.GetLength(0);
            m_Board = new Board();
            m_Board.SetBoard(boardSize);
            m_Players = m_Players;
            m_Quitter = null;
            m_IsGameOver = false;
        }

        public List<List<int>> GetOptionalMoves(Board i_Board, char i_Symbol)
        {
            List<List<int>> optionalMoves = new List<List<int>>();
            initializePieceTypes(i_Symbol, out ePieceType regularPiece, out ePieceType kingPiece, out _, out _, out int rowDirection);

            for (int row = 0; row < i_Board.m_Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.m_Grid.GetLength(1); col++)
                {
                    ePieceType piece = m_Board.GetPieceAt(row, col);

                    if (piece == regularPiece || piece == kingPiece)
                    {
                        List<int> fromPosition = new List<int>
                        {
                            row, col,
                        };
                        checkForwardMoves(row, col, rowDirection, fromPosition, optionalMoves);

                        if (piece == kingPiece)
                        {
                            checkBackwardMoves(row, col, rowDirection, fromPosition, optionalMoves);
                        }
                    }
                }
            }

            return optionalMoves;
        }

        public List<List<int>> GetOptionalEatMoves(Board i_Board, char i_Symbol)
        {
            List<List<int>> optionalEats = new List<List<int>>();
            initializePieceTypes(i_Symbol, out ePieceType playerPiece, out ePieceType playerKing,
                                 out ePieceType opponentPiece, out ePieceType opponentKing,
                                 out int rowDirection);

            for (int row = 0; row < i_Board.m_Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.m_Grid.GetLength(1); col++)
                {
                    ePieceType piece = m_Board.GetPieceAt(row, col);

                    if (piece == playerPiece || piece == playerKing)
                    {

                        List<int> fromPosition = new List<int>
                        {
                            row, col
                        };

                        checkForwardEatMoves(row, col, rowDirection, fromPosition,
                                             opponentPiece, opponentKing, optionalEats);
                        if (piece == playerKing)
                        {
                            checkBackwardEatMoves(row, col, rowDirection, fromPosition,
                                                  opponentPiece, opponentKing, optionalEats);
                        }
                    }
                }
            }

            return optionalEats;
        }

        public bool IsValidPosition(int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < m_Board.m_Grid.GetLength(0) &&
                   i_Col >= 0 && i_Col < m_Board.m_Grid.GetLength(1);
        }

        public bool IsContainsMove(List<List<int>> i_OptionalMoves, List<int> i_MoveToCheck)
        {
            bool containsMove = false;

            foreach (List<int> move in i_OptionalMoves)
            {
                if (move.Count == i_MoveToCheck.Count)
                {
                    bool isEqual = true;

                    for (int i = 0; i < move.Count; i++)
                    {
                        if (move[i] != i_MoveToCheck[i])
                        {
                            isEqual = false;
                            break;
                        }
                    }

                    if (isEqual)
                    {
                        containsMove = true;
                        break;
                    }
                }
            }

            return containsMove;
        }

        public void MakeMove(List<int> i_Move, Board i_Board, bool i_IsEatingMove)
        {
            int fromRow = i_Move[0];
            int fromCol = i_Move[1];
            int toRow = i_Move[2];
            int toCol = i_Move[3];
            ePieceType newPieceType;

            if (toRow == i_Board.m_Grid.GetLength(0) - 1 && i_Board.GetPieceAt(fromRow, fromCol) == ePieceType.O)
            {
                newPieceType = ePieceType.U;
            }
            else if (toRow == 0 && i_Board.GetPieceAt(fromRow, fromCol) == ePieceType.X)
            {
                newPieceType = ePieceType.K;
            }
            else
            {
                newPieceType = i_Board.GetPieceAt(fromRow, fromCol);
            }

            i_Board.SetPieceAt(fromRow, fromCol, ePieceType.None);
            i_Board.SetPieceAt(toRow, toCol, newPieceType);

            if (i_IsEatingMove)
            {
                int eatAtRow = (fromRow + toRow) / 2;
                int eatAtCol = (fromCol + toCol) / 2;
                i_Board.SetPieceAt(eatAtRow, eatAtCol, ePieceType.None);
            }
        }

        public void MakeMoveForComputer(Board i_Board)
        {
            List<List<int>> eatMoves = GetOptionalEatMoves(i_Board, 'O');
            List<List<int>> regularMoves = GetOptionalMoves(i_Board, 'O');
            List<int> selectedMove = null;
            bool isEatMove = false;

            if (eatMoves.Count > 0)
            {
                selectedMove = selectMove(eatMoves);
                isEatMove = true;
            }
            else if (regularMoves.Count > 0)
            {
                selectedMove = selectMove(regularMoves);
            }

            if (selectedMove != null)
            {
                MakeMove(selectedMove, m_Board, eatMoves.Contains(selectedMove));

                if (isEatMove)
                {
                    while (IsMoreEatMoves(selectedMove, m_Board, ref eatMoves))
                    {
                        MakeMoveForComputer(m_Board);
                    }
                }
            }
            else
            {
                ChangeGameOverState(m_Players[1]);
            }
        }

        public bool IsMoreEatMoves(List<int> i_LastMove, Board i_Board,
            ref List<List<int>> i_EatMoves)
        {
            bool hasMoreEatMoves = false;
            i_EatMoves.Clear();
            int landRow = i_LastMove[2];
            int landCol = i_LastMove[3];

            char pieceSymbol = (char)i_Board.GetPieceAt(landRow, landCol);
            List<List<int>> eatMovesTotal = GetOptionalEatMoves(i_Board, pieceSymbol);

            foreach (List<int> move in eatMovesTotal)
            {
                if (move[0] == landRow && move[1] == landCol)
                {
                    i_EatMoves.Add(move);
                }
            }

            if (i_EatMoves.Count > 0)
            {
                hasMoreEatMoves = true;
            }

            return hasMoreEatMoves;
        }

        public int CalculatePlayerScore(Board i_Board, Player i_Player)
        {
            int pointsCounter = 0;
            ePieceType regularPiece = i_Player.m_Symbol == 'X' ? ePieceType.X : ePieceType.O;
            ePieceType kingPiece = i_Player.m_Symbol == 'X' ? ePieceType.K : ePieceType.U;

            for (int row = 0; row < i_Board.m_Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.m_Grid.GetLength(1); col++)
                {
                    ePieceType piece = i_Board.GetPieceAt(row, col);

                    if (piece == regularPiece)
                    {
                        pointsCounter++;
                    }

                    if (piece == kingPiece)
                    {
                        pointsCounter += 4;
                    }
                }
            }

            return pointsCounter;
        }

        public void CalculateScore(List<Player> i_Players)
        {
            int firstPlayerScore = CalculatePlayerScore(m_Board, i_Players[0]);
            int secondPlayerScore = CalculatePlayerScore(m_Board, i_Players[1]);
            int diff = Math.Abs(firstPlayerScore - secondPlayerScore);

            if (firstPlayerScore > secondPlayerScore)
            {
                i_Players[0].AddScore(diff);
            }
            else if (secondPlayerScore > firstPlayerScore)
            {
                i_Players[1].AddScore(diff);
            }
        }
    }
}
