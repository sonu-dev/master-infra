namespace Master.Core.MassTransit.Testing
{
    public interface CreateOrderMessage
    {
        int OrderId { get; }
        string Value { get; }
        bool IsOrderCreated { get; }
    }

    public interface SubmittedOrderMessage
    {
        int OrderId { get; }
        string Value { get; }
        bool IsOrderCreated { get; }
    }
}
