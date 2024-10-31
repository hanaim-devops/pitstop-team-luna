using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// setup logging
builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration)
        .Enrich.WithMachineName()
);

// add repo
var sqlConnectionString = builder.Configuration.GetConnectionString("CustomerSupportCN");
builder.Services.AddTransient<ICustomerSupportDataRepository>(_ => new CustomerSupportDataRepository(sqlConnectionString));

// Add framework services
builder.Services
    .AddMvc(options => options.EnableEndpointRouting = false)
    .AddNewtonsoftJson();

// Register the Swagger generator, defining one or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerSupport API", Version = "v1" });
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });
 
// setup MVC
builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMvc();
app.UseDefaultFiles();
app.UseStaticFiles();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerSupport API - v1");
});

app.UseHealthChecks("/hc");

app.MapControllers();

app.Run();