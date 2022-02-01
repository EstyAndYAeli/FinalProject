
using BL;
using DL;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace auto_parking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            {
                services.AddScoped<BL.ICostumerBL, CostumerBL>();
                services.AddScoped<DL.ICostumerDL, CostumerDL>();

                services.AddScoped<BL.ICommentBL, CommentBL>();
                services.AddScoped<DL.ICommentDL, CommentDL>();

                services.AddScoped<BL.IOrderBL, OrderBL>();
                services.AddScoped<DL.IOrderDL, OrderDL>();

                services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" }); });
                services.AddDbContext<auto_parkingContext>(options => options.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=auto_parking;Integrated Security=True;Pooling=False"));
                services.AddControllers();
                services.AddAuthorization();
                services.AddCors(options =>
                {
                    options.AddPolicy(name: "MyAllowSpecificOrigins",
                                      builder =>
                                      {
                                          builder.WithOrigins("http://localhost:4200")
                                          .AllowAnyMethod()
                                          .AllowAnyHeader();
                                      });
                });
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("MyAllowSpecificOrigins");
            
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"); });
        }
    }
}
