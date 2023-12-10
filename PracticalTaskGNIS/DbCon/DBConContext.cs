using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.DbCon;

public class DBConContext(DbContextOptions<DBConContext> options) : DbContext(options)
{
    public DbSet<CorporateCustomer> CorporateCustomers { get; set; }

    public DbSet<IndividualCustomer> IndividualCustomer { get; set; }
    public DbSet<CorporateOrIndividual> CorporateOrIndividuals { get; set; }
    public DbSet<MeetingMinutes> MeetingMinutes { get; set; }
}