using System;

namespace tic_tac_toe
{
    public class Field
    {
        private Player[,] field;
        private Player currentPlayer;

        public Field()
        {
            field = new Player[3, 3];
            ClearField();
            changePlayer();
        }

        public void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j] = Player.EMPTY;
                }
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Player.CROSS)
            {
                currentPlayer = Player.ZERO;
            }
            else
            {
                currentPlayer = Player.CROSS;
            }
        }

        public void MakeMove(int i, int j)
        {
            field[i, j] = currentPlayer;
            changePlayer();
        }

        public Player Winner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == field[i, 1] && field[i, 0] == field[i, 2] && field[i, 0] != Player.EMPTY)
                {
                    return field[i, 0];
                }

                if (field[0, i] == field[1, i] && field[0, i] == field[2, i] && field[0, i] != Player.EMPTY)
                {
                    return field[0, i];
                }
            }

            if (field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2] && field[0, 0] != Player.EMPTY)
            {
                return field[0, 0];
            }

            if (field[2, 0] == field[1, 1] && field[2, 0] == field[0, 2] && field[2, 0] != Player.EMPTY)
            {
                return field[2, 0];
            }

            return Player.EMPTY;
        }

        public void Print()
        {
            string mark = "";
            Console.WriteLine("  \\ j");
            Console.WriteLine("i   0 | 1 | 2 ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("  ------------");
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    switch (field[i, j])
                    {
                        case Player.EMPTY:
                            mark = "   ";
                            break;
                        case Player.CROSS:
                            mark = " X ";
                            break;
                        case Player.ZERO:
                            mark = " O ";
                            break;
                    }

                    Console.Write("|" + mark);
                }

                Console.WriteLine();
            }
        }

        public string GetPlayer()
        {
            switch (currentPlayer)
            {
                case Player.CROSS:
                    return "X"; 
                case Player.ZERO:
                    return "O";
            }
            return "empty";
        }

        public bool IsFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == Player.EMPTY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsEmpty(int i, int j)
        {
            return field[i, j] == Player.EMPTY;
        }
    }
}    