# Sudoku
C# program for solving a Sudoku

Logic
------
1. if there are no missing numbers in the board, then return true
2. Get the first missing number position
3. Try to fill in any number in the missing number position by checking whether
    3.a The number is not present in the same row
    3.b The number is not present in the same column
    3.c The number is not present in the same box
         Calculation of row and column indices of the box is as follows
        startIndex = currentIndex - (currentIndex%3)
        endIndex = startIndex + 3
4. If the number can be placed,place the number in the position and recur
5. If the recursion returns true, return true
6. Backtrack by setting the position as 0 marking it as a place of missing number
        
