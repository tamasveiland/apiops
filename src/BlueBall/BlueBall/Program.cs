using Asp.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BlueBall
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                //options.ApiVersionReader = ApiVersionReader.Combine(
                //    new UrlSegmentApiVersionReader(),
                //    new HeaderApiVersionReader("X-Api-Version")
                //);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlueBall v1", Version = "v1.0" });
                //c.SwaggerDoc("v2", new OpenApiInfo { Title = "BlueBall v2", Version = "v2.0" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlueBall v1"));
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "BlueBall v2"));

            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwaggerUI(
                   options =>
                   {
                       var descriptions = app.DescribeApiVersions();

                       // build a swagger endpoint for each discovered API version
                       foreach (var description in descriptions)
                       {
                           var url = $"/swagger/{description.GroupName}/swagger.json";
                           var name = description.GroupName.ToUpperInvariant();
                           options.SwaggerEndpoint(url, name);
                       }
                   });
            //}

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
