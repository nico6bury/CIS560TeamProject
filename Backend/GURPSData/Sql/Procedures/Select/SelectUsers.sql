CREATE OR ALTER PROCEDURE AppRecords.RetrieveAllUsers
AS
SELECT U.UserID,U.Username,U.[Password],U.IsAdmin,U.JoinedOn FROM AppRecords.[User] U;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveUserForID
	@UserID INT
AS
SELECT U.UserID,U.Username,U.[Password],U.IsAdmin,U.JoinedOn
FROM AppRecords.[User] U WHERE U.UserID = @UserID;
GO

CREATE OR ALTER PROCEDURE AppRecords.RetrieveUserForUsername
	@Username NVARCHAR(64)
AS
SELECT U.UserID,U.Username,U.[Password],U.IsAdmin,U.JoinedOn
FROM AppRecords.[User] U WHERE U.Username = @Username;
GO 