using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Subscriptions;
using mgrapi.Dtos.Category;
using mgrapi.Dtos.Post;
using mgrapi.Dtos.User;
using mgrapi.Interfaces;
using mgrapi.Models;
using mgrapi.Services;

namespace mgrgraphql
{
    public class Query
    {

        // Get All resources
        public GetAllCategoriesDto GetAllCategories([Service] ICategoriesService categoriesService) =>
            categoriesService.GetAll();

        public GetAllUsersDto GetAllUsers([Service] IUsersService usersService) =>
            usersService.GetAll();

        public GetAllPostsDto GetAllPosts([Service] IPostsService postsService) =>
            postsService.GetAll();


        // Get Resource By Id
        public GetCategoryByIdDto GetCategoryById([Service] ICategoriesService categoriesService, int id)
        {
            GetCategoryByIdDto category = categoriesService.Get(id);
            return category;
        }         

        public GetUserByIdDto GetUserById([Service] IUsersService usersService, int id)
        {
            GetUserByIdDto user = usersService.Get(id);
            return user;
        }     

        public GetPostByIdDto GetPostById([Service] IPostsService postsService, int id)
        {
            GetPostByIdDto post = postsService.Get(id);
            return post;
        }     
    }
}