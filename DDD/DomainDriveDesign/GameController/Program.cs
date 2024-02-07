// See https://aka.ms/new-console-template for more information
using TicTacToe.Domain.DomainModel;

Console.WriteLine("Hello, World!");
Game.GameBuilder gameBuilder = new Game.GameBuilder();
gameBuilder.AddPlayer(new BotPlayer())
gameBuilder.Build();
game