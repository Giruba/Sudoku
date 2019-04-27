using System;

namespace Soduku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solving a Sudoku!");
            Console.WriteLine("-----------------");

            new Sudoku().Solve();

            Console.ReadLine();
        }
    }
}
