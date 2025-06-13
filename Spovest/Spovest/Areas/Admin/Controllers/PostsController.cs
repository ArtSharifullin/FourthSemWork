using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.Posts.Query.GetAllPosts;
using Spovest.Application.Features.Posts.Query.GetPostById;
using Spovest.Areas.Admin.Models.Players;
using Spovest.Areas.Admin.Models.Posts;
using Spovest.Application.Features.Posts.Command.Create;
using Spovest.Application.Features.Posts.Command.Update;
using Spovest.Application.Features.Posts.Command.Delete;
using Microsoft.AspNetCore.Authorization;

namespace Spovest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllPostsQuery();
            var posts = await _mediator.Send(query);
            var postsVM = new PostsVM
            {
                Posts = posts
            };

            return View(postsVM);
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Add()
        {
            return View(new PostFormVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Add(PostFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new CreatePostCommand
            {
                UserId = model.UserId,
                Title = model.Title,
                Content = model.Content,
                Img = model.Img
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetPostByIdQuery(id);
            var post = await _mediator.Send(query);

            var model = new PostFormVM
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Img = post.Img
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(PostFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new UpdatePostCommand
            {
                Id = model.Id.Value,
                Title = model.Title,
                Content = model.Content,
                Img = model.Img
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Remove(int id)
        {
            var query = new GetPostByIdQuery(id);
            var post = await _mediator.Send(query);

            var model = new PostFormVM
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Img = post.Img
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var command = new DeletePostCommand { id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}