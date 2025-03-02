namespace InfraFlow.Domain.Core.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true)]
public class ExcludeFromProcessingAttribute : Attribute
{
    
}

