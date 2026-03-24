using AIIMS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIIMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // ========================
        // WRITE APIs
        // ========================

        [HttpPost("stock-in")]
        public async Task<IActionResult> StockIn(StockInRequest request)
        {
            await _inventoryService.StockIn(
                request.ItemId,
                request.LocationId,
                request.Quantity,
                request.UserId
            );

            return Ok("Stock added successfully");
        }

        [HttpPost("stock-out")]
        public async Task<IActionResult> StockOut(StockOutRequest request)
        {
            await _inventoryService.StockOut(
                request.ItemId,
                request.LocationId,
                request.Quantity,
                request.UserId
            );

            return Ok("Stock removed successfully");
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(TransferRequest request)
        {
            await _inventoryService.TransferStock(
                request.ItemId,
                request.FromLocationId,
                request.ToLocationId,
                request.Quantity,
                request.UserId
            );

            return Ok("Stock transferred successfully");
        }

        // ========================
        // READ APIs (NEW)
        // ========================

        [HttpGet("items")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _inventoryService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("item/{itemId}")]
        public async Task<IActionResult> GetStockByItem(int itemId)
        {
            var stock = await _inventoryService.GetStockByItem(itemId);
            return Ok(stock);
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _inventoryService.GetAllTransactions();
            return Ok(transactions);
        }
    }

    // ========================
    // REQUEST MODELS
    // ========================

    public class StockInRequest
    {
        public int ItemId { get; set; }
        public int LocationId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }

    public class StockOutRequest
    {
        public int ItemId { get; set; }
        public int LocationId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }

    public class TransferRequest
    {
        public int ItemId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
    }
}