using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public interface IAppVerificationCodeRepository : IRepository<AppVerificationCode, Guid>
{
    
}