-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema ktmdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ktmdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ktmdb` DEFAULT CHARACTER SET utf8 ;
USE `ktmdb` ;

-- -----------------------------------------------------
-- Table `ktmdb`.`area_incharge`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ktmdb`.`area_incharge` (
  `ID` INT(11) NOT NULL,
  `First Name` VARCHAR(50) NOT NULL,
  `Middle Name` VARCHAR(50) NOT NULL,
  `Last Name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ktmdb`.`area`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ktmdb`.`area` (
  `area_name` VARCHAR(20) NOT NULL,
  `ic` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`area_name`),
  INDEX `f1_idx` (`ic` ASC),
  CONSTRAINT `f1`
    FOREIGN KEY (`ic`)
    REFERENCES `ktmdb`.`area_incharge` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ktmdb`.`workshop`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ktmdb`.`workshop` (
  `wk_code` INT(11) NOT NULL,
  `wk_name` VARCHAR(45) NULL DEFAULT NULL,
  `area` VARCHAR(20) NULL DEFAULT NULL,
  `manpower` INT(11) NULL DEFAULT NULL,
  `customer_visits` INT(11) NULL DEFAULT NULL,
  `recovery` VARCHAR(10) NULL DEFAULT NULL,
  `score` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`wk_code`),
  INDEX `f2_idx` (`area` ASC),
  CONSTRAINT `f2`
    FOREIGN KEY (`area`)
    REFERENCES `ktmdb`.`area` (`area_name`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ktmdb`.`workshop_ic`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ktmdb`.`workshop_ic` (
  `id` INT(11) NOT NULL,
  `fname` VARCHAR(45) NULL DEFAULT NULL,
  `mname` VARCHAR(45) NULL DEFAULT NULL,
  `lname` VARCHAR(45) NULL DEFAULT NULL,
  `rating` INT(11) NULL DEFAULT NULL,
  `area_ic` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `f3_idx` (`area_ic` ASC),
  CONSTRAINT `f3`
    FOREIGN KEY (`area_ic`)
    REFERENCES `ktmdb`.`area_incharge` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ktmdb`.`manages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ktmdb`.`manages` (
  `wk_code` INT(11) NOT NULL,
  `ic_id` INT(11) NOT NULL,
  PRIMARY KEY (`wk_code`, `ic_id`),
  INDEX `f5_idx` (`ic_id` ASC),
  CONSTRAINT `f4`
    FOREIGN KEY (`wk_code`)
    REFERENCES `ktmdb`.`workshop` (`wk_code`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `f5`
    FOREIGN KEY (`ic_id`)
    REFERENCES `ktmdb`.`workshop_ic` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ktmdb`.`revenue`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ktmdb`.`revenue` (
  `wk_code` INT(11) NOT NULL,
  `year` INT(11) NOT NULL,
  `quarter` INT(11) NOT NULL,
  `total_sales` INT(11) NULL DEFAULT NULL,
  `service_cost` INT(11) NULL DEFAULT NULL,
  `profit` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`wk_code`, `year`, `quarter`),
  CONSTRAINT `f6`
    FOREIGN KEY (`wk_code`)
    REFERENCES `ktmdb`.`workshop` (`wk_code`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

USE `ktmdb` ;

-- -----------------------------------------------------
-- procedure Insert_Revenue
-- -----------------------------------------------------

DELIMITER $$
USE `ktmdb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Insert_Revenue`(IN `wk_code` INT, IN `year` INT, IN `quarter` INT, IN `total_sales` INT, IN `service_cost` INT, IN `profit` INT)
BEGIN 
    INSERT INTO revenue(wk_code, year, quarter, total_sales, service_cost, profit) 
    VALUES (`wk_code`, `year`, `quarter`, `total_sales`, `service_cost`, `profit`); 
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure fetching_all_revenues
-- -----------------------------------------------------

DELIMITER $$
USE `ktmdb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `fetching_all_revenues`()
BEGIN
    SELECT * FROM revenue;
END$$

DELIMITER ;
USE `ktmdb`;

DELIMITER $$
USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`after_workshop_deletion`
BEFORE DELETE ON `ktmdb`.`workshop`
FOR EACH ROW
BEGIN
   DELETE FROM manages WHERE wk_code = OLD.wk_code;
END$$

USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`before_workshop_deletion_rev`
BEFORE DELETE ON `ktmdb`.`workshop`
FOR EACH ROW
BEGIN
   DELETE FROM revenue WHERE wk_code = OLD.wk_code;
END$$

USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`score_calculation`
BEFORE INSERT ON `ktmdb`.`workshop`
FOR EACH ROW
BEGIN
   SET NEW.score = FLOOR((NEW.manpower / 100 * 4) + (NEW.customer_visits / 1000 * 4) + (IF(NEW.recovery = 'yes', 2, 0)));
END$$

USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`score_calculation_before_update`
BEFORE UPDATE ON `ktmdb`.`workshop`
FOR EACH ROW
BEGIN
   SET NEW.score = FLOOR((NEW.manpower / 100 * 4) + (NEW.customer_visits / 1000 * 4) + (IF(NEW.recovery = 'yes', 2, 0)));
END$$

USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`after_incharge_deletion`
BEFORE DELETE ON `ktmdb`.`workshop_ic`
FOR EACH ROW
BEGIN
   DELETE FROM manages WHERE ic_id = OLD.id;
END$$

USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`profit_adjust`
BEFORE INSERT ON `ktmdb`.`revenue`
FOR EACH ROW
BEGIN
   SET NEW.profit = NEW.total_sales - NEW.service_cost;
END$$

USE `ktmdb`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `ktmdb`.`profit_adjust_before_update`
BEFORE UPDATE ON `ktmdb`.`revenue`
FOR EACH ROW
BEGIN
   SET NEW.profit = NEW.total_sales - NEW.service_cost;
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
