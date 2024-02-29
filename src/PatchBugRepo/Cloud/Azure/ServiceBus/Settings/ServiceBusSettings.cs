namespace PatchBugRepo.Cloud.Azure.ServiceBus.Settings;

public class ServiceBusSettings
{
    public string ConnectionString { get; set; } = string.Empty;

    public TopicSettings TopicSettings { get; set; } = new();
}

public class TopicSettings
{
    public string Example { get; set; } = string.Empty;
}
