CREATE TABLE [dbo].[NumberTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UnsortedNumber] INT NOT NULL, 
    [SortedNumber] INT NOT NULL, 
    [Direction] VARCHAR(50) NOT NULL
)
