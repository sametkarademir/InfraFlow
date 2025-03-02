using Autofac;
using Autofac.Extensions.DependencyInjection;
using InfraFlow.Application;
using InfraFlow.EntityFramework.AuditLog.DependencyInjection;
using InfraFlow.EntityFramework.ExceptionLog.DependencyInjection;
using InfraFlow.EntityFramework.HttpRequestLog.DependencyInjection;
using InfraFlow.EntityFramework.Identity.DependencyInjection;
using InfraFlow.EntityFramework.Snapshot.DependencyInjection;
using InfraFlow.Infrastructure;
using InfraFlow.Infrastructure.Contexts;
using InfraFlow.Web.Helpers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

#region AddCors
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", corsPolicyBuilder =>
        corsPolicyBuilder.SetIsOriginAllowedToAllowWildcardSubdomains()
            .WithOrigins(allowedOrigins ?? new string[] { builder.Configuration["AllowedHosts"] ?? "https://localhost:5001" })
            .AllowAnyHeader()
            .AllowAnyMethod());
});
#endregion

builder.Services.AddMemoryCache();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new InfrastructureModule());
    containerBuilder.RegisterModule(new ApplicationModule());
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddEntityFrameworkAuditLogServices<ApplicationDbContext>();
builder.Services.AddEntityFrameworkExceptionLogServices<ApplicationDbContext>();
builder.Services.AddEntityFrameworkHttpRequestLogServices<ApplicationDbContext>();
builder.Services.AddEntityFrameworkIdentityServices<ApplicationDbContext>();
builder.Services.AddEntityFrameworkSnapshotServices<ApplicationDbContext>();

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddApiVersioning(options =>
//     {
//         options.DefaultApiVersion = new ApiVersion(1);
//         options.ReportApiVersions = true;
//         options.AssumeDefaultVersionWhenUnspecified = true;
//         options.ApiVersionReader = ApiVersionReader.Combine(
//             new UrlSegmentApiVersionReader(),
//             new HeaderApiVersionReader("X-Api-Version"));
//     })
//     .AddApiExplorer(options =>
//     {
//         options.GroupNameFormat = "'v'V";
//         options.SubstituteApiVersionInUrl = true;
//     });
builder.Services.AddSwaggerGen(opt => {
    opt.AddSecurityDefinition(
        name: "Bearer",
        securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
                "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer YOUR_TOKEN\". \r\n\r\n"
                + "`Enter your token in the text input below.`"
        }
    );
    opt.OperationFilter<BearerSecurityRequirementOperationFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors("MyCorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();