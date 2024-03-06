using Playtypuces.Models;

namespace Playtypuces.Data
{
    public class FakeDb
    {
        private List<Playtypuce> _playtypuces;
        private int _lastId = 0;

        public FakeDb()
        {
            _playtypuces = new List<Playtypuce>()
            {
        new Playtypuce { Id = ++_lastId, Name = "Tigrou", Age = 3, Colour = "Orange", Gender = "Mâle" },
        new Playtypuce { Id = ++_lastId, Name = "Minou", Age = 2, Colour = "Noir", Gender = "Femelle" },
        new Playtypuce { Id = ++_lastId, Name = "Simba", Age = 4, Colour = "Doré", Gender = "Mâle" },
        new Playtypuce { Id = ++_lastId, Name = "Misty", Age = 1, Colour = "Gris", Gender = "Femelle" },
        new Playtypuce { Id = ++_lastId, Name = "Whiskers", Age = 2, Colour = "Rayé", Gender = "Mâle" },
    };
        }
        public List<Playtypuce> GetAll()
        {
            return _playtypuces;
        }

        public Playtypuce? GetById(int id)
        {
            return _playtypuces.FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Playtypuce playtypuce)
        {
            playtypuce.Id = ++_lastId;
            _playtypuces.Add(playtypuce);
            return true; 
        }

        public bool Edit(Playtypuce playtypuce)
        {
            var playtypuceFromDb = GetById(playtypuce.Id);

            if (playtypuceFromDb == null)
                return false;

            playtypuceFromDb.Name = playtypuce.Name;
            playtypuceFromDb.Age = playtypuce.Age;
            playtypuceFromDb.Colour = playtypuce.Colour;
            playtypuceFromDb.Gender = playtypuce.Gender;

            return true;
        }

        public bool Delete(int id)
        {
            var playtypuce = GetById(id);

            if (playtypuce == null)
                return false;

            _playtypuces.Remove(playtypuce);

            return true;
        }
    }
}
