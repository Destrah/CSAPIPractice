using CSAPIPractice.Entities;

namespace CSAPIPractice.Repositories
{
    public interface IDPlayersRepository
    {
        Player GetPlayer(string identifier);
        IEnumerable<Player> GetPlayers();
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void RemovePlayer(string identifier);
        void RemoveAllPlayers();
    }
}