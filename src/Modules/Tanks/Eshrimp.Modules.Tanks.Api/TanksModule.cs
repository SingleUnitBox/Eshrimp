using Eshrimp.Shared.Abstractions.Modules;

namespace Eshrimp.Modules.Tanks.Api
{
    public class TanksModule : IModule
    {
        public const string BasePath = "tanks-module";
        public string Name => "Tanks";

        public string Path => BasePath;

        public void RegisterModule()
        {
            
        }

        public void UseModule()
        {
            
        }
    }
}
