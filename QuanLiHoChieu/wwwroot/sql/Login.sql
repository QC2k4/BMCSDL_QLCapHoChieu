-- Sử dụng CSDL
USE PASSPORT_SYSTEM;
GO

--B1: Tạo các database role
CREATE ROLE XT;  -- Xác thực
CREATE ROLE XD;  -- Xét duyệt
CREATE ROLE LT;  -- Lưu trữ
CREATE ROLE GS;  -- Giám sát
GO

--B2: Gán quyền cho các role
-- Xác thực
-- Xem PassportData & ResidentData
GRANT SELECT ON PassportData TO XT;
GRANT SELECT ON ResidentData TO XT;

-- Lưu lại hoạt động (ghi vào bảng XuLy)
GRANT INSERT ON XuLy TO XT;

-------------------------------------------

-- Xét duyệt
-- Xem PassportData
GRANT SELECT ON PassportData TO XD;

-- Lưu lại hoạt động (ghi vào bảng XuLy)
GRANT INSERT ON XuLy TO XD;

------------------------------------------

-- Lưu trữ
-- Tạo view chứa thông tin đã phê duyệt (VD: trong bảng XuLy có Trạng thái)
GO
CREATE VIEW View_LT_Approved AS
SELECT x.XuLyID, x.FormID, x.NgayXuLy, x.TrangThai, x.LoaiXuLy
FROM XuLy x
WHERE x.TrangThai IS NOT NULL;
GO

-- Cấp quyền SELECT trên view đó
GRANT SELECT ON View_LT_Approved TO LT;

-- Cho phép lưu lại hoạt động (INSERT XuLy)
GRANT INSERT ON XuLy TO LT;

---------------------------------------------

--Giám sát
-- Giám sát toàn bộ dữ liệu
GRANT SELECT ON PassportData TO GS;
GRANT SELECT ON ResidentData TO GS;
GRANT SELECT ON XuLy TO GS;
GRANT SELECT ON LuuTru TO GS;

-- Toàn quyền với bảng User và TaiKhoan để quản lý người dùng
GRANT SELECT, INSERT, UPDATE, DELETE ON [User] TO GS;
GRANT SELECT, INSERT, UPDATE, DELETE ON TaiKhoan TO GS;


--B3:Tạo Login, User và gán vào role
-- Tạo Login
CREATE LOGIN xt_login WITH PASSWORD = 'XT_LOGIN_BMCSDL';
CREATE LOGIN xd_login WITH PASSWORD = 'XD_LOGIN_BMCSDL';
CREATE LOGIN lt_login WITH PASSWORD = 'LT_LOGIN_BMCSDL';
CREATE LOGIN gs_login WITH PASSWORD = 'GS_LOGIN_BMCSDL';
GO

-- Tạo User trong CSDL
CREATE USER xt_user FOR LOGIN xt_login;
CREATE USER xd_user FOR LOGIN xd_login;
CREATE USER lt_user FOR LOGIN lt_login;
CREATE USER gs_user FOR LOGIN gs_login;
GO


-- Nếu bạn muốn các user này có toàn quyền như db_owner:
ALTER ROLE db_owner ADD MEMBER xt_user;
ALTER ROLE db_owner ADD MEMBER xd_user;
ALTER ROLE db_owner ADD MEMBER lt_user;
ALTER ROLE db_owner ADD MEMBER gs_user;
GO

-- Gán role
EXEC sp_addrolemember 'XT', xt_user;
EXEC sp_addrolemember 'XD', xd_user;
EXEC sp_addrolemember 'LT', lt_user;
EXEC sp_addrolemember 'GS', gs_user;
GO

