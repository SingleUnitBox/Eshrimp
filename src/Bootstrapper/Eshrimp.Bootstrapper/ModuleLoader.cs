using Eshrimp.Shared.Abstractions.Modules;
using System.Reflection;

namespace Eshrimp.Bootstrapper
{
    internal static class ModuleLoader
    {
        public static IList<Assembly> LoadAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .ToList();
            var locations = assemblies.Where(l => !l.IsDynamic)
                .Select(x => x.Location)
                .ToArray();
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

            return assemblies;
        }

        public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        {
            var modules = assemblies
                .SelectMany(t => t.GetTypes())
                .Where(m => typeof(IModule).IsAssignableFrom(m) && !m.IsInterface)
                .OrderBy(m => m.Name)
                .Select(Activator.CreateInstance)
                .Cast<IModule>()
                .ToList();

            return modules;
        }
    }
}
