-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema salkadb.schedule
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema salkadb.schedule
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `salkadb.schedule` DEFAULT CHARACTER SET utf8 ;
USE `salkadb.schedule` ;

-- -----------------------------------------------------
-- Table `salkadb.schedule`.`Schedules`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.schedule`.`Schedules` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.schedule`.`ReservationTypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.schedule`.`ReservationTypes` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Type` VARCHAR(100) NOT NULL,
  `IsProducerRequired` TINYINT NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.schedule`.`Reservations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.schedule`.`Reservations` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IsPaymentCompleted` TINYINT NOT NULL,
  `IsAcknowledged` TINYINT NOT NULL,
  `IsRegular` TINYINT NOT NULL,
  `TotalCost` FLOAT NULL,
  `Comment` VARCHAR(45) NULL,
  `NumberOfVocals` VARCHAR(45) NULL,
  `ClientId` INT NOT NULL,
  `ReservationTypeId` INT NOT NULL,
  `StaffId` INT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Reservation_ReservationType1_idx` (`ReservationTypeId` ASC),
  CONSTRAINT `fk_Reservation_ReservationType1`
    FOREIGN KEY (`ReservationTypeId`)
    REFERENCES `salkadb.schedule`.`ReservationTypes` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.schedule`.`ReservationDates`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.schedule`.`ReservationDates` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Date` DATE NOT NULL,
  `Start` DATETIME NOT NULL,
  `End` DATETIME NOT NULL,
  `ScheduleId` INT NOT NULL,
  `ReservationId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_ReservationDate_Schedule1_idx` (`ScheduleId` ASC),
  INDEX `fk_ReservationDate_Reservation1_idx` (`ReservationId` ASC),
  CONSTRAINT `fk_ReservationDate_Schedule1`
    FOREIGN KEY (`ScheduleId`)
    REFERENCES `salkadb.schedule`.`Schedules` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ReservationDate_Reservation1`
    FOREIGN KEY (`ReservationId`)
    REFERENCES `salkadb.schedule`.`Reservations` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
