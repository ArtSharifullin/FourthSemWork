using Spovest.Application.Features.Posts.Query;

namespace Spovest.Areas.Admin.Models.Posts
{
    public class PostsVM
    {
        public IEnumerable<PostsDto> Posts { get; set; }
    }
}
