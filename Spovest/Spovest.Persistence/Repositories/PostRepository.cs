using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Spovest.Application.Interfaces.Repositories;
using Spovest.Domain.Entities;

namespace Spovest.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IGenericRepository<Post> _repository;

        public PostRepository(IGenericRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsByUserIdAsync(int userId)
        {
            return await _repository.Entities.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> AddPostAsync(int userId, string title, string content, string img)
        {
            var post = new Post
            {
                UserId = userId,
                Title = title,
                Content = content,
                Img = img 
            };
            await _repository.AddAsync(post);
            return true;
        }
        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await GetPostByIdAsync(id);
            await _repository.DeleteAsync(post);
            return true;
        }
        public async Task<bool> UpdatePostAsync(int id, string title, string content, string img)
        {
            var existingPost = await GetPostByIdAsync(id);
            if (existingPost == null) { return false; }
            existingPost.Title = title ?? existingPost.Title;
            existingPost.Content = content ?? existingPost.Content;
            existingPost.Img = img ?? existingPost.Img;
            await _repository.UpdateAsync(existingPost);
            return true;

        }
    }
}
