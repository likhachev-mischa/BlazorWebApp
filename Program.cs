using BlazorApp.Components;
using BlazorApp.Controller;
using Controller;
using Lab;
using View;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


PhilosopherContext context = new();
PhilosophersDbStorage dbStorage = new(context);

EntityView<Philosopher> philosopherView = new();
builder.Services.AddSingleton(philosopherView);
PhilosophersController philosophersController = new(dbStorage, philosopherView);

EntityView<Country> countryView = new();
builder.Services.AddSingleton(countryView);
CountriesController countriesController = new(dbStorage, countryView);

EntityView<Work> workView = new();
builder.Services.AddSingleton(workView);
WorksController worksController = new(dbStorage, workView);

EntityView<PhilosopherCountryConnection> pccView = new();
builder.Services.AddSingleton(pccView);
PCCsController pccsController = new(dbStorage, pccView);

EntityView<PhilosopherStudentConnection> pscView = new();
builder.Services.AddSingleton(pscView);
PSCsController pscsController = new(dbStorage, pscView);

EntityView<Philosophy> philosophyView = new();
builder.Services.AddSingleton(philosophyView);
PhilosophiesController philosophiesController = new( dbStorage, philosophyView);

EntityView<PhilosopherPhilosophyConnection> ppcView = new();
builder.Services.AddSingleton(ppcView);
PPCsController ppcsController = new(dbStorage, ppcView);


var app = builder.Build();


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


