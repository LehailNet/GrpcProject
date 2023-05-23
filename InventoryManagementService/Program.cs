using InventoryManagementService;
using InventoryManagementService.MapperProfile;
using OrederService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc();

builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();

InventoryServiceDI.Configure(builder.Services);

builder.Services.AddAutoMapper(typeof(ItemMappingProfile));

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

app.MapGrpcService<OrderInventoryService>();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
