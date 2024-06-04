using eCommerceServer.Application.Features.Categories.CreateCategory;
using eCommerceServer.Application.Features.Categories.GetAllCategory;
using eCommerceServer.Application.Features.Categories.RemoveCategory;
using eCommerceServer.Application.Features.Categories.UpdateCategory;
using eCommerceServer.Application.Features.Companies.CreateCompany;
using eCommerceServer.Application.Features.Companies.DeleteCompanyById;
using eCommerceServer.Application.Features.Companies.UpdateCompany;

namespace eCommerceServer.WebAPI.Utilities;

public sealed record ApiMethod(string ControllerName, string ActionName, Type Body)
{
    public static List<ApiMethod> ApiMethods { get; set; } = new()
        {
            new("Categories","Create",typeof(CreateCategoryCommand)),
            new("Categories","Update",typeof(UpdateCategoryCommand)),
            new("Categories","DeleteById",typeof(DeleteCategoryByIdCommand)),
            new("Categories","GetAll",typeof(GetAllCategoryQuery)),

            new("Companies","Create",typeof(CreateCompanyCommand)),
            new("Companies","Update",typeof(UpdateCompanyCommand)),
            new("Companies","DeleteById",typeof(DeleteCompanyByIdCommand)),
            //new("Categories","GetAll",typeof(GetAllCategoryQuery)),
        };
}


