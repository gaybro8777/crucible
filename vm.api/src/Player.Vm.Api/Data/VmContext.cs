/*
Crucible
Copyright 2020 Carnegie Mellon University.
NO WARRANTY. THIS CARNEGIE MELLON UNIVERSITY AND SOFTWARE ENGINEERING INSTITUTE MATERIAL IS FURNISHED ON AN "AS-IS" BASIS. CARNEGIE MELLON UNIVERSITY MAKES NO WARRANTIES OF ANY KIND, EITHER EXPRESSED OR IMPLIED, AS TO ANY MATTER INCLUDING, BUT NOT LIMITED TO, WARRANTY OF FITNESS FOR PURPOSE OR MERCHANTABILITY, EXCLUSIVITY, OR RESULTS OBTAINED FROM USE OF THE MATERIAL. CARNEGIE MELLON UNIVERSITY DOES NOT MAKE ANY WARRANTY OF ANY KIND WITH RESPECT TO FREEDOM FROM PATENT, TRADEMARK, OR COPYRIGHT INFRINGEMENT.
Released under a MIT (SEI)-style license, please see license.txt or contact permission@sei.cmu.edu for full terms.
[DISTRIBUTION STATEMENT A] This material has been approved for public release and unlimited distribution.  Please see Copyright notice for non-US Government use and distribution.
Carnegie Mellon(R) and CERT(R) are registered in the U.S. Patent and Trademark Office by Carnegie Mellon University.
DM20-0181
*/

using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Player.Vm.Api.Domain.Models;
using Player.Vm.Api.Infrastructure.Extensions;

namespace Player.Vm.Api.Data
{
    public class VmContext : DbContext
    {
        private DbContextOptions _options;

        public VmContext(DbContextOptions options)
            : base(options)
        {
            _options = options;
        }

        public DbSet<Domain.Models.Vm> Vms { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<VmTeam> VmTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VmTeamConfiguration());

            // Apply PostgreSQL specific options
            if (_options.FindExtension<NpgsqlOptionsExtension>() != null)
            {
                modelBuilder.AddPostgresUUIDGeneration();
                modelBuilder.UsePostgresCasing();
            }
        }
    }
}