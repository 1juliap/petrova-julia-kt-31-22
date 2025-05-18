using Petrova_Julia_KT_31.Interfaces.TeachersInterfaces;

namespace Petrova_Julia_KT_31.ServiceExstensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IDisciplinesService, DisciplinesService>();
            return services;
        }
    }
}
