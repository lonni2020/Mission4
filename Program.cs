// Mission 4 Assignment
// Group 2-10: Bentley Redden, Marissa Lewis, Lonni Burdett, Annabelle Baker

using Mission4;

// Initialize variables and classes
bool game_on = true;  // Declare whether the game should continue or not
int player = 2;  // Declare which player's turn it is
char[][] game_board = new char[4][];  // Game board nested array
List<string> positions_used = new List<string>();  // List containing positions that are already used
BoardGame bg = new BoardGame();

// Add numbers and letters for locations in the board
game_board[0] = new char[] { ' ', 'A', 'B', 'C' };
game_board[1] = new char[] { '1', '-', '-', '-' };
game_board[2] = new char[] { '2', '-', '-', '-' };
game_board[3] = new char[] { '3', '-', '-', '-' };

// Welcome the user
Console.WriteLine("Welcome to the Tic Tac Toe game!");

// Pass array to method to print game board
bg.PrintBoard(game_board);

// Loop until game is over
while (game_on == true)
{
    // Switch players
    if (player == 1)
    {
        player = 2;
    }
    else
    {
        player = 1;
    }

    // Ask the player where they want to place their marker
    Console.WriteLine($"\n\nPlayer {player}: Where do you want to place your marker? (Give a letter and number, such as A1)");
    string position = Console.ReadLine().ToUpper();

    // Make sure input is valid
    bool input_is_valid = false;
    while(!input_is_valid)
    {
        // Make sure input is the valid length
        if (position.Length != 2)
        {
            Console.WriteLine("Your input is longer than 2 characters. Please enter a new position.");
        }
        else
        {
            // Make sure first character is a valid letter  
            char letter = position[0];
            if (!char.IsLetter(letter) || letter < 'A' || letter > 'C')
            {
                Console.WriteLine("The first character you entered is not a valid letter (make sure to input A, B, or C). Please enter a new position.");
            }

            else
            {
                // Make sure second character is a valid number  
                char number = position[1];
                if (!char.IsDigit(number) || number < '1' || number > '3')
                {
                    Console.WriteLine("The second character you entered is not a valid letter (make sure to input 1, 2, or 3). Please enter a new position.");
                }

                else
                {
                    // Make sure the position is not already occupied
                    if (positions_used.Contains(position))
                    {
                        Console.WriteLine("The position you selected is already occupied. Please enter a new position.");
                        input_is_valid = false;
                    }
                    else
                    {
                        input_is_valid = true;
                    }
                }
            } 
        }
        // If the input is invalid, ask for a new one
        if (!input_is_valid)
        {
            Console.WriteLine("Try again:");
            position = Console.ReadLine().ToUpper();
        }
    }

    // Add the marker to the occupied list
    positions_used.Add(position);

    // Print the board with the new marking on it
    int column = position[0] - 'A' + 1;
    int row = position[1] - '1' + 1;

    if (player == 1)
    {
        game_board[row][column] = 'X';
    }
    else
    {
        game_board[row][column] = 'O';
    }

    // Pass array to method to print game board
    bg.PrintBoard(game_board);

    // Check if someone has won
    char round_result = bg.WinLose(game_board);

    // Notify players if someone has won
    if (round_result == 'X')
    {
        Console.WriteLine($"\n\nPlayer {player} won! Great game!");
        game_on = false;
    }
    else if (round_result == 'O')
    {
        Console.WriteLine($"\n\nPlayer {player} won! Great game!");
        game_on = false;
    }
    else if (round_result == 'D')
    {
        Console.WriteLine("\n\nIt was a draw! Great game!");
        game_on = false;
    }
}
