using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfraFlow.Core.EntityFramework.Models;

public class ExtraPropertyDictionaryConverter : ValueConverter<ExtraPropertyDictionary, string>
{
    public ExtraPropertyDictionaryConverter() : base(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        v => JsonSerializer.Deserialize<ExtraPropertyDictionary>(v, (JsonSerializerOptions?)null) ?? new ExtraPropertyDictionary())
    { }
}