CREATE OR ALTER PROCEDURE AppRecords.SaveUser
	@UserID INT,
	@Username NVARCHAR(64),
	@Password NVARCHAR(128)
AS

MERGE AppRecords.[User] U
USING (
	VALUES(@UserID,@Username,@Password)
	) CTE(UserID,Username,[Password])
	ON U.UserID = CTE.UserID
WHEN MATCHED THEN
	UPDATE
	SET
		Username = CTE.Username,
		[Password] = CTE.[Password]
WHEN NOT MATCHED THEN
	INSERT(Username, [Password])
	VALUES(@Username, @Password);
GO