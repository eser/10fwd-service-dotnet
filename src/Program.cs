using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DataContext");

builder.Services.AddSqlite<DataContext>(connectionString);

builder.Services.AddTransient<UserRepository>();

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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
  options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
  // options.RoutePrefix = "/swagger";
});

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.MapGroup("/").MapHomeRoutes();
app.MapGroup("/users/").MapUsersRoutes();

app.Run();
