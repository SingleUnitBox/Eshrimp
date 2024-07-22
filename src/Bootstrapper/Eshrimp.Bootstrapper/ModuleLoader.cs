using Eshrimp.Shared.Abstractions.Modules;
using System.Reflection;

namespace Eshrimp.Bootstrapper
{
    internal static class ModuleLoader
    {
        public static IList<Assembly> LoadAssemblies(IConfiguration configuration)
        {
            const string modulePart = "Eshrimp.Modules.";
            var assemblies = AppDomain.CurrentDomain
             .GetAssemblies()
             .OrderByDescending(x => x.Location)
             .ToList();

            var locations = assemblies
                .Where(a => !a.IsDynamic)
                .Select(a => a.Location)
                .ToArray();

            var files = Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(l => !locations.Contains(l, StringComparer.InvariantCultureIgnoreCase))
                .ToList();

            var disabledModules = new List<string>();
            foreach (var file in files)
            {
                if (!file.Contains(modulePart))
                {
                    continue;
                }

                var moduleName = file.Split(modulePart)[1].Split('.')[0];
                var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");
                if (!enabled)
                {
                    disabledModules.Add(file);
                }
            }

            foreach (var disabledModule in disabledModules)
            {
                files.Remove(disabledModule);
            }

            files.ForEach(f => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(f))));

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
