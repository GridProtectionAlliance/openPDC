CREATE FUNCTION [dbo].[ufn_GenerateIntegers] (@StartIndex INT, @MaxValue INT)
RETURNS @Integers TABLE ( [IntValue] INT )
AS
BEGIN
    DECLARE @Index INT
    SET @Index = @StartIndex
    WHILE @Index <= @MaxValue
    BEGIN
        INSERT INTO @Integers ( [IntValue] ) VALUES ( @Index )
        SET @Index = @Index + 1
    END

    RETURN
END
GO