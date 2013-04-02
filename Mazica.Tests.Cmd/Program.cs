using System;
using Mazica.Domain;

namespace Mazica.Tests.Cmd
{
	public class Program
	{
		static void Main(string[] args)
		{
			var game = new SimpleMazeGame();
			game.Play();
		}
	}
}
