using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DataContext");

builder.Services.AddDbContext<DataContext>(options =>
{
  options.UseNpgsql(connectionString);
});

builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<ProfileRepository>();
builder.Services.AddTransient<ProfileMembershipRepository>();

builder.Services.AddHealthChecks();

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Version = "v1",
    Title = "10forward API",
    Description = "a meta-community for developers",
    TermsOfService = new Uri("https://10forward.io/terms"),
    Contact = new OpenApiContact
    {
      Name = "Contact",
      Url = new Uri("https://10forward.io/contact")
    },
    License = new OpenApiLicense
    {
      Name = "License",
      Url = new Uri("https://10forward.io/license")
    }
  });

  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
  options.SerializerOptions.WriteIndented = true;
  options.SerializerOptions.IncludeFields = true;
  options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
  // options.SerializerOptions.AllowTrailingCommas = true;
  options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
  options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
  options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
  // options.RoutePrefix = "/swagger";
});

if (app.Environment.IsDevelopment())
{
  app.UseHttpLogging();
  app.UseDeveloperExceptionPage();
}

app.MapHealthChecks("/health-check");

app.MapGroup("/").MapHomeRoutes();
app.MapGroup("/users/").MapUsersRoutes();
app.MapGroup("/profiles/").MapProfilesRoutes();

app.Run();
