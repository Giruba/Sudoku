using System;
using System.Collections.Generic;
using System.Text;

namespace Soduku
{
    class Sudoku
    {
        int[,] board;

        public Sudoku() {
            board = new int[9, 9];
        }

        public void SetSodukuBoard(int[,] board) {
            this.board = board;
        }

        public int[,] GetSodukuBoard() {
            return board;
        }

        public void Solve() {
            board = GetSodukuInput();
            if (_FillMissingNumbers(board))
            {
                Console.WriteLine("Sudoku is solved!");
                Console.WriteLine();
                PrintSudokuBoard(board);
            }
            else {
                Console.WriteLine("Sudoku cannot be solved!");
            }
        }

        public int[,] GetSodukuInput() {
            Console.WriteLine("Enter the elements of each row" +
                " separated by space, colon or semi-colon");
            try {
                for (int index = 0; index < 9; index++) {
                    Console.WriteLine("Enter the elements of row " + index
                        + " separated by space");
                    String[] elements = Console.ReadLine().Split(' ', ',', ';');
                    for (int elementIndex = 0; elementIndex < elements.Length; elementIndex++) {
                        board[index, elementIndex] = int.Parse(elements[elementIndex]);
                    }
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is " +
                    "" + exception.Message);
            }

            return board;
        }

        public void PrintSudokuBoard(int[,] matrix) {
            for (int rowIndex = 0; rowIndex < 9; rowIndex++) {
                for (int colIndex = 0; colIndex < 9; colIndex++) {
                    Console.Write(matrix[rowIndex, colIndex] + " ");
                }
                Console.WriteLine();
            }
        }

        private bool IndeedMissing(UnfilledPosition unfilledPosition) {
            return unfilledPosition.GetRowPosition() != -1 &&
                unfilledPosition.GetColumnPosition() != -1;
        }

        private bool _FillMissingNumbers(int[,] board) {

            UnfilledPosition position = new UnfilledPosition(-1, -1);
            position = _GetMissingPosition(board);
            //If there is no missing number, the problem is solved!
            if (!IndeedMissing(position))
            {
                return true;
            }
            for (int numberToBeFilled = 1; numberToBeFilled < 10; numberToBeFilled++)
            {
                if (CanThisNumberFilled(board, position.GetRowPosition(),
                    position.GetColumnPosition(), numberToBeFilled))
                {
                    board[position.GetRowPosition(), position.GetColumnPosition()] = numberToBeFilled;
                    //Recurse for other missing numbers
                    if (_FillMissingNumbers(board))
                    {
                        return true;
                    }
                    else
                    {
                        //Backtrack -> Reset the filled number
                        board[position.GetRowPosition(), position.GetColumnPosition()] = 0;
                    }
                }
            }
            return false;
        }
        private UnfilledPosition _GetMissingPosition(int[,] board) {
            UnfilledPosition unfilledPosition = new UnfilledPosition(-1, -1);
            
            for (int index = 0; index < 9; index++){
                for (int secIndex = 0; secIndex < 9; secIndex++) {
                    if (board[index, secIndex] == 0) {
                        unfilledPosition.SetRowPosition(index);
                        unfilledPosition.SetColumnPosition(secIndex);
                        break;
                    }
                }
                //Break out of outer for if missing position is found
                if (IndeedMissing(unfilledPosition)) {
                    break;
                }
            }
            return unfilledPosition;
        }

        private bool CanThisNumberFilled(int[,] board, int rowPosition, int columnPosition, int number) {

            /* Check whether the number that we are going to fill
            *  is already present in the same row.
            *  If yes, we should return false
            */
            for (int colIndex  = 0; colIndex < 9; colIndex++) {
                if (board[rowPosition, colIndex] == number) {
                    return false;
                }   
            }

            /* Similarly, we should return false, if we find
             * the number that we are going to place is already
             * present in the column
             */
            for (int rowIndex = 0; rowIndex < 9; rowIndex++) {
                if (board[rowIndex, columnPosition] == number) {
                    return false;
                }
            }

            /* We know that as per Sudoku rules, we cannot have the 
             * same number that we are going to fill in the same
             * box. That is every (3*3) box in Sudoku board
             * should have unique numbers from 1 to 9.
             */
            int rowPositionStart = rowPosition - (rowPosition%3);
            int colPositionStart = columnPosition - (columnPosition % 3);
            int rowPositionEnd = rowPositionStart + 3;
            int colPositionEnd = colPositionStart + 3;
            for (int rowIndex = rowPositionStart; rowIndex < rowPositionEnd; rowIndex++) {
                for (int colIndex = colPositionStart; colIndex < colPositionEnd; colIndex++) {
                    if (board[rowIndex, colIndex] == number) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
