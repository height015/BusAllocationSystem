using System;
using Microsoft.EntityFrameworkCore;

namespace XGrid.Domain.Object.Data;

public class AppDbContext :DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
	{

	}

	public DbSet<PassangerRegObj> Passangers { get; set; }
    public DbSet<BusRegistrationObj> Buses { get; set; }
    public DbSet<ReservationObj> Reservations { get; set; }
    public DbSet<RouteCordinatorRegObj> RouteCordinatorReg { get; set; }
    public DbSet<RouteRegObj> Routes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }
}

