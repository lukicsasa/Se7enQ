using AutoMapper;
using Se7enQ.API.Models;
using Se7enQ.API.Models.User;
using Se7enQ.Entities;
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

        public static UserModel Map(User user)
        {
            if (user == null) return null;

            var userModel = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                ImageUrl = user.ImageUrl + "?t=" + DateTime.UtcNow.Ticks,
                DateCreated = user.DateCreated,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
            };
            return userModel;
        }
    }
}