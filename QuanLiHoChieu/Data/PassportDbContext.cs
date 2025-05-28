using Microsoft.EntityFrameworkCore;
using QuanLiHoChieu.Models;
using QuanLiHoChieu.Models.ViewModels;

namespace QuanLiHoChieu.Data
{
    public class PassportDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PassportDbContext> _logger;
        public PassportDbContext(DbContextOptions<PassportDbContext> options,
            IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ILogger<PassportDbContext> logger)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _logger = logger;
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<PassportData> PassportDatas { get; set; } = null!;
        public DbSet<XuLy> XuLys { get; set; } = null!;
        public DbSet<ResidentData> ResidentDatas { get; set; } = null!;
        public DbSet<LuuTru> LuuTrus { get; set; } = null!;
        public DbSet<AuditLog> AuditLog { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: make table names singular if needed
            modelBuilder.Entity<TaiKhoan>().ToTable("TaiKhoan");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<PassportData>().ToTable("PassportData");
            modelBuilder.Entity<XuLy>().ToTable("XuLy");
            modelBuilder.Entity<ResidentData>().ToTable("ResidentData");
            modelBuilder.Entity<LuuTru>().ToTable("LuuTru");
            modelBuilder.Entity<AuditLog>().ToTable("AuditLog");

            // Unique constraint on FormID in LuuTru (only needed if not using [Index])
            modelBuilder.Entity<LuuTru>()
                .HasIndex(l => l.FormID)
                .IsUnique();

            // Set up composite key or constraints if any (none in your case so far)

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DecryptedUserVM>(e =>
            {
                e.HasNoKey();
                e.ToView(null);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var user = _httpContextAccessor.HttpContext?.User;
                string connectionString;

                string GetConnStr(string name) =>
                    _configuration.GetConnectionString(name)
                    ?? throw new InvalidOperationException($"Connection string '{name}' not found.");

                if (user != null)
                {
                    if (user.IsInRole("GiamSat"))
                        connectionString = GetConnStr("GSConnection");
                    else if (user.IsInRole("XacThuc"))
                        connectionString = GetConnStr("XTConnection");
                    else if (user.IsInRole("XetDuyet"))
                        connectionString = GetConnStr("XDConnection");
                    else if (user.IsInRole("LuuTru"))
                        connectionString = GetConnStr("LTConnection");
                    else
                        connectionString = GetConnStr("DefaultConnection");
                }
                else
                {
                    connectionString = GetConnStr("DefaultConnection");
                }

                _logger.LogInformation("Selected connection string: {conn}", connectionString);

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
