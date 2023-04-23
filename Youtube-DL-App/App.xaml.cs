using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Youtube_DL_App.Interfaces;
using Youtube_DL_App.Services;
using Youtube_DL_App.View;
using Youtube_DL_App.ViewModel;
using Youtube_DL_Wrapper.Interfaces;
using Youtube_DL_Wrapper.Services;

namespace Youtube_DL_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            // Setup logging.
            Log.Logger = ConfigureLogging();

            // Setup services.
            this.Services = ConfigureServices();
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
        /// Configure the logging for this application.
        /// </summary>
        /// <returns>Configured logger.</returns>
        private static ILogger ConfigureLogging()
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        /// <summary>
        /// Configure the services for this application.
        /// </summary>
        /// <returns>Configured service provider.</returns>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Logging
            services.AddLogging(logging => { logging.AddSerilog(); });

            // Services
            services.AddTransient<IWindowService, WindowService>();
            services.AddTransient<IBinaryHelper, BinaryHelper>();
            //services.AddTransient<IDownloadService, AudioDownloadService>();
            //services.AddTransient<IDownloadService, VideoDownloadService>();

            // View Models
            services.AddTransient<MainViewModel>();
            services.AddTransient<SettingsViewModel>();

            // Views
            services.AddSingleton<MainWindow>();

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// On startup.
        /// </summary>
        /// <param name="sender">This parameter is not used.</param>
        /// <param name="e">This parameter is not used.</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = this.Services.GetService<MainWindow>();

            window?.Show();
        }
    }
}
