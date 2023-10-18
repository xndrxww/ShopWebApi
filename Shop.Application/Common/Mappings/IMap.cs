using AutoMapper;

namespace Shop.Application.Common.Mappings
{
    public interface IMap<T>
    {
        private void Mapping(Profile profile)
        {
            profile.CreateMap(typeof(T), GetType());
        }

    }
}
