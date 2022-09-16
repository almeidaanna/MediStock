
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/16/2022 14:51:02
-- Generated from EDMX file: C:\Users\annaa\source\repos\Assignment2\Assignment2\Models\FIT5032_MediStock.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MediStock_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DrugDrugList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugLists] DROP CONSTRAINT [FK_DrugDrugList];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentEquipmentList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentLists] DROP CONSTRAINT [FK_EquipmentEquipmentList];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminDoctor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Admins] DROP CONSTRAINT [FK_AdminDoctor];
GO
IF OBJECT_ID(N'[dbo].[FK_PharmacistAdmin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pharmacists] DROP CONSTRAINT [FK_PharmacistAdmin];
GO
IF OBJECT_ID(N'[dbo].[FK_LogisticBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugBookings] DROP CONSTRAINT [FK_LogisticBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminLogistic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Logistics] DROP CONSTRAINT [FK_AdminLogistic];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentBookingDoctor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentBookings] DROP CONSTRAINT [FK_EquipmentBookingDoctor];
GO
IF OBJECT_ID(N'[dbo].[FK_LogisticEquipmentBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentBookings] DROP CONSTRAINT [FK_LogisticEquipmentBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorDrugBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugBookings] DROP CONSTRAINT [FK_DoctorDrugBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_PharmacistDrugBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugBookings] DROP CONSTRAINT [FK_PharmacistDrugBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorEquipmentList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentLists] DROP CONSTRAINT [FK_DoctorEquipmentList];
GO
IF OBJECT_ID(N'[dbo].[FK_DrugListDrugBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DrugBookings] DROP CONSTRAINT [FK_DrugListDrugBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_EquipmentListEquipmentBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EquipmentBookings] DROP CONSTRAINT [FK_EquipmentListEquipmentBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Drugs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drugs];
GO
IF OBJECT_ID(N'[dbo].[Equipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipments];
GO
IF OBJECT_ID(N'[dbo].[DrugBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugBookings];
GO
IF OBJECT_ID(N'[dbo].[Pharmacists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pharmacists];
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
IF OBJECT_ID(N'[dbo].[DrugLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DrugLists];
GO
IF OBJECT_ID(N'[dbo].[EquipmentLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentLists];
GO
IF OBJECT_ID(N'[dbo].[EquipmentBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EquipmentBookings];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Drugs'
CREATE TABLE [dbo].[Drugs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [drug_name] nvarchar(max)  NOT NULL,
    [dosage] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [warning] nvarchar(max)  NOT NULL,
    [side_effect] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [equipment_name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [warning] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DrugBookings'
CREATE TABLE [dbo].[DrugBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sender_id] int  NOT NULL,
    [receiver_id] int  NOT NULL,
    [datetime] datetime  NOT NULL,
    [delivery_status] nvarchar(max)  NOT NULL,
    [transaction_status] nvarchar(max)  NOT NULL,
    [quantity] int  NOT NULL,
    [logistic_id] int  NOT NULL,
    [DrugList_owner_id] int  NOT NULL,
    [DrugList_drug_Id] int  NOT NULL,
    [Doctor_Id] int  NOT NULL,
    [Pharmacist_Id] int  NOT NULL
);
GO

-- Creating table 'Pharmacists'
CREATE TABLE [dbo].[Pharmacists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [location] nvarchar(max)  NOT NULL,
    [pharmacy_name] nvarchar(max)  NOT NULL,
    [email_address] nvarchar(max)  NOT NULL,
    [medical_reg] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [Admins_Id] int  NOT NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [location] nvarchar(max)  NOT NULL,
    [hospital_name] nvarchar(max)  NOT NULL,
    [email_address] nvarchar(max)  NOT NULL,
    [medical_reg] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [email_address] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [Doctors_Id] int  NOT NULL
);
GO

-- Creating table 'Logistics'
CREATE TABLE [dbo].[Logistics] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [first_name] nvarchar(max)  NOT NULL,
    [last_name] nvarchar(max)  NOT NULL,
    [phone_no] nvarchar(max)  NOT NULL,
    [email_id] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [Admin_Id] int  NOT NULL
);
GO

-- Creating table 'DrugLists'
CREATE TABLE [dbo].[DrugLists] (
    [drug_Id] int  NOT NULL,
    [owner_id] int  NOT NULL,
    [available_stock] int  NOT NULL
);
GO

-- Creating table 'EquipmentLists'
CREATE TABLE [dbo].[EquipmentLists] (
    [equipment_id] int  NOT NULL,
    [available_stock] int  NOT NULL,
    [owner_id] int  NOT NULL
);
GO

-- Creating table 'EquipmentBookings'
CREATE TABLE [dbo].[EquipmentBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [receiver_id] int  NOT NULL,
    [datetime] datetime  NOT NULL,
    [delivery_status] nvarchar(max)  NOT NULL,
    [transaction_status] nvarchar(max)  NOT NULL,
    [quantity] int  NOT NULL,
    [sender_id] int  NOT NULL,
    [logistic_id] int  NOT NULL,
    [EquipmentList_equipment_id] int  NOT NULL,
    [EquipmentList_owner_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Drugs'
ALTER TABLE [dbo].[Drugs]
ADD CONSTRAINT [PK_Drugs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DrugBookings'
ALTER TABLE [dbo].[DrugBookings]
ADD CONSTRAINT [PK_DrugBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pharmacists'
ALTER TABLE [dbo].[Pharmacists]
ADD CONSTRAINT [PK_Pharmacists]
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

-- Creating primary key on [owner_id], [drug_Id] in table 'DrugLists'
ALTER TABLE [dbo].[DrugLists]
ADD CONSTRAINT [PK_DrugLists]
    PRIMARY KEY CLUSTERED ([owner_id], [drug_Id] ASC);
GO

-- Creating primary key on [equipment_id], [owner_id] in table 'EquipmentLists'
ALTER TABLE [dbo].[EquipmentLists]
ADD CONSTRAINT [PK_EquipmentLists]
    PRIMARY KEY CLUSTERED ([equipment_id], [owner_id] ASC);
GO

-- Creating primary key on [Id] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [PK_EquipmentBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [drug_Id] in table 'DrugLists'
ALTER TABLE [dbo].[DrugLists]
ADD CONSTRAINT [FK_DrugDrugList]
    FOREIGN KEY ([drug_Id])
    REFERENCES [dbo].[Drugs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugDrugList'
CREATE INDEX [IX_FK_DrugDrugList]
ON [dbo].[DrugLists]
    ([drug_Id]);
GO

-- Creating foreign key on [equipment_id] in table 'EquipmentLists'
ALTER TABLE [dbo].[EquipmentLists]
ADD CONSTRAINT [FK_EquipmentEquipmentList]
    FOREIGN KEY ([equipment_id])
    REFERENCES [dbo].[Equipments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Doctors_Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [FK_AdminDoctor]
    FOREIGN KEY ([Doctors_Id])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminDoctor'
CREATE INDEX [IX_FK_AdminDoctor]
ON [dbo].[Admins]
    ([Doctors_Id]);
GO

-- Creating foreign key on [Admins_Id] in table 'Pharmacists'
ALTER TABLE [dbo].[Pharmacists]
ADD CONSTRAINT [FK_PharmacistAdmin]
    FOREIGN KEY ([Admins_Id])
    REFERENCES [dbo].[Admins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PharmacistAdmin'
CREATE INDEX [IX_FK_PharmacistAdmin]
ON [dbo].[Pharmacists]
    ([Admins_Id]);
GO

-- Creating foreign key on [logistic_id] in table 'DrugBookings'
ALTER TABLE [dbo].[DrugBookings]
ADD CONSTRAINT [FK_LogisticBooking]
    FOREIGN KEY ([logistic_id])
    REFERENCES [dbo].[Logistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogisticBooking'
CREATE INDEX [IX_FK_LogisticBooking]
ON [dbo].[DrugBookings]
    ([logistic_id]);
GO

-- Creating foreign key on [Admin_Id] in table 'Logistics'
ALTER TABLE [dbo].[Logistics]
ADD CONSTRAINT [FK_AdminLogistic]
    FOREIGN KEY ([Admin_Id])
    REFERENCES [dbo].[Admins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminLogistic'
CREATE INDEX [IX_FK_AdminLogistic]
ON [dbo].[Logistics]
    ([Admin_Id]);
GO

-- Creating foreign key on [sender_id] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [FK_EquipmentBookingDoctor]
    FOREIGN KEY ([sender_id])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentBookingDoctor'
CREATE INDEX [IX_FK_EquipmentBookingDoctor]
ON [dbo].[EquipmentBookings]
    ([sender_id]);
GO

-- Creating foreign key on [logistic_id] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [FK_LogisticEquipmentBooking]
    FOREIGN KEY ([logistic_id])
    REFERENCES [dbo].[Logistics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogisticEquipmentBooking'
CREATE INDEX [IX_FK_LogisticEquipmentBooking]
ON [dbo].[EquipmentBookings]
    ([logistic_id]);
GO

-- Creating foreign key on [Doctor_Id] in table 'DrugBookings'
ALTER TABLE [dbo].[DrugBookings]
ADD CONSTRAINT [FK_DoctorDrugBooking]
    FOREIGN KEY ([Doctor_Id])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorDrugBooking'
CREATE INDEX [IX_FK_DoctorDrugBooking]
ON [dbo].[DrugBookings]
    ([Doctor_Id]);
GO

-- Creating foreign key on [Pharmacist_Id] in table 'DrugBookings'
ALTER TABLE [dbo].[DrugBookings]
ADD CONSTRAINT [FK_PharmacistDrugBooking]
    FOREIGN KEY ([Pharmacist_Id])
    REFERENCES [dbo].[Pharmacists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PharmacistDrugBooking'
CREATE INDEX [IX_FK_PharmacistDrugBooking]
ON [dbo].[DrugBookings]
    ([Pharmacist_Id]);
GO

-- Creating foreign key on [owner_id] in table 'EquipmentLists'
ALTER TABLE [dbo].[EquipmentLists]
ADD CONSTRAINT [FK_DoctorEquipmentList]
    FOREIGN KEY ([owner_id])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorEquipmentList'
CREATE INDEX [IX_FK_DoctorEquipmentList]
ON [dbo].[EquipmentLists]
    ([owner_id]);
GO

-- Creating foreign key on [DrugList_owner_id], [DrugList_drug_Id] in table 'DrugBookings'
ALTER TABLE [dbo].[DrugBookings]
ADD CONSTRAINT [FK_DrugListDrugBooking]
    FOREIGN KEY ([DrugList_owner_id], [DrugList_drug_Id])
    REFERENCES [dbo].[DrugLists]
        ([owner_id], [drug_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DrugListDrugBooking'
CREATE INDEX [IX_FK_DrugListDrugBooking]
ON [dbo].[DrugBookings]
    ([DrugList_owner_id], [DrugList_drug_Id]);
GO

-- Creating foreign key on [EquipmentList_equipment_id], [EquipmentList_owner_id] in table 'EquipmentBookings'
ALTER TABLE [dbo].[EquipmentBookings]
ADD CONSTRAINT [FK_EquipmentListEquipmentBooking]
    FOREIGN KEY ([EquipmentList_equipment_id], [EquipmentList_owner_id])
    REFERENCES [dbo].[EquipmentLists]
        ([equipment_id], [owner_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EquipmentListEquipmentBooking'
CREATE INDEX [IX_FK_EquipmentListEquipmentBooking]
ON [dbo].[EquipmentBookings]
    ([EquipmentList_equipment_id], [EquipmentList_owner_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------