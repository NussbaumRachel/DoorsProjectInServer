using Bl.Api;
using Bl.Models;
using Bl.Services;
using Dal;
using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{

    public class BlManager : IBl
    {
        public IBlEmployees employees { get; }

        public IBlOrders orders { get; }

        public IBlCheck checks { get; }

        public IBlCustomers customers { get; }

        public IBlDoors doors { get; }

        public IBlDoorsFrames doorsFrames { get; }

        public IBlOrderItems orderItems { get; }

        public BlManager()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<DbManager>();
            services.AddSingleton<IBlDoors, BlDoorsService>();
            services.AddSingleton<IBlOrderItems, BlOrderItemsService>();
            services.AddSingleton<IBlOrders, BlOrdersService>();
            services.AddSingleton<IBlCustomers, BlCustomersService>();
            services.AddSingleton<IBlDoorsFrames, BlDoorsFramesService>();
            services.AddSingleton<IBlCheck, BlCheckService>();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBlEmployees, BlEmployeesService>();
            ServiceProvider servicesProvider = services.BuildServiceProvider();
            employees = servicesProvider.GetRequiredService<IBlEmployees>();
            doors = servicesProvider.GetRequiredService<IBlDoors>();
            customers = servicesProvider.GetRequiredService<IBlCustomers>();
            orders = servicesProvider.GetRequiredService<IBlOrders>();
            doorsFrames = servicesProvider.GetRequiredService<IBlDoorsFrames>();
            checks = servicesProvider.GetRequiredService<IBlCheck>();
            orderItems = servicesProvider.GetRequiredService<IBlOrderItems>();
        }
    }
}
