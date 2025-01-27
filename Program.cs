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
    Console.WriteLine($"Player {player}: Where do you want to place your marker? (Give a letter and number, such as A1)");
    string position = Console.ReadLine().ToUpper();

    // Make sure input is valid
    bool input_is_valid = true;
    do
    { 
        // Make sure input is the valid length
        if (position.Length != 2)
        {
            Console.WriteLine("Your input is longer than 2 characters. Please enter a new position.");
            input_is_valid = false;
        }

        // Make sure first character is a valid letter  
        char letter = position[0];
        if (!char.IsLetter(letter) || letter < 'A' || letter > 'C')
        {
            Console.WriteLine("The first character you entered is not a valid letter (make sure to input A, B, or C). Please enter a new position.");
            input_is_valid = false;
        }

        // Make sure second character is a valid number  
        char number = position[1];
        if (!char.IsDigit(number) || number < '1' || number > '3')
        {
            Console.WriteLine("The second character you entered is not a valid letter (make sure to input 1, 2, or 3). Please enter a new position.");
            input_is_valid = false;
        }

        // Make sure the position is not already occupied
        if (positions_used.Contains(position))
        {
            Console.WriteLine("The position you selected is already occupied. Please enter a new position.");
            input_is_valid = false;
        }

    } while (input_is_valid == false);

    // Add the marker to the occupied list
    positions_used.Add(position);

    // Print the board with the new marking on it
    int column = position[0] - 'A';
    int row = position[1] - 1;

    if (player == 1)
    {
        game_board[column][row] = 'X';
    }
    else
    {
        game_board[column][row] = 'O';
    }

    // Pass array to method to print game board
    bg.PrintBoard(game_board);

    // Check if someone has won
    string round_result = bg.WinLose(game_board);

    // Notify players if someone has won
    if (round_result == "X")
    {
        game_on = false;
    }
    else if (round_result == "O")
    {
        game_on = false;
    }
    else if (round_result == "Draw")
    {
        game_on = false;
    }
}

// End game
Console.WriteLine($"Player {player} won! Great game!");