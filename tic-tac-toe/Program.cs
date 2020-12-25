using System;

namespace tic_tac_toe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Field field = new Field();
            int i = 0;
            int j = 0;
            string input = "";
            while (field.Winner() == Player.EMPTY && !field.IsFull())
            {
                field.Print();
                Console.WriteLine("Player " + field.GetPlayer() + " is moving.");
                Console.WriteLine("Specify the row number and column number from 0 to 2 separated by a space:");
                bool error;
                do
                {
                    error = false;
                    input = Console.ReadLine();
                    if (input.Length < 3)
                    {
                        Console.WriteLine("Too short line");
                        error = true;
                    } else if (!Int32.TryParse(input.Substring(0, 1), out i) |
                          !Int32.TryParse(input.Substring(2, 1), out j))
                    {
                        Console.WriteLine("Invalid character");
                        error = true;
                    }
                } while (error || i < 0 || i > 2 || j < 0 || j > 2 || !field.IsEmpty(i,j));
                field.MakeMove(i,j);
            }
            field.Print();
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
            Console.ReadLine();
        }
    }
}