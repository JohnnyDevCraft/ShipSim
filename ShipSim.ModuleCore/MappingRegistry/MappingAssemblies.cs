using System.Reflection;

namespace ShipSim.ModuleCore.MappingRegistry;

public static class MappingAssemblies
{
    private static List<Assembly> _assemblies = new();

    public static void AddAssembly(Assembly assembly)
    {
        _assemblies.Add(assembly);
    }

    public static IEnumerable<Assembly> GetAssemblies()
    {
        return _assemblies;
    }
}