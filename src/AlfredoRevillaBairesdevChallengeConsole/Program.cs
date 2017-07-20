using System.Collections.Generic;
using System.IO;

namespace AlfredoRevillaBairesdevChallengeConsole
{
    public class Entity
    {
        public string Country { get; set; }
        public string CurrentRole { get; set; }
        public string Industry { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int NumberOfConnections { get; set; }
        public int NumberOfRecommendations { get; set; }
        public long PersonId { get; set; }
    }

    public class EntityReader
    {
        private Mapper mapper;

        public EntityReader(Mapper mapper)
        {
            this.mapper = mapper;
        }


    }

    public class Mapper
    {
        public IEnumerable<Entity> Read(string[] lines)
        {
            foreach (var item in lines)
            {
                yield return Read(item);
            }
        }

        public Entity Read(string line)
        {
            var i = 0;
            var values = line.Split('|');
            return new Entity
            {
                PersonId = long.Parse(values[i++]),
                Name = values[i++],
                LastName = values[i++],
                CurrentRole = values[i++],
                Country = values[i++],
                Industry = values[i++],
                NumberOfRecommendations = int.Parse(values[i++]),
                NumberOfConnections = int.Parse(values[i++])
            };
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Mapper mapper = new Mapper();
            var value = mapper.Read(File.ReadAllLines("people.in"));

        }
    }
}