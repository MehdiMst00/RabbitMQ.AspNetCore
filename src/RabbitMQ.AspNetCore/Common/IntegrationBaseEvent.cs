namespace RabbitMQ.AspNetCore.Common;

public class IntegrationBaseEvent
{
    public IntegrationBaseEvent()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
    }

    public IntegrationBaseEvent(Guid id, DateTime creationTime)
    {
        Id = id;
        CreationTime = creationTime;
    }

    public Guid Id { get; private set; }

    public DateTime CreationTime { get; private set; }
}