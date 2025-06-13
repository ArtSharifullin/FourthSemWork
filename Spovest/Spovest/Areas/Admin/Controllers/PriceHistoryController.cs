using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spovest.Application.Features.Price.Command.Create;
using Spovest.Application.Features.Price.Command.Delete;
using Spovest.Application.Features.Price.Command.Update;
using Spovest.Application.Features.Price.Query.GetAllPrices;
using Spovest.Application.Features.Price.Query.GetPriceById;
using Spovest.Areas.Admin.Models.PriceHistory;

namespace Spovest.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriceHistoryController : Controller
    {
        private readonly IMediator _mediator;

        public PriceHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "ManagerPolicy")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllPricesQuery();
            var prices = await _mediator.Send(query);
            var viewModel = new PriceHistoryVM
            {
                Prices = prices.OrderByDescending(x=>x.Timestamp)
            };

            return View(viewModel);
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Add()
        {
            return View(new PricesFormVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Add(PricesFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new CreatePriceCommand
            {
                playerId = model.PlayerId,
                pprice = model.Purchase_Price.Value,
                sprice = model.Sale_Price.Value
            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(int id)
        {
            var query = new GetPriceByIdQuery(id);
            var price = await _mediator.Send(query);

            var model = new PricesFormVM
            {
                Id = price.Id,
                PlayerId = price.PlayerId,
                Purchase_Price = price.Purchase_price,
                Sale_Price = price.Sale_price,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Update(PricesFormVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new UpdatePriceCommand
            {
                id = model.Id.Value,
                playerId = model.PlayerId,
                pprice = model.Purchase_Price.Value,
                sprice= model.Sale_Price.Value

            };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Remove(int id)
        {
            var query = new GetPriceByIdQuery(id);
            var price = await _mediator.Send(query);

            var model = new PricesFormVM
            {
                Id = price.Id,
                PlayerId = price.PlayerId,
                Purchase_Price = price.Purchase_price,
                Sale_Price = price.Sale_price,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var command = new DeletePriceCommand { id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
} 