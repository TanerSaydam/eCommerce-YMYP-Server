﻿using AutoMapper;
using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Domain.Categories;

namespace eCommerceServer.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>().ForMember(x=> x.Name, options =>
        {
            options.MapFrom(y=> new Name(y.Name));
        });
    }
}