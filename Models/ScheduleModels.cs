using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeSchedule.Models
{
    public class EmployeeSetup
    {
        public int id { get; set; }
        public string name { get; set; }
        public string dept { get; set; }
        public string position { get; set; }
        public int wage { get; set; }

    }

    public class Availability 
    {
        public int id { get; set; }
        public string DayId { get; set; }

        [ForeignKey("empstp")]
        public int empID { get; set; }
        public EmployeeSetup epmstp { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public DateTime st { get; set; }
        public DateTime et { get; set; }
        public string reason { get; set; }
    }

    public class ScheduleSetup : DbContext
    {
        public ScheduleSetup(DbContextOptions<ScheduleSetup> options) : base(options)
        {

        }
        public DbSet<EmployeeSetup> employeeSetup { get; set; }
        public DbSet<Availability> availability { get; set; }
    }
}
