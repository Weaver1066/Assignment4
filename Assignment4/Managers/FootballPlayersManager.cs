using Assignment1;

namespace Assignment4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer{id = _nextId++, Name = "Bob Ross", Age = 30, ShirtNumber = 23 },
            new FootballPlayer{id = _nextId++, Name = "Jeff Besos", Age = 25, ShirtNumber = 30 },
            new FootballPlayer{id = _nextId++, Name = "Joe Biden", Age = 89, ShirtNumber = 42 },
            new FootballPlayer{id = _nextId++, Name = "David Wreckham", Age = 26, ShirtNumber = 80 },
        };

        public List<FootballPlayer> GetAll()
        {
            List<FootballPlayer> footballPlayerslist = new List<FootballPlayer>(Data);
            return footballPlayerslist;
        }
        public FootballPlayer GetFootballPlayerById(int id)
        {
            return Data.Find(players => players.id == id);
        }
        public FootballPlayer Add(FootballPlayer newFootballPlayer)
        {
            newFootballPlayer.id = _nextId++;
            Data.Add(newFootballPlayer);
            return newFootballPlayer;
        }
        public FootballPlayer Delete(int id)
        {
            FootballPlayer footballPlayers = Data.Find(players => players.id == id);
            if(footballPlayers == null) return null;
            Data.Remove(footballPlayers);
            return footballPlayers;
        }
        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer footballPlayers = Data.Find(players => players.id == id);
            if (footballPlayers == null) return null;
            footballPlayers.Name = updates.Name;
            footballPlayers.Age = updates.Age;
            footballPlayers.ShirtNumber = updates.ShirtNumber;
            return footballPlayers;
        }
    }
}
