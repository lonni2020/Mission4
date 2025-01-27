using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission4
{
    internal class BoardGame
    {
        public void PrintBoard(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine();

                for(int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
            }
        }

        public char WinLose(char[][] board)
        {
            char result = '-';


            // for rows check
            for (int row = 0; row < board.Length; row++)
            {
                if (board[row][1] != '-' && board[row][1] == board[row][2] && board[row][2] == board[row][3])
                {
                    result = board[row][0];
                }  
            }

            // columns check
            for (int col = 0; col < board.Length; col++)
            {
                if (board[1][col] != '-' && board[1][ col] == board[2][ col] && board[2][ col] == board[3][ col])
                {
                    result = board[1][col]; // Return the winner (X or O)
                }
            }

            // Check diagonals
            if (board[1][1] != '-' && board[1][1] == board[2][2] && board[2][2] == board[3][3])
            {
                result =  board[1][1]; // Return the winner (X or O)
            }

            // the other diagnal
            if (board[1][3] != '-' && board[1][3] == board[2][2] && board[2][2] == board[3][1])
            {
                result = board[1][3]; // Return the winner (X or O)
            }


            //check for a draw
            /*foreach (char[] row in board)
            {
                foreach (char cell in row)
                {
                    if (cell == '-') // Empty cell found
                    {
                        result = '-';
                    }
                }

            }*/
             // No empty cells, it's a draw


            return result;

        }
    }
}
