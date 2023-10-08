using AutoMapper;
using Path.DTO;
using Path.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, SingInDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>()
                .ForMember(
                    var=>var.IdCategoryNavigation,
                    option=>option.Ignore()
                );

            CreateMap<SaleDetail, SaleDetailDTO>();
            CreateMap<SaleDetailDTO, SaleDetail>();

            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>();
        }
    }
}
