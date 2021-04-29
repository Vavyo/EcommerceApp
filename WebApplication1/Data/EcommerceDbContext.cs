using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Identity;

namespace WebApplication1.Data
{
    public class EcommerceDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
