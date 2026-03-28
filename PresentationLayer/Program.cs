using BusinessLayer;
using System;

var gameService = new GameService();

while (true)
{
    Console.WriteLine("\n=== GAME MANAGER ===");
    Console.WriteLine("1. Add game");
    Console.WriteLine("2. View all games");
    Console.WriteLine("3. Delete game");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddGameMenu(gameService);
            break;
        case "2":
            ViewAllGames(gameService);
            break;
        case "3":
            DeleteGameMenu(gameService);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
}

static void AddGameMenu(IGameService gameService)
{
    Console.Write("Game title: ");
    string title = Console.ReadLine()!;
    Console.Write("Genre: ");
    string genre = Console.ReadLine()!;

    gameService.AddGame(title, genre);
    Console.WriteLine("Game added successfully!");
}

static void ViewAllGames(IGameService gameService)
{
    var games = gameService.GetAllGames();
    foreach (var g in games)
        Console.WriteLine($"[{g.Id}] {g.Title} — {g.Genre}");
}