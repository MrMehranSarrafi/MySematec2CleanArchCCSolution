namespace MyCleanarchGeneral.Domain.Entities;

public class Order
{
    public int Id { get; private set; }
    public string CustomerName { get; private set; }
    public decimal TotalAmount { get; private set; }
    public DateTime CreatedAt    { get; private set; }

    public bool IsPaid { get; private set; }

    public Order(string customerName, decimal totalAmount)
    {
        CustomerName = customerName;
        TotalAmount = totalAmount;
        CreatedAt = DateTime.UtcNow;
        IsPaid = false;
    }
    public void MarkAsPaid()
    {
        if (IsPaid)
            throw new InvalidOperationException("Order already paid");
        IsPaid = true;
    }

}
