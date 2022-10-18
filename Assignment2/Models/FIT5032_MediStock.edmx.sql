
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2022 01:25:03
-- Generated from EDMX file: C:\Users\annaa\source\repos\Assignment2\Assignment2\Models\FIT5032_MediStock.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-Assignment2-20220904103708];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AdminEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipments] DROP CONSTRAINT [FK_AdminEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorEquipmentBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentBookings] DROP CONSTRAINT [FK_DoctorEquipmentBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_LogisticEquipmentBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentBookings] DROP CONSTRAINT [FK_LogisticEquipmentBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentEquipmentBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentBookings] DROP CONSTRAINT [FK_EquipmentEquipmentBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Equipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipments];
GO
IF OBJECT_ID(N'[dbo].[Doctors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctors];
GO
IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[Logistics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logistics];
GO
IF OBJECT_ID(N'[dbo].[EquipmentBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentBookings];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [equipment_name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [available_stock] int  NOT NULL,
    [AdminId] int  NOT NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [latitude] decimal(18,0)  NOT NULL,
    [hospital_name] nvarchar(max)  NOT NULL,
    [email_address] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [longitude] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [email_address] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Logistics'
CREATE TABLE [dbo].[Logistics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [email_id] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EquipmentBookings'
CREATE TABLE [dbo].[EquipmentBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [datetime] datetime  NOT NULL,
    [status] bit  NOT NULL,
    [quantity] int  NOT NULL,
    [DoctorId] int  NOT NULL,
    [LogisticId] int  NOT NULL,
    [EquipmentId] int  NOT NULL
);
GO

-- Creating table 'EquipmentRatings'
CREATE TABLE [dbo].[EquipmentRatings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rating] int  NOT NULL,
    [comment] nvarchar(max)  NOT NULL,
    [commentDate] datetime  NOT NULL,
    [EquipmentId] int  NOT NULL,
    [DoctorId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Logistics'
ALTER TABLE [dbo].[Logistics]
ADD CONSTRAINT [PK_Logistics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [PK_EquipmentBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentRatings'
ALTER TABLE [dbo].[EquipmentRatings]
ADD CONSTRAINT [PK_EquipmentRatings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AdminId] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_AdminEquipment]
    FOREIGN KEY ([AdminId])
    REFERENCES [dbo].[Admins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminEquipment'
CREATE INDEX [IX_FK_AdminEquipment]
ON [dbo].[Equipments]
    ([AdminId]);
GO

-- Creating foreign key on [DoctorId] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [FK_DoctorEquipmentBooking]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorEquipmentBooking'
CREATE INDEX [IX_FK_DoctorEquipmentBooking]
ON [dbo].[EquipmentBookings]
    ([DoctorId]);
GO

-- Creating foreign key on [LogisticId] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [FK_LogisticEquipmentBooking]
    FOREIGN KEY ([LogisticId])
    REFERENCES [dbo].[Logistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogisticEquipmentBooking'
CREATE INDEX [IX_FK_LogisticEquipmentBooking]
ON [dbo].[EquipmentBookings]
    ([LogisticId]);
GO

-- Creating foreign key on [EquipmentId] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [FK_EquipmentEquipmentBooking]
    FOREIGN KEY ([EquipmentId])
    REFERENCES [dbo].[Equipments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentEquipmentBooking'
CREATE INDEX [IX_FK_EquipmentEquipmentBooking]
ON [dbo].[EquipmentBookings]
    ([EquipmentId]);
GO

-- Creating foreign key on [EquipmentId] in table 'EquipmentRatings'
ALTER TABLE [dbo].[EquipmentRatings]
ADD CONSTRAINT [FK_EquipmentEquipmentRating]
    FOREIGN KEY ([EquipmentId])
    REFERENCES [dbo].[Equipments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentEquipmentRating'
CREATE INDEX [IX_FK_EquipmentEquipmentRating]
ON [dbo].[EquipmentRatings]
    ([EquipmentId]);
GO

-- Creating foreign key on [DoctorId] in table 'EquipmentRatings'
ALTER TABLE [dbo].[EquipmentRatings]
ADD CONSTRAINT [FK_DoctorEquipmentRating]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorEquipmentRating'
CREATE INDEX [IX_FK_DoctorEquipmentRating]
ON [dbo].[EquipmentRatings]
    ([DoctorId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------