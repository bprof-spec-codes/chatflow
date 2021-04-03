using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Logic.Classes;
using Logic.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Repository.Classes;
using Repository.Interfaces;

namespace ChatFlow
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IMessagesLogic, MessagesLogic>();
            services.AddTransient<IRoomLogic, RoomLogic>();
            services.AddTransient<IThreadsLogic, ThreadsLogic>();

            services.AddTransient<IMessagesRepository, MessagesRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IThreadsRepository, ThreadsRepository>();

            services.AddTransient<DbContext, ChatFlowContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
