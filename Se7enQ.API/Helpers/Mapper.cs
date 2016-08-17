using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Se7enQ.API.Helpers
{
    public class Mapper
    {
        public static TDestination AutoMap<TSource, TDestination>(TSource source)
           where TDestination : class
           where TSource : class
        {
            var config = new MapperConfiguration(c => c.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            var result = mapper.Map<TDestination>(source);

            return result;
        }
    }
}