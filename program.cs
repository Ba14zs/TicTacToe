using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static char[] board = new char[9];

    static void Main()
    {
        Console.Title = "Tic-Tac-Toe by Ba14zs";
        StartNewGameLoop();
    }

    static void StartNewGameLoop()
    {
        while (true)
        {
            InitBoard();
            PlayGame();
            Console.WriteLine();
            Console.Write("New game? [Y]es/[N]o: ");
            var k = Console.ReadKey(true).KeyChar;
            Console.WriteLine(k);
            if (char.ToLower(k) != 'y') break;
        }
    }

    static void InitBoard()
    {
        for (int i = 0; i < 9; i++) board[i] = ' ';
    }

    static void PlayGame()
    {
        bool playerStarts = true;
        Console.Write("Do you want to start? [Y]es/[N]o: ");
        var c = Console.ReadKey(true).KeyChar;
        Console.WriteLine(c);
        if (char.ToLower(c) == 'n') playerStarts = false;

        char current = playerStarts ? 'X' : 'O';
        while (true)
        {
            Console.Clear();
            PrintBoard();
            var winner = CheckWinner(board);
            if (winner != ' ')
            {
                if (winner == 'D')
                {
                    Console.WriteLine("Draw!");
                }
                else
                {
                    Console.WriteLine($"The winner is: {winner}");
                    if (winner == 'X') Console.WriteLine("You are the winner!");
                    else Console.WriteLine("Bot won.");
                }
                break;
            }

            if (current == 'X')
            {
                PlayerMove();
                current = 'O';
            }
            else
            {
                Console.WriteLine("Bot thinks...");
                AIMove();
                current = 'X';
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine();
        Console.WriteLine("Gameboard: (You: X, Bot: O)");
        Console.WriteLine();

        for (int r = 0; r < 3; r++)
        {
            int baseIdx = r * 3;
            Console.WriteLine($" {Symbol(board[baseIdx])} | {Symbol(board[baseIdx + 1])} | {Symbol(board[baseIdx + 2])} ");
            if (r < 2) Console.WriteLine("---+---+---");
        }

        Console.WriteLine();
    }

    static char Symbol(char c) => c == ' ' ? '.' : c;

    static void PlayerMove()
    {
        while (true)
        {
            Console.Write("Where do you want to move? (0-8): ");
            string? input = Console.ReadLine()?.Trim();
            if (int.TryParse(input, out int idx))
            {
                if (idx >= 0 && idx < 9)
                {
                    if (board[idx] == ' ')
                    {
                        board[idx] = 'X';
                        return;
                    }
                    else
                    {
                        Console.WriteLine("That spot is taken. Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Please choose a number between 0 and 8!");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number!");
            }
        }
    }

    static void AIMove()
    {
        int bestScore = int.MinValue;
        int bestMove = -1;
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == ' ')
            {
                board[i] = 'O';
                int score = Minimax(board, false);
                board[i] = ' ';
                if (score > bestScore)
                {
                    bestScore = score;
                    bestMove = i;
                }
            }
        }

        if (bestMove == -1)
        {
            var empties = Enumerable.Range(0, 9).Where(i => board[i] == ' ').ToArray();
            if (empties.Length > 0) bestMove = empties[0];
            else return;
        }

        board[bestMove] = 'O';
        Console.WriteLine($"Bot moved to space {bestMove}");
        Thread.Sleep(600);
    }

    static int Minimax(char[] state, bool isMaximizing)
    {
        char winner = CheckWinner(state);
        if (winner != ' ')
        {
            if (winner == 'O') return 10;
            if (winner == 'X') return -10;
            if (winner == 'D') return 0;
        }

        if (isMaximizing)
        {
            int best = int.MinValue;
            for (int i = 0; i < 9; i++)
            {
                if (state[i] == ' ')
                {
                    state[i] = 'O';
                    int val = Minimax(state, false);
                    state[i] = ' ';
                    best = Math.Max(best, val);
                }
            }
            return best;
        }
        else
        {
            int best = int.MaxValue;
            for (int i = 0; i < 9; i++)
            {
                if (state[i] == ' ')
                {
                    state[i] = 'X';
                    int val = Minimax(state, true);
                    state[i] = ' ';
                    best = Math.Min(best, val);
                }
            }
            return best;
        }
    }

    static char CheckWinner(char[] b)
    {
        int[][] wins = new int[][]
        {
            new[]{0,1,2},
            new[]{3,4,5},
            new[]{6,7,8},
            new[]{0,3,6},
            new[]{1,4,7},
            new[]{2,5,8},
            new[]{0,4,8},
            new[]{2,4,6},
        };

        foreach (var w in wins)
        {
            if (b[w[0]] != ' ' && b[w[0]] == b[w[1]] && b[w[1]] == b[w[2]])
            {
                return b[w[0]];
            }
        }

        if (b.Any(c => c == ' ')) return ' ';
        return 'D';
    }
}
