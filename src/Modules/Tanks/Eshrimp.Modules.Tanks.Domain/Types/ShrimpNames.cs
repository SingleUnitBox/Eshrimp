using System.Reflection;

namespace Eshrimp.Modules.Tanks.Domain.Types
{
    internal static class ShrimpNames
    {
        public const string TaiwanBee = nameof(TaiwanBee);
        public const string RedRuby = nameof(RedRuby);
        public const string ZebraPinto = nameof(ZebraPinto);
        public const string GalaxyPinto = nameof(GalaxyPinto);
        public const string PureWhiteLine = nameof(PureWhiteLine);
        public const string PureRedLine = nameof(PureRedLine);
        public const string PureBlackLine = nameof(PureBlackLine);
        public const string BlueBolt = nameof(BlueBolt);
        public const string RedBolt = nameof(RedBolt);
        public const string YellowKingKong = nameof(YellowKingKong);

        public static IEnumerable<string> GetShrimpNames()
            => typeof(ShrimpNames)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(field => field.IsLiteral && !field.IsInitOnly)
                .Select(field => field.GetValue(null).ToString())
                .ToList();
    }
}
