CREATE OR ALTER PROCEDURE AppRecords.CreateUser
	@Username NVARCHAR(64),
	@Password NVARCHAR(128),
	@UserID INT OUTPUT,
	@IsAdmin BIT OUTPUT,
	@JoinedOn DATETIMEOFFSET OUTPUT
AS

INSERT AppRecords.[User](Username, [Password])
VALUES(@Username, @Password);

SET @UserID = SCOPE_IDENTITY();
SET @IsAdmin = 0;
SET @JoinedOn = (SELECT U.JoinedOn FROM AppRecords.[User] U WHERE U.UserID = @UserID);
GO