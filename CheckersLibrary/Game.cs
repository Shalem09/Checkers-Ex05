    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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

        public void ChangeGameOverState(Player i_Quitter)
        {
            m_IsGameOver = !m_IsGameOver;
            m_Quitter = i_Quitter;
        }

        public void InitializeGame(int i_BoardSize, string i_Player1Name, string i_Player2Name)
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
	    //we need to updte the score
            int boardSize = m_Board.Grid.GetLength(0);
            m_Board = new Board();
            m_Board.SetBoard(boardSize);
            m_Players = m_Players;
            m_Quitter = null;
            m_IsGameOver = false;
        }

        private void CheckForwardMoves(int i_Row, int i_Col, int i_RowDirection, string i_FromPosition, List<string> i_OptionalMoves)
        {
            int nextRow = i_Row + i_RowDirection;
            int leftCol = i_Col - 1;
            int rightCol = i_Col + 1;

            if (IsValidPosition(nextRow, leftCol) && m_Board.GetPieceAt(nextRow, leftCol) == ePieceType.None)
            {
                string toPosition = $"{(char)(nextRow + 'A')}{(char)(leftCol + 'a')}";
                i_OptionalMoves.Add($"{i_FromPosition}>{toPosition}");
            }

            if (IsValidPosition(nextRow, rightCol) && m_Board.GetPieceAt(nextRow, rightCol) == ePieceType.None)
            {
                string toPosition = $"{(char)(nextRow + 'A')}{(char)(rightCol + 'a')}";
                i_OptionalMoves.Add($"{i_FromPosition}>{toPosition}");
            }
        }

        private void CheckForwardMovesNew(
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

        private void CheckBackwardMoves(int i_Row, int i_Col, int i_RowDirection, string i_FromPosition, List<string> i_OptionalMoves)
        {
            int behindRow = i_Row - i_RowDirection;
            int leftCol = i_Col - 1;
            int rightCol = i_Col + 1;

            if (IsValidPosition(behindRow, leftCol) && m_Board.GetPieceAt(behindRow, leftCol) == ePieceType.None)
            {
                string toPosition = $"{(char)(behindRow + 'A')}{(char)(leftCol + 'a')}";
                i_OptionalMoves.Add($"{i_FromPosition}>{toPosition}");
            }

            if (IsValidPosition(behindRow, rightCol) && m_Board.GetPieceAt(behindRow, rightCol) == ePieceType.None)
            {
                string toPosition = $"{(char)(behindRow + 'A')}{(char)(rightCol + 'a')}";
                i_OptionalMoves.Add($"{i_FromPosition}>{toPosition}");
            }
        }

        private void CheckBackwardMovesNew(
        int i_Row,
        int i_Col,
        int i_RowDirection,
        List<int> i_FromPosition,
        List<List<int>> i_OptionalMoves)
        {
            int behindRow = i_Row - i_RowDirection;
            int leftCol = i_Col - 1;
            int rightCol = i_Col + 1;

            if (IsValidPosition(behindRow, leftCol) && m_Board.GetPieceAt(behindRow, leftCol) == ePieceType.None)
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindRow, leftCol,
                };

                i_OptionalMoves.Add(move);
            }

            if (IsValidPosition(behindRow, rightCol) && m_Board.GetPieceAt(behindRow, rightCol) == ePieceType.None)
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindRow, rightCol,
                };

                i_OptionalMoves.Add(move);
            }
        }

        public List<string> GetOptionalMoves(Board i_Board, char i_Symbol)
        {
            List<string> optionalMoves = new List<string>();
            InitializePieceTypes(i_Symbol, out ePieceType regularPiece, out ePieceType kingPiece, out _, out _, out int rowDirection);

            for (int row = 0; row < i_Board.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.Grid.GetLength(1); col++)
                {
                    ePieceType piece = m_Board.GetPieceAt(row, col);

                    if (piece == regularPiece || piece == kingPiece)
                    {
                        string fromPosition = $"{(char)(row + 'A')}{(char)(col + 'a')}";
                        CheckForwardMoves(row, col, rowDirection, fromPosition, optionalMoves);

                        if (piece == kingPiece)
                        {
                            CheckBackwardMoves(row, col, rowDirection, fromPosition, optionalMoves);
                        }
                    }
                }
            }

            return optionalMoves;
        }

        public bool ContainsMove(List<List<int>> i_OptionalMoves, List<int> i_MoveToCheck)
        {
            bool containsMove = false;

            foreach (var move in i_OptionalMoves)
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


        public List<List<int>> GetOptionalMovesNew(Board i_Board, char i_Symbol)
        {
            List<List<int>> optionalMoves = new List<List<int>>();
            InitializePieceTypes(i_Symbol, out ePieceType regularPiece, out ePieceType kingPiece, out _, out _, out int rowDirection);

            for (int row = 0; row < i_Board.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.Grid.GetLength(1); col++)
                {
                    ePieceType piece = m_Board.GetPieceAt(row, col);

                    if (piece == regularPiece || piece == kingPiece)
                    {
                        List<int> fromPosition = new List<int>
                        {
                            row, col,
                        };
                        CheckForwardMovesNew(row, col, rowDirection, fromPosition, optionalMoves);

                        if (piece == kingPiece)
                        {
                            CheckBackwardMovesNew(row, col, rowDirection, fromPosition, optionalMoves);
                        }
                    }
                }
            }

            return optionalMoves;
        }


        private void InitializePieceTypes(char i_Symbol, out ePieceType o_PlayerPiece, out ePieceType o_PlayerKing,
                                  out ePieceType o_OpponentPiece, out ePieceType o_OpponentKing, out int o_RowDirection)
        {
            if (i_Symbol == 'X')
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

        private void CheckForwardEatMoves(int i_Row, int i_Col, int i_RowDirection, string i_FromPosition,
                                  ePieceType i_PlayerKing, ePieceType i_OpponentPiece,
                                  ePieceType i_OpponentKing, List<string> i_OptionalEats)
        {
            int eatRow = i_Row + i_RowDirection;
            int landRow = i_Row + (2 * i_RowDirection);
            int eatLeftCol = i_Col - 1;
            int eatRightCol = i_Col + 1;
            int landLeftCol = i_Col - 2;
            int landRightCol = i_Col + 2;

            if (IsValidEatMove(eatRow, eatLeftCol, landRow, landLeftCol, i_OpponentPiece, i_OpponentKing))
            {
                string toPosition = $"{(char)(landRow + 'A')}{(char)(landLeftCol + 'a')}";
                i_OptionalEats.Add($"{i_FromPosition}>{toPosition}");
            }

            if (IsValidEatMove(eatRow, eatRightCol, landRow, landRightCol, i_OpponentPiece, i_OpponentKing))
            {
                string toPosition = $"{(char)(landRow + 'A')}{(char)(landRightCol + 'a')}";
                i_OptionalEats.Add($"{i_FromPosition}>{toPosition}");
            }
        }

        private void CheckForwardEatMovesNew(int i_Row, int i_Col, int i_RowDirection, List<int> i_FromPosition,
                          ePieceType i_PlayerKing, ePieceType i_OpponentPiece,
                          ePieceType i_OpponentKing, List<List<int>> i_OptionalEats)
        {
            int eatRow = i_Row + i_RowDirection;
            int landRow = i_Row + (2 * i_RowDirection);
            int eatLeftCol = i_Col - 1;
            int eatRightCol = i_Col + 1;
            int landLeftCol = i_Col - 2;
            int landRightCol = i_Col + 2;

            if (IsValidEatMove(eatRow, eatLeftCol, landRow, landLeftCol, i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], landRow, landLeftCol, 
                };

                i_OptionalEats.Add(move);
            }

            if (IsValidEatMove(eatRow, eatRightCol, landRow, landRightCol, i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], landRow, landRightCol,
                };

                i_OptionalEats.Add(move);
            }
        }

        private void CheckBackwardEatMoves(int i_Row, int i_Col, int i_RowDirection, string i_FromPosition,
                                   ePieceType i_OpponentPiece, ePieceType i_OpponentKing,
                                   List<string> i_OptionalEats)
        {
            int behindEatRow = i_Row - i_RowDirection;
            int behindLandRow = i_Row - (2 * i_RowDirection);
            int eatLeftCol = i_Col - 1;
            int eatRightCol = i_Col + 1;
            int landLeftCol = i_Col - 2;
            int landRightCol = i_Col + 2;

            if (IsValidEatMove(behindEatRow, eatLeftCol, behindLandRow, landLeftCol, i_OpponentPiece, i_OpponentKing))
            {
                string toPosition = $"{(char)(behindLandRow + 'A')}{(char)(landLeftCol + 'a')}";
                i_OptionalEats.Add($"{i_FromPosition}>{toPosition}");
            }

            if (IsValidEatMove(behindEatRow, eatRightCol, behindLandRow, landRightCol, i_OpponentPiece, i_OpponentKing))
            {
                string toPosition = $"{(char)(behindLandRow + 'A')}{(char)(landRightCol + 'a')}";
                i_OptionalEats.Add($"{i_FromPosition}>{toPosition}");
            }
        }

        private void CheckBackwardEatMovesNew(int i_Row, int i_Col, int i_RowDirection, List<int> i_FromPosition,
                           ePieceType i_OpponentPiece, ePieceType i_OpponentKing,
                           List<List<int>> i_OptionalEats)
        {
            int behindEatRow = i_Row - i_RowDirection;
            int behindLandRow = i_Row - (2 * i_RowDirection);
            int eatLeftCol = i_Col - 1;
            int eatRightCol = i_Col + 1;
            int landLeftCol = i_Col - 2;
            int landRightCol = i_Col + 2;

            if (IsValidEatMove(behindEatRow, eatLeftCol, behindLandRow, landLeftCol, i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindLandRow, landLeftCol,
                };

                i_OptionalEats.Add(move);
            }

            if (IsValidEatMove(behindEatRow, eatRightCol, behindLandRow, landRightCol, i_OpponentPiece, i_OpponentKing))
            {
                List<int> move = new List<int>
                {
                    i_FromPosition[0], i_FromPosition[1], behindLandRow, landRightCol,
                };

                i_OptionalEats.Add(move);
            }
        }

        private bool IsValidEatMove(int i_EatRow, int i_EatCol, int i_LandRow, int i_LandCol,
                            ePieceType i_OpponentPiece, ePieceType i_OpponentKing)
        {
            return IsValidPosition(i_EatRow, i_EatCol) &&
                   IsValidPosition(i_LandRow, i_LandCol) &&
                   (m_Board.GetPieceAt(i_EatRow, i_EatCol) == i_OpponentPiece ||
                    m_Board.GetPieceAt(i_EatRow, i_EatCol) == i_OpponentKing) &&
                   m_Board.GetPieceAt(i_LandRow, i_LandCol) == ePieceType.None;
        }

        public List<string> GetOptionalEatMoves(Board i_Board, char i_Symbol)
        {
            List<string> optionalEats = new List<string>();
            InitializePieceTypes(i_Symbol, out ePieceType playerPiece, out ePieceType playerKing,
                                 out ePieceType opponentPiece, out ePieceType opponentKing,
                                 out int rowDirection);

            for (int row = 0; row < i_Board.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.Grid.GetLength(1); col++)
                {
                    ePieceType piece = m_Board.GetPieceAt(row, col);

                    if (piece == playerPiece || piece == playerKing)
                    {
                        string fromPosition = $"{(char)(row + 'A')}{(char)(col + 'a')}";
                        CheckForwardEatMoves(row, col, rowDirection, fromPosition, playerKing,
                                             opponentPiece, opponentKing, optionalEats);
                        if (piece == playerKing)
                        {
                            CheckBackwardEatMoves(row, col, rowDirection, fromPosition,
                                                  opponentPiece, opponentKing, optionalEats);
                        }
                    }
                }
            }

            return optionalEats;
        }

        public List<List<int>> GetOptionalEatMovesNew(Board i_Board, char i_Symbol)
        {
            List<List<int>> optionalEats = new List<List<int>>();
            InitializePieceTypes(i_Symbol, out ePieceType playerPiece, out ePieceType playerKing,
                                 out ePieceType opponentPiece, out ePieceType opponentKing,
                                 out int rowDirection);

            for (int row = 0; row < i_Board.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.Grid.GetLength(1); col++)
                {
                    ePieceType piece = m_Board.GetPieceAt(row, col);

                    if (piece == playerPiece || piece == playerKing)
                    {

                        List<int> fromPosition = new List<int>
                        {
                            row, col
                        };

                        CheckForwardEatMovesNew(row, col, rowDirection, fromPosition, playerKing,
                                             opponentPiece, opponentKing, optionalEats);
                        if (piece == playerKing)
                        {
                            CheckBackwardEatMovesNew(row, col, rowDirection, fromPosition,
                                                  opponentPiece, opponentKing, optionalEats);
                        }
                    }
                }
            }

            return optionalEats;
        }

        public bool HasMoreEatMoves(string i_LastMove, Board i_Board, ref List<string> i_EatMoves)
        {
            bool hasMoreEatMoves = false;
            i_EatMoves.Clear();
            string to = i_LastMove.Substring(3, 2);
            int row = to[0] - 'A';
            int col = to[1] - 'a';

            char pieceSymbol = (char)i_Board.GetPieceAt(row, col);

            List<string> eatMovesTotal = GetOptionalEatMoves(i_Board, pieceSymbol);
            List<string> eatMoves = new List<string>();

            foreach (string move in eatMovesTotal)
            {
                if (move.StartsWith(to))
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

        public bool HasMoreEatMovesNew(List<int> i_LastMove, Board i_Board, ref List<List<int>> i_EatMoves)
        {
            bool hasMoreEatMoves = false;
            i_EatMoves.Clear();
            int fromRow = i_LastMove[0];
            int fromCol = i_LastMove[1];
            int toRow = i_LastMove[2];
            int toCol = i_LastMove[3];
            List<int> toPosition = new List<int>
            {
                toRow, toCol
            };

            char pieceSymbol = (char)i_Board.GetPieceAt(fromRow, fromCol);

            List<List<int>> eatMovesTotal = GetOptionalEatMovesNew(i_Board, pieceSymbol);

            foreach (List<int> move in eatMovesTotal)
            {
                List<int> moveStartPosition = new List<int> 
                {
                    move[0], move[1] 
                };

                if (moveStartPosition == toPosition)
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


        // Here need to change i_Move from string to list of ints
        public void MakeMove(string i_Move, Board i_Board, bool i_IsEatingMove)
        {
            int fromRow = i_Move[0] - 'A';
            int fromCol = i_Move[1] - 'a';
            int toRow = i_Move[3] - 'A';
            int toCol = i_Move[4] - 'a';
            ePieceType newPieceType = ePieceType.None;

            if (toRow == i_Board.Grid.GetLength(0) - 1)
            {
                newPieceType = ePieceType.U;
            }
            else if(toRow == 0)
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

        public void MakeMoveNew(List<int> i_Move, Board i_Board, bool i_IsEatingMove)
        {
            int fromRow = i_Move[0];
            int fromCol = i_Move[1];
            int toRow = i_Move[2];
            int toCol = i_Move[3];
            ePieceType newPieceType = ePieceType.None;

            if (toRow == i_Board.Grid.GetLength(0) - 1)
            {
                newPieceType = ePieceType.U;
            }
            else if (toRow == 0)
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

        private string SelectMove(List<string> moves)
        {
            Random random = new Random();
            int index = random.Next(moves.Count);
            return moves[index];
        }

        private List<int> SelectMoveNew(List<List<int>> moves)
        {
            Random random = new Random();
            int index = random.Next(moves.Count);
            return moves[index];
        }


        public string MakeMoveForComputer(Board i_Board, char i_Symbol)
        {
            List<string> eatMoves = GetOptionalEatMoves(i_Board, i_Symbol);
            List<string> regularMoves = GetOptionalMoves(i_Board, i_Symbol);
            string selectedMove = null;

            if (eatMoves.Count > 0)
            {
                selectedMove = SelectMove(eatMoves);
            }
            else if (regularMoves.Count > 0)
            {
                selectedMove = SelectMove(regularMoves);
            }

            if (selectedMove != null)
            {
                MakeMove(selectedMove, i_Board, eatMoves.Contains(selectedMove));
            }
            else
            {
                Console.WriteLine($"Computer ({i_Symbol}) has no valid moves.");
                ChangeGameOverState(null);
            }
            
            return selectedMove;
        }

        public List<int> MakeMoveForComputerNew(Board i_Board, char i_Symbol)
        {
            List<List<int>> eatMoves = GetOptionalEatMovesNew(i_Board, i_Symbol);
            List<List<int>> regularMoves = GetOptionalMovesNew(i_Board, i_Symbol);
            List<int> selectedMove = null;

            if (eatMoves.Count > 0)
            {
                selectedMove = SelectMoveNew(eatMoves);
            }
            else if (regularMoves.Count > 0)
            {
                selectedMove = SelectMoveNew(regularMoves);
            }

            if (selectedMove != null)
            {
                MakeMoveNew(selectedMove, i_Board, eatMoves.Contains(selectedMove));
            }
            else
            {
                //Console.WriteLine($"Computer ({i_Symbol}) has no valid moves.");
                ChangeGameOverState(null);
            }

            return selectedMove;
        }


        public bool IsValidPosition(int i_Row, int i_Col)
        {
            return i_Row >= 0 && i_Row < m_Board.Grid.GetLength(0) &&
                   i_Col >= 0 && i_Col < m_Board.Grid.GetLength(1);
        }

        public int CalculatePlayerScore(Board i_Board, Player i_Player)
        {
            int pointsCounter = 0;
            ePieceType regularPiece = i_Player.m_Symbol == 'X' ? ePieceType.X : ePieceType.O;
            ePieceType kingPiece = i_Player.m_Symbol == 'X' ? ePieceType.K : ePieceType.U;

            for (int row = 0; row < i_Board.Grid.GetLength(0); row++)
            {
                for (int col = 0; col < i_Board.Grid.GetLength(1); col++)
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
