-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema salkadb.client
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema salkadb.client
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `salkadb.client` DEFAULT CHARACTER SET utf8 ;
USE `salkadb.client` ;

-- -----------------------------------------------------
-- Table `salkadb.client`.`Cities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.client`.`Cities` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.client`.`Posts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.client`.`Posts` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `PostalCode` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.client`.`Addresses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.client`.`Addresses` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Street` VARCHAR(45) NULL,
  `CityId` INT NOT NULL,
  `HouseNumber` INT NULL,
  `FlatNumber` INT NULL,
  `PostId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Address_City_idx` (`CityId` ASC),
  INDEX `fk_Address_Post1_idx` (`PostId` ASC),
  CONSTRAINT `fk_Address_City`
    FOREIGN KEY (`CityId`)
    REFERENCES `salkadb.client`.`Cities` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Address_Post1`
    FOREIGN KEY (`PostId`)
    REFERENCES `salkadb.client`.`Posts` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.client`.`RecordingStudios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.client`.`RecordingStudios` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  `AddressId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_RecordingStudio_Address1_idx` (`AddressId` ASC),
  CONSTRAINT `fk_RecordingStudio_Address1`
    FOREIGN KEY (`AddressId`)
    REFERENCES `salkadb.client`.`Addresses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.client`.`Clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.client`.`Clients` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Bandname` VARCHAR(100) NOT NULL,
  `PhoneNumber` VARCHAR(12) NOT NULL,
  `Email` VARCHAR(100) NOT NULL,
  `RecordingStudioId` INT NOT NULL,
  `AddressId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Client_RecordingStudio1_idx` (`RecordingStudioId` ASC),
  INDEX `fk_Client_Address1_idx` (`AddressId` ASC),
  CONSTRAINT `fk_Client_RecordingStudio1`
    FOREIGN KEY (`RecordingStudioId`)
    REFERENCES `salkadb.client`.`RecordingStudios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Client_Address1`
    FOREIGN KEY (`AddressId`)
    REFERENCES `salkadb.client`.`Addresses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.client`.`Staff`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.client`.`Staff` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NULL,
  `Surname` VARCHAR(100) NULL,
  `AddressId` INT NOT NULL,
  `RecordingStudioId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Staff_Addresses1_idx` (`AddressId` ASC),
  INDEX `fk_Staff_RecordingStudios1_idx` (`RecordingStudioId` ASC),
  CONSTRAINT `fk_Staff_Addresses1`
    FOREIGN KEY (`AddressId`)
    REFERENCES `salkadb.client`.`Addresses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Staff_RecordingStudios1`
    FOREIGN KEY (`RecordingStudioId`)
    REFERENCES `salkadb.client`.`RecordingStudios` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
