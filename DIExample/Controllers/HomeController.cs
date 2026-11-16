using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
using Autofac;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        // instead of creating them manually using the new keyword.
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;


        // IServiceScopeFactory:
        // Used to create new dependency injection scopes manually.
        private readonly IServiceScopeFactory _serviceScopeFactory;

        // Autofac ILifetimeScope:
        // Represents an Autofac lifetime scope and allows resolving
        // dependencies within that scope
        private readonly ILifetimeScope _lifetimeScope;

        // Constructor Injection:

        public HomeController(
            ICitiesService citiesService1,
            ICitiesService citiesService2,
            ICitiesService citiesService3,
            IServiceScopeFactory serviceScopeFactory ,
            ILifetimeScope lifetimeScope)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;
            _lifetimeScope = lifetimeScope;
        }



        [Route("/")]

        public IActionResult Index()
        {
            List<string> cities = _citiesService1.GetCities();

            // Displaying service instance IDs to demonstrate
            ViewBag.ServiceInstance1 = _citiesService1.serviceInstanceID;
            ViewBag.ServiceInstance2 = _citiesService2.serviceInstanceID;
            ViewBag.ServiceInstance3 = _citiesService3.serviceInstanceID;



            // Creating a new Autofac Lifetime Scope.

            using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
            {
                ICitiesService citiesService = 
                scope.Resolve<ICitiesService>();


                // Displaying the instance ID to compare it with
                ViewBag.InstanceFromScope = citiesService.serviceInstanceID;
            }
            return View(cities);
        }
    }
}
