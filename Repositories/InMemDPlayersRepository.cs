using System;
using System.Collections.Generic;
using CSAPIPractice.Entities;

namespace CSAPIPractice.Repositories
{

    public class InMemDPlayersRepository : IDPlayersRepository
    {
        private readonly List<Player> players = new List<Player>();

        public IEnumerable<Player> GetPlayers()
        {
            return players;
        }

        public Player GetPlayer(string identifier)
        {
            return players.Where(player => player.Identifier == identifier).FirstOrDefault();
        }

        public void AddPlayer(Player player)
        {
            var index = players.FindIndex(existingItem => existingItem.Identifier == player.Identifier);
            if (index == -1) {
                players.Add(player);
            }
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

        public void RemoveAllPlayers()
        {
            players.Clear();
        }
    }
}