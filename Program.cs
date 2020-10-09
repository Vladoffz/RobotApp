using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace RobotAppp228322
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            var scope = _serviceProvider.CreateScope();
            

            GeneratingField gf = scope.ServiceProvider.GetService<GeneratingField>();
            var field = gf.Generate(20);
            Game game = new Game(field);
            game.Play();

        }
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRobot, Robot>();
            services.AddSingleton<IBagage, Bagage>();
            services.AddSingleton<List<IBagage>>();
            services.AddSingleton<GeneratingField>();
            services.AddSingleton<GeneratingBaggages>();
            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
