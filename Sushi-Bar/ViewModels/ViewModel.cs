using Sushi_Bar.Models;

public class OrderViewModel
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
}

public class OrderItemViewModel
{
    public int DishId { get; set; }
    public int Quantity { get; set; }
    public string DishName { get; set; }
}

public class OrderEditViewModel : OrderViewModel
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}