using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniComp.Core.Extension;

namespace MiniComp.Autofac;

public static class Setup
{
    /// <summary>
    /// 使用Autofac
    /// </summary>
    /// <param name="hostBuilder"></param>
    public static void UseAutofac(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }

    /// <summary>
    /// 自动注入
    /// </summary>
    /// <param name="services"></param>
    /// <param name="types"></param>
    public static void AutoAddDependency(this IServiceCollection services, List<Type> types)
    {
        types.ForEach(d =>
        {
            var at = d.GetCustomAttribute<AutofacDependencyAttribute>();
            if (at == null)
                return;
            if (string.IsNullOrWhiteSpace(at.ServiceKey))
            {
                services.Inject(at.ServiceLifetime, at.Type, d);
            }
            else
            {
                services.Inject(at.ServiceKey, at.ServiceLifetime, at.Type, d);
            }
        });
    }
}
