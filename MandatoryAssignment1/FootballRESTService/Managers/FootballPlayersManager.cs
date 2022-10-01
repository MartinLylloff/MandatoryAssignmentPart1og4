using MandatoryAssignment1;

namespace FootballRESTService.Managers
{
    public class FootballPlayersManager
    {

        private static int _nextId = 1;
        private static List<FootballPlayer> _players = new List<FootballPlayer>()
        {
            new FootballPlayer(){Id = _nextId++, Name = "Martin", Age = 29, ShirtNumber = 11 },
            new FootballPlayer(){Id = _nextId++, Name = "Victor", Age = 25, ShirtNumber = 1 },
            new FootballPlayer(){Id = _nextId++, Name = "Andreas", Age = 26, ShirtNumber = 8 },
            new FootballPlayer(){Id = _nextId++, Name = "Frederik", Age = 24, ShirtNumber = 5 }
        };

        public List<FootballPlayer> GetAll()
        {
            return _players;
        }

        public FootballPlayer GetById(int id)
        {
            return _players.Find(Player => Player.Id == id);
        }

        public FootballPlayer Add(FootballPlayer player)
        {
            player.Id = _nextId++;
            _players.Add(player);
            return player;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer? footballPlayer = GetById(id);
            if (footballPlayer == null) return null;
            _players.Remove(footballPlayer);
            return footballPlayer;
        }

        public FootballPlayer Update(int id, FootballPlayer player)
        {
           
            FootballPlayer footballPlayer = GetById(id);
            footballPlayer.Name = player.Name;
            footballPlayer.ShirtNumber = player.ShirtNumber;
            footballPlayer.Age = player.Age;
            return footballPlayer;
        }
    }
}
