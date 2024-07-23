using Eshrimp.Modules.Tanks.Domain.ValueObjects;
using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.Entities
{
    public class Shrimp
    {
        public ShrimpId Id { get; private set; }
        public ShrimpName Name { get; private set; }
        public Species Species { get; private set; }
        public Tank Tank { get; private set; }

        private Shrimp()
        {
            
        }

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
