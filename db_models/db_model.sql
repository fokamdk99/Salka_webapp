-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema salkadb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema salkadb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `salkadb` DEFAULT CHARACTER SET utf8 ;
USE `salkadb` ;

-- -----------------------------------------------------
-- Table `salkadb`.`Schedules`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Schedules` (
  `ScheduleId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ScheduleId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Cities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Cities` (
  `CityId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`CityId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Posts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Posts` (
  `PostId` INT NOT NULL AUTO_INCREMENT,
  `PostalCode` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`PostId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Addresses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Addresses` (
  `AddressId` INT NOT NULL AUTO_INCREMENT,
  `Street` VARCHAR(45) NULL,
  `CityId` INT NOT NULL,
  `HouseNumber` INT NULL,
  `FlatNumber` VARCHAR(45) NULL,
  `PostId` INT NOT NULL,
  PRIMARY KEY (`AddressId`),
  INDEX `fk_Address_City_idx` (`CityId` ASC),
  INDEX `fk_Address_Post1_idx` (`PostId` ASC),
  CONSTRAINT `fk_Address_City`
    FOREIGN KEY (`CityId`)
    REFERENCES `salkadb`.`Cities` (`CityId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Address_Post1`
    FOREIGN KEY (`PostId`)
    REFERENCES `salkadb`.`Posts` (`PostId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`RecordingStudios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`RecordingStudios` (
  `RecordingStudioId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  `Address_idAddress` INT NOT NULL,
  PRIMARY KEY (`RecordingStudioId`),
  INDEX `fk_RecordingStudio_Address1_idx` (`Address_idAddress` ASC),
  CONSTRAINT `fk_RecordingStudio_Address1`
    FOREIGN KEY (`Address_idAddress`)
    REFERENCES `salkadb`.`Addresses` (`AddressId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Clients` (
  `ClientId` INT NOT NULL AUTO_INCREMENT,
  `Bandname` VARCHAR(100) NOT NULL,
  `PhoneNumber` VARCHAR(12) NOT NULL,
  `Email` VARCHAR(100) NOT NULL,
  `RecordingStudioId` INT NOT NULL,
  `AddressId` INT NOT NULL,
  PRIMARY KEY (`ClientId`),
  INDEX `fk_Client_RecordingStudio1_idx` (`RecordingStudioId` ASC),
  INDEX `fk_Client_Address1_idx` (`AddressId` ASC),
  CONSTRAINT `fk_Client_RecordingStudio1`
    FOREIGN KEY (`RecordingStudioId`)
    REFERENCES `salkadb`.`RecordingStudios` (`RecordingStudioId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Client_Address1`
    FOREIGN KEY (`AddressId`)
    REFERENCES `salkadb`.`Addresses` (`AddressId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`ReservationTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`ReservationTypes` (
  `ReservationTypeId` INT NOT NULL AUTO_INCREMENT,
  `Type` VARCHAR(100) NOT NULL,
  `IsProducerRequired` TINYINT NOT NULL,
  PRIMARY KEY (`ReservationTypeId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Staff`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Staff` (
  `idStaff` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NULL,
  `Surname` VARCHAR(100) NULL,
  PRIMARY KEY (`idStaff`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Reservations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Reservations` (
  `ReservationId` INT NOT NULL AUTO_INCREMENT,
  `IsPaymentCompleted` TINYINT NOT NULL,
  `IsAcknowledged` TINYINT NOT NULL,
  `IsRegular` TINYINT NOT NULL,
  `TotalCost` FLOAT NULL,
  `Comment` VARCHAR(45) NULL,
  `NumberOfVocals` VARCHAR(45) NULL,
  `ClientId` INT NOT NULL,
  `ReservationTypeId` INT NOT NULL,
  `StaffId` INT NULL,
  PRIMARY KEY (`ReservationId`),
  INDEX `fk_Reservation_Client1_idx` (`ClientId` ASC),
  INDEX `fk_Reservation_ReservationType1_idx` (`ReservationTypeId` ASC),
  INDEX `fk_Reservation_Staff1_idx` (`StaffId` ASC),
  CONSTRAINT `fk_Reservation_Client1`
    FOREIGN KEY (`ClientId`)
    REFERENCES `salkadb`.`Clients` (`ClientId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Reservation_ReservationType1`
    FOREIGN KEY (`ReservationTypeId`)
    REFERENCES `salkadb`.`ReservationTypes` (`ReservationTypeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Reservation_Staff1`
    FOREIGN KEY (`StaffId`)
    REFERENCES `salkadb`.`Staff` (`idStaff`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`EquipmentCategories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`EquipmentCategories` (
  `EquipmentCategoryId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`EquipmentCategoryId`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Equipments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Equipments` (
  `EquipmentId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Quantity` VARCHAR(45) NOT NULL,
  `Cost` FLOAT NOT NULL,
  `EquipmentCategoryId` INT NOT NULL,
  PRIMARY KEY (`EquipmentId`),
  INDEX `fk_Equipment_EquipmentCategory1_idx` (`EquipmentCategoryId` ASC),
  CONSTRAINT `fk_Equipment_EquipmentCategory1`
    FOREIGN KEY (`EquipmentCategoryId`)
    REFERENCES `salkadb`.`EquipmentCategories` (`EquipmentCategoryId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`Resources`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`Resources` (
  `ResourceId` INT NOT NULL AUTO_INCREMENT,
  `Quantity` VARCHAR(45) NOT NULL,
  `EquipmentId` INT NOT NULL,
  `ReservationId` INT NOT NULL,
  PRIMARY KEY (`ResourceId`),
  INDEX `fk_Resource_Equipment1_idx` (`EquipmentId` ASC),
  INDEX `fk_Resource_Reservation1_idx` (`ReservationId` ASC),
  CONSTRAINT `fk_Resource_Equipment1`
    FOREIGN KEY (`EquipmentId`)
    REFERENCES `salkadb`.`Equipments` (`EquipmentId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Resource_Reservation1`
    FOREIGN KEY (`ReservationId`)
    REFERENCES `salkadb`.`Reservations` (`ReservationId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb`.`ReservationDates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb`.`ReservationDates` (
  `ReservationDateId` INT NOT NULL AUTO_INCREMENT,
  `Date` DATE NOT NULL,
  `Start` DATETIME NOT NULL,
  `End` DATETIME NOT NULL,
  `ScheduleId` INT NOT NULL,
  `ReservationId` INT NOT NULL,
  PRIMARY KEY (`ReservationDateId`),
  INDEX `fk_ReservationDate_Schedule1_idx` (`ScheduleId` ASC),
  INDEX `fk_ReservationDate_Reservation1_idx` (`ReservationId` ASC),
  CONSTRAINT `fk_ReservationDate_Schedule1`
    FOREIGN KEY (`ScheduleId`)
    REFERENCES `salkadb`.`Schedules` (`ScheduleId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ReservationDate_Reservation1`
    FOREIGN KEY (`ReservationId`)
    REFERENCES `salkadb`.`Reservations` (`ReservationId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
