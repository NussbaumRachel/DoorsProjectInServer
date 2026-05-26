using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalManager : IDal
    {
        public IOrders orders { get; }

        public ICustomers customers { get; }

        public IDoors doors { get; }

        public IDoorsFrames doorFrames { get; }
        public IEmployee employees { get; }

        public ICheck checks { get; }
        public IOrderItems orderItems { get; }

        public DalManager()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<DbManager>();
            //services.AddDbContext<DbManager>(options =>
            //options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\תיקייה כללית חדש\\שנה א תשפה\\תלמידות\\#PROJECTS\\רחלי קמינר ורחל נוסבוים.mdf';Integrated Security=True;Connect Timeout=30;Encrypt=True"));
            services.AddSingleton<IDoors, DoorsService>();
            services.AddSingleton<ICheck, CheckService>();
            services.AddSingleton<IOrders, OrdersService>();
            services.AddSingleton<ICustomers, CustomersService>();
            services.AddSingleton<IDoorsFrames, DoorsFramesService>();
            services.AddSingleton<IOrderItems, OrderItemsService>();
            services.AddSingleton<IEmployee, EmployeesService>();
            ServiceProvider servicesProvider = services.BuildServiceProvider();    
            employees = servicesProvider.GetRequiredService<IEmployee>();
            doors = servicesProvider.GetRequiredService<IDoors>();
            customers = servicesProvider.GetRequiredService<ICustomers>();
            orders = servicesProvider.GetRequiredService<IOrders>();
            doorFrames = servicesProvider.GetRequiredService<IDoorsFrames>();
            checks = servicesProvider.GetRequiredService<ICheck>();
            orderItems = servicesProvider.GetRequiredService<IOrderItems>();
        }

    }
}
