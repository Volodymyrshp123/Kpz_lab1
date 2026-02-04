using System;
using System.Collections.Generic;

namespace Game2048Lib
{
    public class GameBoard
    {
        public int[,] Board { get; private set; }
        public int Size { get; private set; } = 4;
        private Random rand = new Random();

        public GameBoard()
        {
            Board = new int[Size, Size];
            AddRandomTile();
            AddRandomTile();
        }

        public bool MoveLeft(out int points)
        {
            points = 0;
            bool moved = false;

            for (int i = 0; i < Size; i++)
            {
                int[] row = new int[Size];
                int index = 0;

                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] != 0)
                        row[index++] = Board[i, j];
                }

                for (int j = 0; j < Size - 1; j++)
                {
                    if (row[j] != 0 && row[j] == row[j + 1])
                    {
                        row[j] *= 2;
                        row[j + 1] = 0;
                        points += 2;
                        moved = true;
                    }
                }

                int[] newRow = new int[Size];
                index = 0;
                for (int j = 0; j < Size; j++)
                {
                    if (row[j] != 0)
                        newRow[index++] = row[j];
                }

                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] != newRow[j])
                    {
                        Board[i, j] = newRow[j];
                        moved = true;
                    }
                }
            }

            if (moved)
                AddRandomTile();

            return moved;
        }

        public bool MoveRight(out int points)
        {
            RotateBoard(180);
            bool moved = MoveLeft(out points);
            RotateBoard(180);
            return moved;
        }

        public bool MoveUp(out int points)
        {
            RotateBoard(270);
            bool moved = MoveLeft(out points);
            RotateBoard(90);
            return moved;
        }

        public bool MoveDown(out int points)
        {
            RotateBoard(90);
            bool moved = MoveLeft(out points);
            RotateBoard(270);
            return moved;
        }

        public bool MoveLeft() => MoveLeft(out _);
        public bool MoveRight() => MoveRight(out _);
        public bool MoveUp() => MoveUp(out _);
        public bool MoveDown() => MoveDown(out _);

        public void AddRandomTile()
        {
            List<(int, int)> empty = new List<(int, int)>();

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (Board[i, j] == 0)
                        empty.Add((i, j));

            if (empty.Count > 0)
            {
                var (x, y) = empty[rand.Next(empty.Count)];
                Board[x, y] = rand.Next(10) == 0 ? 4 : 2;
            }
        }

        private void RotateBoard(int angle)
        {
            for (int t = 0; t < angle / 90; t++)
            {
                int[,] newBoard = new int[Size, Size];
                for (int i = 0; i < Size; i++)
                    for (int j = 0; j < Size; j++)
                        newBoard[i, j] = Board[Size - j - 1, i];
                Board = newBoard;
            }
        }

        public bool CanMove()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] == 0) return true;
                    if (j < Size - 1 && Board[i, j] == Board[i, j + 1]) return true;
                    if (i < Size - 1 && Board[i, j] == Board[i + 1, j]) return true;
                }
            return false;
        }

        public bool Has2048Tile()
        {
            foreach (int value in Board)
                if (value == 2048)
                    return true;
            return false;
        }
    }
}
