CREATE PROCEDURE DbReset
AS
BEGIN
	delete from CardSet;
	DBCC CHECKIDENT('CardSet', RESEED, 0);

	insert into CardSet (CardSetName)
	values ('Base'),
	('Intrigue');
END