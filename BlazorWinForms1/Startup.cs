using Blazored.LocalStorage;
using BlazorWinForms1.Helper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MudBlazor;
using MudBlazor.Services;



namespace BlazorWinForms1
{

    public   class Startup
    {
      
        
        public static IServiceProvider? Services { get; private set; }
       public static Form1 _form1 { get; set; }
        public static void Init()
        {
     
            var host = Host.CreateDefaultBuilder().ConfigureHostConfiguration(Configration)
                           .ConfigureServices(WireupServices)
                           .Build();

            Services = host.Services;
           
            System.Diagnostics.Debug.WriteLine("");
        }
        public static void Configration(IConfigurationBuilder conf) 
        {
            conf.SetBasePath(Directory.GetCurrentDirectory());
            conf.AddJsonFile("appsettings.json");
        }
      
        private static void WireupServices(HostBuilderContext context, IServiceCollection services)
        {
            
           
            services.AddBlazorWebView();
            services.AddBlazoredLocalStorage();
            services.AddSingleton(typeof(Form1),_form1);
            services.AddScoped(typeof(ManagerHelper));
           // services.AddHttpClient();
           services.AddHttpClient();
           services.AddMudServices(configuration =>
           {
               configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
               configuration.SnackbarConfiguration.HideTransitionDuration = 100;
               configuration.SnackbarConfiguration.ShowTransitionDuration = 100;
               configuration.SnackbarConfiguration.VisibleStateDuration = 5000;
               configuration.SnackbarConfiguration.ShowCloseIcon = true;
           });
        }
    }
}