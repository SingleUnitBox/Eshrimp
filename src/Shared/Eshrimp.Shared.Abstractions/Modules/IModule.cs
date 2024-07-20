namespace Eshrimp.Shared.Abstractions.Modules
{
    public interface IModule
    {
        string Name { get; }
        string Path { get; }
        void RegisterModule();
        void UseModule();
    }
}
