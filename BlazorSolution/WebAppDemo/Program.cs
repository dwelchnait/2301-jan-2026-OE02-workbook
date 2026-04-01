using Microsoft.EntityFrameworkCore;
using WebAppDemo.Components;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

var builder = WebApplication.CreateBuilder(args);

// add the dbcontext and service class of my class library
//      to the collection of services that will be made
//      available to this web app when the web app requests
//      said service

// obtain the connection to supply to out DAL context class
// We will be registering the db connection AND our services
//      we create within the BLL folder of your library

//grab your connection string from its declared location
// either appsettings.json
//     or user secrets  

//access is first to appsettings.json
//then to user secrets
//if there is a declaration in both
// the declaration in appsettings is over ridden with the
//          declaration in user secrets.
var connectionstring = builder.Configuration.GetConnectionString("WWDB");

//register the DbContext to the Sql Sever
builder.Services.AddDbContext<WestWindContext>(options => options.UseSqlServer(connectionstring));

//Register your service class
//One for EACH service class in your BLL
//project recommendation, ADD lastname to the front of your service class
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<CategoryServices>();
builder.Services.AddScoped<SupplierServices>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
