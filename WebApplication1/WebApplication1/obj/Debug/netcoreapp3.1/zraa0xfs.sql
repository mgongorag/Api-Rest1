IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Gender] (
    [idGender] int NOT NULL IDENTITY,
    [gender] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Gender] PRIMARY KEY ([idGender])
);
GO

CREATE TABLE [ImagePost] (
    [idImage] int NOT NULL IDENTITY,
    [path] nvarchar(max) NOT NULL,
    [state] bit NOT NULL,
    CONSTRAINT [PK_ImagePost] PRIMARY KEY ([idImage])
);
GO

CREATE TABLE [TypeOfNotifications] (
    [idType] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [message] nvarchar(256) NOT NULL,
    [state] bit NOT NULL,
    CONSTRAINT [PK_TypeOfNotifications] PRIMARY KEY ([idType])
);
GO

CREATE TABLE [TypeOfPost] (
    [idTypeOfPost] int NOT NULL IDENTITY,
    [typePost] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TypeOfPost] PRIMARY KEY ([idTypeOfPost])
);
GO

CREATE TABLE [User] (
    [idUSer] int NOT NULL IDENTITY,
    [firstName] nvarchar(50) NOT NULL,
    [lastName] nvarchar(50) NOT NULL,
    [birthday] nvarchar(10) NOT NULL,
    [idGenter] int NOT NULL,
    [username] nvarchar(15) NOT NULL,
    [email] nvarchar(max) NOT NULL,
    [password] nvarchar(max) NOT NULL,
    [isVerificate] bit NOT NULL,
    [dateCreated] datetime2 NOT NULL,
    [lastSession] datetime2 NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([idUSer]),
    CONSTRAINT [FK_User_Gender_idGenter] FOREIGN KEY ([idGenter]) REFERENCES [Gender] ([idGender]) ON DELETE CASCADE
);
GO

CREATE TABLE [ListFriend] (
    [idUser] int NOT NULL,
    [idFriend] int NOT NULL,
    [dateAdded] datetime2 NOT NULL,
    [state] bit NOT NULL,
    [useridUSer] int NULL,
    CONSTRAINT [PK_ListFriend] PRIMARY KEY ([idUser], [idFriend]),
    CONSTRAINT [FK_ListFriend_User_idUser] FOREIGN KEY ([idUser]) REFERENCES [User] ([idUSer]) ON DELETE CASCADE,
    CONSTRAINT [FK_ListFriend_User_useridUSer] FOREIGN KEY ([useridUSer]) REFERENCES [User] ([idUSer]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Post] (
    [idPost] int NOT NULL IDENTITY,
    [description] nvarchar(2000) NULL,
    [date] datetime2 NOT NULL,
    [idUser] int NOT NULL,
    [state] bit NOT NULL,
    [idTypePost] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([idPost]),
    CONSTRAINT [FK_Post_TypeOfPost_idTypePost] FOREIGN KEY ([idTypePost]) REFERENCES [TypeOfPost] ([idTypeOfPost]) ON DELETE CASCADE,
    CONSTRAINT [FK_Post_User_idUser] FOREIGN KEY ([idUser]) REFERENCES [User] ([idUSer]) ON DELETE CASCADE
);
GO

CREATE TABLE [Notification] (
    [idNotification] int NOT NULL IDENTITY,
    [idUser] nvarchar(max) NULL,
    [description] nvarchar(250) NOT NULL,
    [isRead] bit NOT NULL,
    [date] datetime2 NOT NULL,
    [idType] int NOT NULL,
    [idPost] int NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY ([idNotification]),
    CONSTRAINT [FK_Notification_Post_idPost] FOREIGN KEY ([idPost]) REFERENCES [Post] ([idPost]) ON DELETE CASCADE,
    CONSTRAINT [FK_Notification_TypeOfNotifications_idType] FOREIGN KEY ([idType]) REFERENCES [TypeOfNotifications] ([idType]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ListFriend_useridUSer] ON [ListFriend] ([useridUSer]);
GO

CREATE INDEX [IX_Notification_idPost] ON [Notification] ([idPost]);
GO

CREATE INDEX [IX_Notification_idType] ON [Notification] ([idType]);
GO

CREATE INDEX [IX_Post_idTypePost] ON [Post] ([idTypePost]);
GO

CREATE INDEX [IX_Post_idUser] ON [Post] ([idUser]);
GO

CREATE INDEX [IX_User_idGenter] ON [User] ([idGenter]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210125030702_inicial', N'5.0.2');
GO

COMMIT;
GO

