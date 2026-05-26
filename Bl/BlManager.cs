using Bl.Api;
using Bl.Models;
using Bl.Services;
using Dal;
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

        public IBlMpfGenerator mpfGenerator { get; }
        public IBlMpfFileService mpfFileService { get; }

        public BlManager()
        {
            ServiceCollection services = new ServiceCollection();


            //services.AddDbContext<DbManager>(options =>
            //options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='F:\\תיקייה כללית חדש\\שנה א תשפה\\תלמידות\\#PROJECTS\\רחלי קמינר ורחל נוסבוים.mdf';Integrated Security=True;Connect Timeout=30;Encrypt=True"));
            services.AddDbContext<DbManager>();
            services.AddSingleton<IBlDoors, BlDoorsService>();
            services.AddSingleton<IBlOrderItems, BlOrderItemsService>();
            services.AddSingleton<IBlOrders, BlOrdersService>();
            services.AddSingleton<IBlCustomers, BlCustomersService>();
            services.AddSingleton<IBlDoorsFrames, BlDoorsFramesService>();
            services.AddSingleton<IBlCheck, BlCheckService>();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBlEmployees, BlEmployeesService>();
            services.AddSingleton<IBlMpfGenerator, MpfGenerator>();
            services.AddSingleton<IBlMpfFileService, MpfFileService>();

            ServiceProvider servicesProvider = services.BuildServiceProvider();
            employees = servicesProvider.GetRequiredService<IBlEmployees>();
            doors = servicesProvider.GetRequiredService<IBlDoors>();
            customers = servicesProvider.GetRequiredService<IBlCustomers>();
            orders = servicesProvider.GetRequiredService<IBlOrders>();
            doorsFrames = servicesProvider.GetRequiredService<IBlDoorsFrames>();
            checks = servicesProvider.GetRequiredService<IBlCheck>();
            orderItems = servicesProvider.GetRequiredService<IBlOrderItems>();
            mpfGenerator = servicesProvider.GetRequiredService<IBlMpfGenerator>();
            mpfFileService = servicesProvider.GetRequiredService<IBlMpfFileService>();
        }
    }
}
