namespace InfraFlow.Core.Domain.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true)]
public class ExcludeFromProcessingAttribute : Attribute
{
    
}

