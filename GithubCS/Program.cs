using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace GithubCS
{
	class Program
	{
		private DiscordClient _client;

		static void Main(string[] args)
		{
			new Program().mainBot();
			while (Console.ReadLine() == "")
			{
				
			}
		}

		private async void mainBot()
		{
			_client = new DiscordClient();
			_client.MessageReceived += async (s, e) =>
			{
				if(e.Message.IsAuthor) return;
				var wordArray = e.Message.RawText.Split(' ');
				foreach (var word in wordArray)
				{
					if (word.StartsWith("#"))
					{
						string number = word.Replace("#", "");
						await e.Channel.SendMessage("https://github.com/HearthSim/Hearthstone-Deck-Tracker/pull/" + number);
					}
				}
			};

			_client.ExecuteAndWait(async () => {
				await _client.Connect(ReadToken(), TokenType.Bot);
			});
		}

		private string ReadToken(string filename = "token.txt")
		{
			if (!File.Exists(filename))
			{
				Console.WriteLine("Please input Token: ");
				return Console.ReadLine();
			}
			return File.ReadAllText(filename);
		}
	}
}
