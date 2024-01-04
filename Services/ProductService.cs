using AppMvc.Models;
using System.Collections.Generic;

namespace AppMvc.Services
{
    public class ProductService:  List<ProductModel>
    {
        public ProductService(){
            this.AddRange(new ProductModel[]{
                new ProductModel() { Id =1, Name ="Iphone", Price = 1000},
                new ProductModel() { Id =2, Name ="Iphone", Price = 1000},
                new ProductModel() { Id =3, Name ="Iphone", Price = 1000},
                new ProductModel() { Id =4, Name ="Iphone", Price = 1000},
                new ProductModel() { Id =5, Name ="Iphone", Price = 1000},
            });
        }
    }
}