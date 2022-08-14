using System.Reflection;
using System.Text.Json.Serialization;
using GestioneSagre.Core.Customizations.Extensions;
using GestioneSagre.Core.Models.Options;
using GestioneSagre.Domain.Services.Application.Interfaces;
using GestioneSagre.Domain.Services.Application.Internal;
using GestioneSagre.Domain.Services.Application.Public;
using GestioneSagre.Domain.Services.Infrastructure;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

namespace GestioneSagre.Web.Server;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                // Info su: https://github.com/marcominerva/MyWebApiToolbox
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });

        services.AddRazorPages();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
        });

        services.AddDbContextPool<GestioneSagreDbContext>(optionBuilder =>
        {
            var connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");

            optionBuilder.UseSqlite(connectionString, options =>
            {
                // Info su: https://docs.microsoft.com/it-it/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli

                // To perform a new migration you need:
                // 1. Open the Package Manager Console panel
                // 2. In the Default Project drop-down menu make sure that the selected project is GestioneSagre.Web.Server.
                // 3. Run the command Add-Migration NAME-MIGRATION -Project GestioneSagre.Web.Migrations where NAME-MIGRATION represents the name of the migration to create (example: InitialMigration)
                // 4. Finally run the command Update-Database -Project GestioneSagre.Web.Migrations
                options.MigrationsAssembly("GestioneSagre.Web.Migrations");
            });
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        services.AddSwaggerServices(Configuration, xmlPath);

        // Services TRANSIENT - GestioneSagre.Domain.Services.Application.Internal
        services.Scan(scan => scan.FromAssemblyOf<EfCoreInternalService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        // Services TRANSIENT - GestioneSagre.Domain.Services.Application.Public
        services.Scan(scan => scan.FromAssemblyOf<EfCoreVersioneService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        // Services SINGLETON
        services.AddSingleton<IInternalService, EfCoreInternalService>();       
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();      
        //services.AddSingleton<ITransactionLogger, LocalTransactionLogger>();    

        // Options
        services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
        services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        if (env.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }

        var enableSwagger = Configuration.GetSection("Swagger").GetValue<bool>("enabled");

        if (enableSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestione Sagre v1"));
        }

        app.UseHttpsRedirection();
        app.UseBlazorFrameworkFiles();
        
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
    }
}