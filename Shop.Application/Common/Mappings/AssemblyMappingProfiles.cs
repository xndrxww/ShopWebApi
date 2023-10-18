using AutoMapper;
using System.Reflection;

namespace Shop.Application.Common.Mappings
{
    public class AssemblyMappingProfiles : Profile
    {
        public AssemblyMappingProfiles(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly) 
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && 
                    i.GetGenericTypeDefinition() == typeof(IMap<>)))
                .ToList();

            foreach (var type in types) 
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
