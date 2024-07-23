using Eshrimp.Modules.Tanks.Domain.ValueObjects;

namespace Eshrimp.Modules.Tanks.Domain.Entities
{
    public class Shrimp
    {
        public ShrimpId Id { get; private set; }
        public ShrimpName Name { get; private set; }
        public Species Species { get; private set; }

        private Shrimp(Guid id)
        {
            Id = id;
        }

        internal void ChangeShrimpName(string name)
        {
            Name = name;
        }

        internal void ChangeSpecies(string species)
        {
            Species = species;
        }

        public static Shrimp Create(Guid id, string name, string species)
        {
            var shrimp = new Shrimp(id);
            shrimp.ChangeShrimpName(name);
            shrimp.ChangeSpecies(species);

            return shrimp;
        }
    }
}
