using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiHoChieu.Migrations
{
    /// <inheritdoc />
    public partial class UserAuthGrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Roles
            migrationBuilder.Sql("CREATE ROLE XT;");
            migrationBuilder.Sql("CREATE ROLE XD;");
            migrationBuilder.Sql("CREATE ROLE LT;");
            migrationBuilder.Sql("CREATE ROLE GS;");

            // Grants for XT and XD
            migrationBuilder.Sql("GRANT SELECT ON PassportData TO XT;");
            migrationBuilder.Sql("GRANT SELECT ON ResidentData TO XT;");
            migrationBuilder.Sql("GRANT INSERT ON XuLy TO XT;");

            migrationBuilder.Sql("GRANT SELECT ON PassportData TO XD;");
            migrationBuilder.Sql("GRANT INSERT ON XuLy TO XD;");

            // Create view
            migrationBuilder.Sql(@"
                CREATE VIEW View_LT_Approved AS
                SELECT x.XuLyID, x.FormID, x.NgayXuLy, x.TrangThai, x.LoaiXuLy
                FROM XuLy x
                WHERE x.TrangThai IS NOT NULL;
            ");

            // Grants for LT role
            migrationBuilder.Sql("GRANT SELECT ON View_LT_Approved TO LT;");
            migrationBuilder.Sql("GRANT INSERT ON XuLy TO LT;");

            // Grants for GS role
            migrationBuilder.Sql("GRANT SELECT ON PassportData TO GS;");
            migrationBuilder.Sql("GRANT SELECT ON ResidentData TO GS;");
            migrationBuilder.Sql("GRANT SELECT ON XuLy TO GS;");
            migrationBuilder.Sql("GRANT SELECT ON LuuTru TO GS;");
            migrationBuilder.Sql("GRANT SELECT, INSERT, UPDATE, DELETE ON [User] TO GS;");
            migrationBuilder.Sql("GRANT SELECT, INSERT, UPDATE, DELETE ON TaiKhoan TO GS;");

            // Create Logins
            migrationBuilder.Sql("CREATE LOGIN xt_login WITH PASSWORD = 'XT_LOGIN_BMCSDL';");
            migrationBuilder.Sql("CREATE LOGIN xd_login WITH PASSWORD = 'XD_LOGIN_BMCSDL';");
            migrationBuilder.Sql("CREATE LOGIN lt_login WITH PASSWORD = 'LT_LOGIN_BMCSDL';");
            migrationBuilder.Sql("CREATE LOGIN gs_login WITH PASSWORD = 'GS_LOGIN_BMCSDL';");

            // Create Users
            migrationBuilder.Sql("CREATE USER xt_user FOR LOGIN xt_login;");
            migrationBuilder.Sql("CREATE USER xd_user FOR LOGIN xd_login;");
            migrationBuilder.Sql("CREATE USER lt_user FOR LOGIN lt_login;");
            migrationBuilder.Sql("CREATE USER gs_user FOR LOGIN gs_login;");

            // Add to db_owner (careful with this)
            migrationBuilder.Sql("ALTER ROLE db_owner ADD MEMBER xt_user;");
            migrationBuilder.Sql("ALTER ROLE db_owner ADD MEMBER xd_user;");
            migrationBuilder.Sql("ALTER ROLE db_owner ADD MEMBER lt_user;");
            migrationBuilder.Sql("ALTER ROLE db_owner ADD MEMBER gs_user;");

            // Add users to your roles
            migrationBuilder.Sql("EXEC sp_addrolemember 'XT', xt_user;");
            migrationBuilder.Sql("EXEC sp_addrolemember 'XD', xd_user;");
            migrationBuilder.Sql("EXEC sp_addrolemember 'LT', lt_user;");
            migrationBuilder.Sql("EXEC sp_addrolemember 'GS', gs_user;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Implement drop statements for rollback (optional but recommended)
            migrationBuilder.Sql("DROP VIEW IF EXISTS View_LT_Approved;");
            migrationBuilder.Sql("DROP USER IF EXISTS xt_user;");
            migrationBuilder.Sql("DROP USER IF EXISTS xd_user;");
            migrationBuilder.Sql("DROP USER IF EXISTS lt_user;");
            migrationBuilder.Sql("DROP USER IF EXISTS gs_user;");

            migrationBuilder.Sql("DROP LOGIN IF EXISTS xt_login;");
            migrationBuilder.Sql("DROP LOGIN IF EXISTS xd_login;");
            migrationBuilder.Sql("DROP LOGIN IF EXISTS lt_login;");
            migrationBuilder.Sql("DROP LOGIN IF EXISTS gs_login;");

            migrationBuilder.Sql("DROP ROLE IF EXISTS XT;");
            migrationBuilder.Sql("DROP ROLE IF EXISTS XD;");
            migrationBuilder.Sql("DROP ROLE IF EXISTS LT;");
            migrationBuilder.Sql("DROP ROLE IF EXISTS GS;");
        }
    }
}
