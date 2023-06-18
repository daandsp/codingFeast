using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            // Customer mappings

                // API -> Outside (Client)
                Mapper.CreateMap<Customer, CustomerDto>();

                // API <- Inside (server)
                Mapper.CreateMap<CustomerDto, Customer>()
                    .ForMember(c => c.Id, opt => opt.Ignore());



            // Movie mappings

                // API -> Outside (Client)
                Mapper.CreateMap<Movie, MovieDto>();

                // API <- Inside (Server)
                Mapper.CreateMap<MovieDto, Movie>()
                    .ForMember(c => c.Id, opt => opt.Ignore());



            // NewRental mappings

                // API -> Outside (Client)
                Mapper.CreateMap<Rental, NewRentalDto>();

                // API <- Inside (Server)
                Mapper.CreateMap<NewRentalDto, Rental>()
                    .ForMember(c => c.Id, opt => opt.Ignore());


        }
    }
}
