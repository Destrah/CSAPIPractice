using System;
using System.Collections.Generic;
using CSAPIPractice.Entities;

namespace CSAPIPractice.Repositories
{

    public class InMemPlayersRepository : IPlayersRepository
    {
        private readonly List<Player> players = new List<Player>();

        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }

        public Player GetPlayer(string identifier)
        {
            return players.Where(player => player.Identifier == identifier).SingleOrDefault();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void UpdatePlayer(Player player)
        {
            var index = players.FindIndex(existingItem => existingItem.Identifier == player.Identifier);
            players[index] = player;
        }

        public void RemovePlayer(string identifier)
        {
            var index = players.FindIndex(existingItem => existingItem.Identifier == identifier);
            players.RemoveAt(index);
        }
    }
}