using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLiHoChieu.Migrations
{
    public partial class Triggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //User 
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_User_Insert
                ON [User]
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'User', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_User_Update
                ON [User]
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'UPDATE', 'User', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_User_Delete
                ON [User]
                AFTER DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'DELETE', 'User', SYSDATETIME());
                END
            ");

            // PassportData
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_PassportData_Insert
                ON PassportData
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'PassportData', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_PassportData_Update
                ON PassportData
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'UPDATE', 'PassportData', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_PassportData_Delete
                ON PassportData
                AFTER DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'DELETE', 'PassportData', SYSDATETIME());
                END
            ");

            // ResidentData
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_ResidentData_Insert
                ON ResidentData
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'ResidentData', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_ResidentData_Update
                ON ResidentData
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'UPDATE', 'ResidentData', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_ResidentData_Delete
                ON ResidentData
                AFTER DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'DELETE', 'ResidentData', SYSDATETIME());
                END
            ");

            // XuLy
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_XuLy_Insert
                ON XuLy
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog(Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'XuLy', SYSDATETIME())
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_XuLy_Update
                ON XuLy
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog(Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'XuLy', SYSDATETIME())
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_XuLy_Delete
                ON XuLy
                AFTER DELETE
                AS
                BEGIN
                    INSERT INTO AuditLog(Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'XuLy', SYSDATETIME())
                END
            ");

            // LuuTru
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_LuuTru_Insert
                ON LuuTru
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'LuuTru', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_LuuTru_Update
                ON LuuTru
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'UPDATE', 'LuuTru', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_LuuTru_Delete
                ON LuuTru
                AFTER DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'DELETE', 'LuuTru', SYSDATETIME());
                END
            ");

            // TaiKhoan
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_TaiKhoan_Insert
                ON TaiKhoan
                AFTER INSERT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'INSERT', 'TaiKhoan', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_TaiKhoan_Update
                ON TaiKhoan
                AFTER UPDATE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'UPDATE', 'TaiKhoan', SYSDATETIME());
                END
            ");

            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_Audit_TaiKhoan_Delete
                ON TaiKhoan
                AFTER DELETE
                AS
                BEGIN
                    SET NOCOUNT ON;
                    INSERT INTO AuditLog (Username, Action, TableName, TimeStamp)
                    VALUES (SYSTEM_USER, 'DELETE', 'TaiKhoan', SYSDATETIME());
                END
            ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            // User triggers
            migrationBuilder.Sql(@"
                IF OBJECT_ID('trg_Audit_User_Insert', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_User_Insert;
                IF OBJECT_ID('trg_Audit_User_Update', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_User_Update;
                IF OBJECT_ID('trg_Audit_User_Delete', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_User_Delete;
            ");

            // ResidentData triggers
            migrationBuilder.Sql(@"
                IF OBJECT_ID('trg_Audit_ResidentData_Insert', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_ResidentData_Insert;
                IF OBJECT_ID('trg_Audit_ResidentData_Update', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_ResidentData_Update;
                IF OBJECT_ID('trg_Audit_ResidentData_Delete', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_ResidentData_Delete;
            ");

            // PassportData triggers
            migrationBuilder.Sql(@"
                IF OBJECT_ID('trg_Audit_PassportData_Insert', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_PassportData_Insert;
                IF OBJECT_ID('trg_Audit_PassportData_Update', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_PassportData_Update;
                IF OBJECT_ID('trg_Audit_PassportData_Delete', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_PassportData_Delete;
            ");

            // XuLy triggers
            migrationBuilder.Sql(@"
                IF OBJECT_ID('trg_Audit_XuLy_Insert', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_XuLy_Insert;
                IF OBJECT_ID('trg_Audit_XuLy_Update', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_XuLy_Update;
                IF OBJECT_ID('trg_Audit_XuLy_Delete', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_XuLy_Delete;
            ");

            // LuuTru triggers
            migrationBuilder.Sql(@"
                IF OBJECT_ID('trg_Audit_LuuTru_Insert', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_LuuTru_Insert;
                IF OBJECT_ID('trg_Audit_LuuTru_Update', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_LuuTru_Update;
                IF OBJECT_ID('trg_Audit_LuuTru_Delete', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_LuuTru_Delete;
            ");

            // TaiKhoan triggers
            migrationBuilder.Sql(@"
                IF OBJECT_ID('trg_Audit_TaiKhoan_Insert', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_TaiKhoan_Insert;
                IF OBJECT_ID('trg_Audit_TaiKhoan_Update', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_TaiKhoan_Update;
                IF OBJECT_ID('trg_Audit_TaiKhoan_Delete', 'TR') IS NOT NULL DROP TRIGGER trg_Audit_TaiKhoan_Delete;
            ");
        }
    }
}
