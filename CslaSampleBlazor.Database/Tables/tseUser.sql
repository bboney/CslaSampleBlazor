CREATE TABLE [dbo].[tseUser] (
    [UserKey]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedByUserKey]  INT            NULL,
    [CreatedOnDate]     DATETIME       NULL,
    [FirstName]         NVARCHAR (200) NOT NULL,
    [IsActive]          BIT            CONSTRAINT [DF__tseUser__IsActiv__5DCAEF64] DEFAULT ((0)) NOT NULL,
    [IsExternal]        BIT            CONSTRAINT [DF__tseUser__IsExter__5EBF139D] DEFAULT ((0)) NOT NULL,
    [IsInternal]        BIT            CONSTRAINT [DF__tseUser__IsInter__5FB337D6] DEFAULT ((0)) NOT NULL,
    [LastChanged]       ROWVERSION     NULL,
    [LastName]          NVARCHAR (200) NOT NULL,
    [ModifiedByUserKey] INT            NULL,
    [ModifiedOnDate]    DATETIME       NULL,
    [NotificationEmail] NVARCHAR(500)  NULL,
    [NotificationSMS]   NVARCHAR(50)   NULL,
    [UserId]            NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_tseUser] PRIMARY KEY CLUSTERED ([UserKey] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_tseUser_UserId]
    ON [dbo].[tseUser]([UserId] ASC);

