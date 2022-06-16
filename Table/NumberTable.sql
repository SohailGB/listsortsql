CREATE TABLE [dbo].[NumberTable] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [UnsortedNumber] INT          NOT NULL,
    [SortedNumber]   INT          NOT NULL,
    [Direction]      VARCHAR (50) NOT NULL,
    [ElapsedTime] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

