using OrederService;
using OrederService.MapperProfile;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddControllers().AddJsonOptions(options =>
                                                    {
                                                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                                                    });

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(OrderMappingProfile));

IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                         .Build();

OrderServiceDI.Configure(builder.Services, configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger()
   .UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
   });

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
