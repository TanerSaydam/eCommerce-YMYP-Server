using AutoMapper;
using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Application.Features.Categories.UpdateCategory;
using eCommerceServer.Application.Features.Companies.CreateCompany;
using eCommerceServer.Application.Features.Companies.UpdateCompany;
using eCommerceServer.Domain.Categories;
using eCommerceServer.Domain.Companies;
using eCommerceServer.Domain.Shared;

namespace eCommerceServer.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>().ForMember(x => x.Name, options =>
        {
            options.MapFrom(y => new Name(y.Name));
        });

        CreateMap<UpdateCategoryCommand, Category>().ForMember(x => x.Name, options =>
        {
            options.MapFrom(y => new Name(y.Name));
        });

        CreateMap<CreateCompanyCommand, Company>()
            .ForMember(p => p.Name, options =>
        {
            options.MapFrom(p => new Name(p.Name));
        })
            .ForMember(p => p.TaxNumber, options =>
        {
            options.MapFrom(p => new TaxNumber(p.TaxNumber));
        })
            .ForMember(p => p.TaxDepartment, options =>
            {
                options.MapFrom(p => TaxDepartmentSmartEnum.FromValue(p.TaxDepartmentValue));
            })
            .ForMember(p => p.Address, options =>
            {
                options.MapFrom(p => new Address(p.Country, p.City, p.Town, p.Street, p.FullAddress));
            });

        CreateMap<UpdateCompanyCommand, Company>()
            .ForMember(p => p.Name, options =>
            {
                options.MapFrom(p => new Name(p.Name));
            })
            .ForMember(p => p.TaxDepartment, options =>
            {
                options.MapFrom(p => TaxDepartmentSmartEnum.FromValue(p.TaxDepartmentValue));
            })
            .ForMember(p => p.TaxNumber, options =>
            {
                options.MapFrom(p => new TaxNumber(p.TaxNumber));
            })
            .ForMember(p => p.Address, options =>
            {
                options.MapFrom(p => new Address(p.Country, p.City, p.Town, p.Street, p.FullAddress));
            });


    }
}
