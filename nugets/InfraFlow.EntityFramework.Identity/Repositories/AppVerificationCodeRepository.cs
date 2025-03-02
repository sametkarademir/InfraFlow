using InfraFlow.Domain.Identity.Entities;
using InfraFlow.EntityFramework.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InfraFlow.EntityFramework.Identity.Repositories;

public class AppVerificationCodeRepository<TContext> : EfRepositoryBase<AppVerificationCode, Guid, TContext>, IAppVerificationCodeRepository where TContext : DbContext
{
    public AppVerificationCodeRepository(TContext context) : base(context)
    {
        
    }
}