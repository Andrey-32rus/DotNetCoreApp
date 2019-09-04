using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public interface IServiceConfigurator
    {
        void ConfigureServices(IServiceCollection services);
    }
}