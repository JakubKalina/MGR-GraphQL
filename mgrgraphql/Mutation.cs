using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using mgrapi.Dtos.Post;
using mgrapi.Dtos.User;
using mgrapi.Interfaces;
using mgrapi.Models;
using mgrapi.Services;
using mgrgraphql.Dtos.Category;

namespace mgrgraphql
{
    public class Mutation
    {


        // Tworzenie nowego zasobu
        public int CreateCategory([Service] ICategoriesService categoriesService, CreateCategoryDto category)
        {

            var id = categoriesService.Create(category);

            return id;            
        }

        public int CreateUser([Service] IUsersService usersService, CreateUserDto user)
        {

            var id = usersService.Create(user);

            return id;            
        }

        public int CreatePost([Service] IPostsService postsService, CreatePostDto post)
        {

            var id = postsService.Create(post);

            return id;            
        }
        

        // Edycja istniejącego zasobu
        public bool UpdateCategory([Service] ICategoriesService categoriesService, int categoryId, UpdateCategoryDto category)
        {
            var result = categoriesService.Update(categoryId, category);

            return result;            
        }

        public bool UpdateUser([Service] IUsersService usersService, int userId, UpdateUserDto user)
        {
            var result = usersService.Update(userId, user);

            return result;            
        }

        public bool UpdatePost([Service] IPostsService postsService, int postId, UpdatePostDto post)
        {
            var result = postsService.Update(postId, post);

            return result;            
        }


        // Usuwanie istniejącego zasobu
        public bool DeleteCategory([Service] ICategoriesService categoriesService, int categoryId)
        {

            var result = categoriesService.Delete(categoryId);

            return result;            
        }

        public bool DeleteUser([Service] IUsersService usersService, int userId)
        {

            var result = usersService.Delete(userId);

            return result;            
        }

        public bool DeletePost([Service] IPostsService postsService, int postId)
        {

            var result = postsService.Delete(postId);

            return result;            
        }

    }
}