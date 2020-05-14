namespace BLL
{
    using System.Collections.Generic;

    using AutoMapper;

    public static class ObjectMapper<TFrom, TTo>
    {
        public static TTo Map(TFrom fromModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>()).CreateMapper();
            return mapper.Map<TFrom, TTo>(fromModel);
        }

        public static IEnumerable<TTo> MapList(IEnumerable<TFrom> fromModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>()).CreateMapper();
            return mapper.Map<IEnumerable<TFrom>, IEnumerable<TTo>>(fromModel);
        }
    }
}