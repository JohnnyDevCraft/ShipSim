using System.Reflection;

namespace ShipSim.ModuleCore.MediatorManager;

public static class Mediators
{
    private static List<Assembly> _assemblies = new();
    
    public static void AddAssemblies(params Assembly[] assemblies)
    {
        _assemblies.AddRange(assemblies);
    }
    
    public static void AddAssembly(Assembly assembly)
    {
        _assemblies.Add(assembly);
    }
    
    public static List<Assembly> GetAssemblies()
    {
        return _assemblies;
    }
}