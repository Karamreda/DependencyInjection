using Autofac;
using ServiceContracts;
using Services;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new
    Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor(
//typeof(ICitiesService), 
//typeof(CitiesService), 
//ServiceLifetime.Transient
//));
builder.Host.ConfigureContainer<ContainerBuilder>
    (containerBuilder =>
    {
        //=====================================================================
        containerBuilder.RegisterType<CitiesService>
        ().As<ICitiesService>().InstancePerLifetimeScope();

        // builder.Services.AddScoped<ICitiesService, CitiesService>();
        //=====================================================================

        //containerBuilder.RegisterType<CitiesService>
        //().As<ICitiesService>().InstancePerDependency();
        // builder.Services.AddTransient<ICitiesService, CitiesService>();

        //=====================================================================
        //containerBuilder.RegisterType<CitiesService>
        //().As<ICitiesService>().SingleInstance();
        //builder.Services.AddSingleton<ICitiesService, CitiesService>();

    }); 
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
