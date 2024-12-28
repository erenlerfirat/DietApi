using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using DietApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TodoAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args);

            builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.ConfigureContainer<ContainerBuilder>(
               builder => builder.RegisterModule(new AutofacBusinessModule()));

            builder.Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
