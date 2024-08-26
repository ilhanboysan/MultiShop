namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommands
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
