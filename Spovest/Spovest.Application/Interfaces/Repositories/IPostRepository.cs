using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spovest.Domain.Entities;

namespace Spovest.Application.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int userId);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<bool> AddPostAsync(int userId, string title, string content, string img);
        Task<bool> DeletePostAsync(int id);
        Task<bool> UpdatePostAsync(int id, string title, string content, string img);



    }
}
