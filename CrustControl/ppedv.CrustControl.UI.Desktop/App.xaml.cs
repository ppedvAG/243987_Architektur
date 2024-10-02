using Microsoft.Extensions.DependencyInjection;
using ppedv.CrustControl.Data.Db;
using ppedv.CrustControl.Logic;
using ppedv.CrustControl.Model.Contracts.Data;
using ppedv.CrustControl.UI.Desktop.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ppedv.CrustControl.UI.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            string conString = "Server=(localdb)\\mssqllocaldb;Database=CrustControl_TestDb;Trusted_Connection=true";

            var services = new ServiceCollection();

            services.AddSingleton<PizzaService>();
            services.AddSingleton<OrderService>();
            services.AddTransient<IUnitOfWork>(x => new EfContextUnitOfWorkAdapter(conString));

            services.AddTransient<PizzaViewModel>();

            return services.BuildServiceProvider();
        }

    }

}
