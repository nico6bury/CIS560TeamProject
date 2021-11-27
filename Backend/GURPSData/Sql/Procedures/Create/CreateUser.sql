CREATE OR ALTER PROCEDURE AppRecords.CreateUser
	@Username NVARCHAR(64),
	@Password NVARCHAR(128),
	@UserID INT OUTPUT
AS

INSERT AppRecords.[User](Username, [Password])
VALUES(@Username, @Password);

SET @UserID = SCOPE_IDENTITY();
GO