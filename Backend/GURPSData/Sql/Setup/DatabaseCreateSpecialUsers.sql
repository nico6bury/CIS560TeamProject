/*
	NOTE: This script is NOT meant to be re-runnable. It should be run once after
	database creation, just to populate it with special user values.
*/

-- create administrator account
INSERT AppRecords.[User](Username,[Password],IsAdmin)
VALUES (N'Administrator',N'@ v#ry $tr0ng,_S3cUre P@ssc#de >; + ]',1);

-- create account for deleted users
INSERT AppRecords.[User](Username,[Password])
VALUES (N'A Deleted User', N'4n_s3cUrE_p@$Sw6rD, :=} eY? ');