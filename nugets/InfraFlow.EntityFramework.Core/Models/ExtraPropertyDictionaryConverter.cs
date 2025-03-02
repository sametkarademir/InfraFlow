using System.Text.Json;
using InfraFlow.Domain.Core.Aggregates.AggregateRoots;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfraFlow.EntityFramework.Core.Models;

public class ExtraPropertyDictionaryConverter : ValueConverter<ExtraPropertyDictionary, string>
{
    public ExtraPropertyDictionaryConverter() : base(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        v => JsonSerializer.Deserialize<ExtraPropertyDictionary>(v, (JsonSerializerOptions?)null) ?? new ExtraPropertyDictionary())
    { }
}