﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication.Models.IdentityModels
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
     
    }
}