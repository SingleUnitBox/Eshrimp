namespace Eshrimp.Shared.Infrastructure.Modules
{
    public interface IModuleRegistry
    {
        void AddBroadcastRegistration(Type requestType, Func<object, Task> action);
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);
    }
}
