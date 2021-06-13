-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema salkadb.equipment
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema salkadb.equipment
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `salkadb.equipment` DEFAULT CHARACTER SET utf8 ;
USE `salkadb.equipment` ;

-- -----------------------------------------------------
-- Table `salkadb.equipment`.`EquipmentCategories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.equipment`.`EquipmentCategories` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.equipment`.`Equipments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.equipment`.`Equipments` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Quantity` INT NOT NULL,
  `Cost` FLOAT NOT NULL,
  `EquipmentCategoryId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Equipment_EquipmentCategory1_idx` (`EquipmentCategoryId` ASC),
  CONSTRAINT `fk_Equipment_EquipmentCategory1`
    FOREIGN KEY (`EquipmentCategoryId`)
    REFERENCES `salkadb.equipment`.`EquipmentCategories` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `salkadb.equipment`.`Resources`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `salkadb.equipment`.`Resources` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Quantity` INT NOT NULL,
  `EquipmentId` INT NOT NULL,
  `ReservationId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Resource_Equipment1_idx` (`EquipmentId` ASC),
  CONSTRAINT `fk_Resource_Equipment1`
    FOREIGN KEY (`EquipmentId`)
    REFERENCES `salkadb.equipment`.`Equipments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
