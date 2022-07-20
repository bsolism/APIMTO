using ApiMto.Application.UnitOfWork;
using ApiMto.Domain.UnitOfWork;
using ApiMto.Context;
using System.Text.Json.Serialization;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureKestrel(options => options.Listen(System.Net.IPAddress.Parse("130.1.102.8"), 5003));

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.RespectBrowserAcceptHeader = true;
});
//builder.Services.AddControllers().AddXmlSerializerFormatters();
/*builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});*/
builder.Services.AddMvc().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWorkDomain, UnitOfWorkDomain>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
IWebHostEnvironment env = builder.Environment;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x=>x
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(origin=> true)
.AllowCredentials()
);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(env.WebRootPath, "DataSheet")),
    RequestPath = "/pdf/datasheet"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
