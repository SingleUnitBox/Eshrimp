using System.Reflection;

namespace Eshrimp.Modules.Tanks.Domain.Types
{
    internal static class SpeciesTypes
    {
        public const string Caridina = nameof(Caridina);
        public const string Neocaridina = nameof(Neocaridina);
        public const string Sulawesi = nameof(Sulawesi);

        public static IEnumerable<string> GetTypes()
        {
            var speciesTypes = typeof(SpeciesTypes)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly)
                .Select(field => field.GetValue(null).ToString().ToLowerInvariant())
                .ToList();

            return speciesTypes;
        }
    }
}
