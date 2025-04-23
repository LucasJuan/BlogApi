using BlogApi.Application;
using BlogApi.Domain.Interfaces;
using BlogApi.Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using BlogApi.Application.Validators;
using Serilog;

namespace BlogApi.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBlogApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<BlogService>();

            services.AddValidatorsFromAssemblyContaining<BlogPostCreateValidator>();
            services.AddValidatorsFromAssemblyContaining<CommentCreateDtoValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddSingleton<Serilog.ILogger>(Log.Logger);

            return services;
        }
    }
}
