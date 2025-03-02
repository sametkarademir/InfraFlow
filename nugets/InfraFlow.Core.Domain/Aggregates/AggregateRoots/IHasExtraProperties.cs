using System.Text.Json;

namespace InfraFlow.Core.Domain.Aggregates.AggregateRoots;

public interface IHasExtraProperties
{
    ExtraPropertyDictionary? ExtraProperties { get; }
}

[Serializable]
public class ExtraPropertyDictionary : Dictionary<string, object?>
{
    public ExtraPropertyDictionary() { }
    public ExtraPropertyDictionary(IDictionary<string, object?> dictionary) : base(dictionary) { }
    
    public T? GetProperty<T>(string key)
    {
        if (TryGetValue(key, out var value) && value is T typedValue)
        {
            return typedValue;
        }
        return default;
    }
    public void SetProperty<T>(string key, T value)
    {
        this[key] = value;
    }
}