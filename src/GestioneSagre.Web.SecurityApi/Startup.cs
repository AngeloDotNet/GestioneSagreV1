namespace GestioneSagre.Web.SecurityApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
             });

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
        });

        services.AddDbContextPool<GestioneSagreSecurityDbContext>(optionBuilder =>
        {
            var connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");

            optionBuilder.UseSqlite(connectionString, options =>
            {
                options.MigrationsAssembly("GestioneSagre.Web.SecurityApi");
            });
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        // Customized services
        //services.AddSwaggerSecurityServices(Configuration, xmlPath);
        //services.AddRegisterSecurityServices(Configuration);

        // Options
        services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
    }

    public void Configure(WebApplication app)
    {
        IWebHostEnvironment env = app.Environment;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        var enableSwagger = Configuration.GetSection("Swagger").GetValue<bool>("enabled");

        if (enableSwagger)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestione Sagre v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseCors();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}