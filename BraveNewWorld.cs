using System;

namespace BraveNewWorld
{
	internal class BraveNewWorld
	{
		static void Main(string[] args)
		{
			char[,] map = new char[,]
			{
			{'#','#','#','#','#','#', '#', '#'},
			{'#',' ',' ',' ',' ',' ',' ','#'},
			{'#',' ',' ','#',' ',' ', ' ','#'},
			{'#',' ',' ','#',' ',' ',' ','#'},
			{'#',' ', ' ','#',' ',' ',' ','#'},
			{'#',' ',' ','#',' ',' ',' ','#'},
			{'#','#','#','#','#','#','#', '#'}
			};

			int playerPositionX = 1;
			int playerPositionY = 1;

			bool isPlaying = true;

			char playerSymbol = '@';
			char emptySymbol = ' ';

			DrawMap(map);
			DrawSymbol(playerPositionX, playerPositionY, playerSymbol);

			while (isPlaying)
			{
				ConsoleKeyInfo pressedKey = Console.ReadKey(true);


				if (pressedKey.Key == ConsoleKey.Escape)
				{
					isPlaying = false;
				}
				else
				{
					int[] direction = GetDirection(pressedKey);

					int nextPlayerPositionX = playerPositionX + direction[0];
					int nextPlayerPositionY = playerPositionY + direction[1];

					if (TryMove(nextPlayerPositionX, nextPlayerPositionY, map))
					{
						DrawSymbol(playerPositionX, playerPositionY, emptySymbol);

						playerPositionX = nextPlayerPositionX;
						playerPositionY = nextPlayerPositionY;

						DrawSymbol(playerPositionX, playerPositionY, playerSymbol);
					}
				}
			}
			Console.Clear();
		}

		static void DrawMap(char[,] map)
		{
			Console.Clear();

			for (int i = 0; i < map.GetLength(0); i++)
			{
				for (int j = 0; j < map.GetLength(1); j++)
				{
					Console.Write(map[i, j]);
				}
				Console.WriteLine();
			}
		}

		static void DrawSymbol(int positionX, int positionY, char symbol)
		{
			Console.SetCursorPosition(positionX, positionY);
			Console.Write(symbol);
		}

		static bool TryMove(int x, int y, char[,] map)
		{
			if (x >= 0 && x < map.GetLength(0) && y >= 0 && y < map.GetLength(1))
			{
				return map[y, x] != '#';
			}

			return false;
		}

		static int[] GetDirection(ConsoleKeyInfo pressedKey)
		{
			int[] direction = { 0, 0 };

			const ConsoleKey upArrow = ConsoleKey.UpArrow;
			const ConsoleKey downArrow = ConsoleKey.DownArrow;
			const ConsoleKey leftArrow = ConsoleKey.LeftArrow;
			const ConsoleKey rigtArrow = ConsoleKey.RightArrow;

			switch (pressedKey.Key)
			{
				case upArrow:
					direction[1] = -1;
					break;

				case downArrow:
					direction[1] = 1;
					break;

				case leftArrow:
					direction[0] = -1;
					break;

				case rigtArrow:
					direction[0] = 1;
					break;
			}

			return direction;
		}
	}
}
