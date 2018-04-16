using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Team_5_Project.DAL;
namespace Team_5_Project.Models
{
    public class Employee : AppUser
    {
    }

    public class Manager: Employee
    {
        
    }

    public class TicketAgent : Employee
    {
        
    }

    public class CrewMember: Employee
    {
        
       // public virtual Crew Crew { get; set; }
    }
}