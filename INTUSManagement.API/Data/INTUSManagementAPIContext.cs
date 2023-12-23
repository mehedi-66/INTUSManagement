﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using INTUSManagement.Model;

namespace INTUSManagement.API.Data
{
    public class INTUSManagementAPIContext : DbContext
    {
        public INTUSManagementAPIContext (DbContextOptions<INTUSManagementAPIContext> options)
            : base(options)
        {
        }

        public DbSet<INTUSManagement.Model.Element> Element { get; set; } = default!;
    }
}
