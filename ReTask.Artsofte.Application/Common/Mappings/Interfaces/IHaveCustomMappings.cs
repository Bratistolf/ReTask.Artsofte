using AutoMapper;

namespace ReTask.Artsofte.Application.Common.Mappings.Interfaces
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}
