using System;

namespace tic_tac_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Field field = new Field();
            int i;
            int j;
            string input = "";
            while (field.Winner() == Player.EMPTY && !field.IsFull())
            {
                field.Print();
                Console.WriteLine("Player " + field.GetPlayer() + " is moving.");
                Console.WriteLine("Specify the row number and column number from 0 to 2 separated by a space:");
                do
                {
                    input = Console.ReadLine();
                    if (!Int32.TryParse(input.Substring(0, 1), out i) |
                        !Int32.TryParse(input.Substring(2, 1), out j))
                    {
                        Console.WriteLine("Invalid character");
                        continue;
                    }
                } while (i < 0 || i > 2 || j < 0 || j > 2 || !field.IsEmpty(i,j));
                field.MakeMove(i,j);
            }
            switch (field.Winner())
            {
                case Player.EMPTY:
                    Console.WriteLine("The game ended in a draw");
                    break;
                case Player.CROSS:
                    Console.WriteLine("Congratulations, winner is player X");
                    break;
                case Player.ZERO:
                    Console.WriteLine("Congratulations, winner is player O");
                    break;
            }
        }
    }
}