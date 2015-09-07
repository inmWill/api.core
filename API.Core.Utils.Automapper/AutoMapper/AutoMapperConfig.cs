using AutoMapper;

namespace API.Core.Utils.Automapper.AutoMapper
{
    public abstract class AutoMapperConfig
    {
        public abstract void InitMapper();


        public static IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            var configHelper = new ConfigHelper();
            return configHelper.CreateMap<TSource, TDestination>();
        }
    }

    internal class ConfigHelper
    {
        public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>()
        {
            if (!DoesMapAlreadyExist<TSource, TDestination>())
            {
                return Mapper.CreateMap<TSource, TDestination>();
            }
            return null;
        }

        public bool DoesMapAlreadyExist<TSource, TDestination>()
        {
            return (Mapper.FindTypeMapFor<TSource, TDestination>() != null);
        }
    }
}
