using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDataViewModdel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModal>().ReverseMap();
            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();  
            CreateMap<OrderItem, OrderItemViewModel>().ReverseMap();
            CreateMap<FavoriteProduct, FavoriteProductViewModel>().ReverseMap();
            CreateMap<Order, OrderProfile>();
            CreateMap<CartItem, OrderItemViewModel>().ReverseMap();
            CreateMap<UserInfo, UserInfoViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>();

            CreateMap<OrderViewModel, Order>()
                .ForMember(x => x.DateTime, op => op.MapFrom(o => o.DateTime != new DateTime() ? o.DateTime : DateTime.Now))
                .ForMember(x => x.Status, op => op.MapFrom(o => o.Status != 0 ? o.Status : OrderStatuses.Created))
                .ForMember(x => x.UserInfo, op => op.MapFrom(o => o.UserInfo)); 
        }
    }
}
