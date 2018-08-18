-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               5.7.21-log - MySQL Community Server (GPL)
-- Server OS:                    Win32
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for smartpos
CREATE DATABASE IF NOT EXISTS `smartpos` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `smartpos`;

-- Dumping structure for table smartpos.accessright
CREATE TABLE IF NOT EXISTS `accessright` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(1024) NOT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `ControlName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.customer
CREATE TABLE IF NOT EXISTS `customer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) NOT NULL,
  `Address` varchar(1024) NOT NULL,
  `CreatedById` int(11) NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Deleted` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Customer_User_CreatedById` (`CreatedById`),
  CONSTRAINT `FK_Customer_User_CreatedById` FOREIGN KEY (`CreatedById`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.menucategory
CREATE TABLE IF NOT EXISTS `menucategory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `ParentId` int(11) DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_MenuCategory_MenuCategory_ParentId` (`ParentId`),
  CONSTRAINT `FK_MenuCategory_MenuCategory_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `menucategory` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.order
CREATE TABLE IF NOT EXISTS `order` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Number` int(11) NOT NULL,
  `TableId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `State` varchar(255) NOT NULL,
  `CustomerId` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Metadata` varchar(255) DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_Order_Table_TableId` (`TableId`),
  KEY `FK_Order_User_UserId` (`UserId`),
  CONSTRAINT `FK_Order_Table_TableId` FOREIGN KEY (`TableId`) REFERENCES `table` (`Id`),
  CONSTRAINT `FK_Order_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.orderitem
CREATE TABLE IF NOT EXISTS `orderitem` (
  `OrderId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `Name` varchar(256) NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  `Quantity` double NOT NULL,
  `CretedBy` int(11) NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `State` varchar(255) NOT NULL DEFAULT '0',
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`),
  KEY `FK_OrderItem_Order_OrderId` (`OrderId`),
  KEY `FK_OrderItem_Product_ProductId` (`ProductId`),
  KEY `FK_OrderItem_User_CretedBy` (`CretedBy`),
  CONSTRAINT `FK_OrderItem_Order_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `order` (`Id`),
  CONSTRAINT `FK_OrderItem_Product_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`),
  CONSTRAINT `FK_OrderItem_User_CretedBy` FOREIGN KEY (`CretedBy`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.product
CREATE TABLE IF NOT EXISTS `product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Metadata` varchar(255) DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_Product_MenuCategory_CategoryId` (`CategoryId`),
  CONSTRAINT `FK_Product_MenuCategory_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `menucategory` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=118 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.table
CREATE TABLE IF NOT EXISTS `table` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) NOT NULL,
  `ZoneId` int(11) NOT NULL,
  `Left` int(11) NOT NULL,
  `Top` int(11) NOT NULL,
  `Width` int(11) NOT NULL,
  `Height` int(11) NOT NULL,
  `Metadata` varchar(255) DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_Table_Zone_ZoneId` (`ZoneId`),
  CONSTRAINT `FK_Table_Zone_ZoneId` FOREIGN KEY (`ZoneId`) REFERENCES `zone` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.user
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FullName` varchar(128) NOT NULL,
  `Email` varchar(128) NOT NULL,
  `Pin` varchar(128) NOT NULL,
  `Access` varchar(255) NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Suspended` tinyint(1) NOT NULL DEFAULT '0',
  `Metadata` varchar(255) DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  `Rights` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.useraccessright
CREATE TABLE IF NOT EXISTS `useraccessright` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AccessRightId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Read` varchar(255) NOT NULL DEFAULT '0',
  `Create` varchar(255) NOT NULL DEFAULT '0',
  `Update` varchar(255) NOT NULL DEFAULT '0',
  `Delete` varchar(255) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `FK_UserAccessRight_AccessRight_AccessRightId` (`AccessRightId`),
  KEY `FK_UserAccessRight_User_UserId` (`UserId`),
  CONSTRAINT `FK_UserAccessRight_AccessRight_AccessRightId` FOREIGN KEY (`AccessRightId`) REFERENCES `accessright` (`Id`),
  CONSTRAINT `FK_UserAccessRight_User_UserId` FOREIGN KEY (`UserId`) REFERENCES `user` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
-- Dumping structure for table smartpos.zone
CREATE TABLE IF NOT EXISTS `zone` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) NOT NULL,
  `Order` int(11) NOT NULL DEFAULT '0',
  `Metadata` varchar(255) DEFAULT NULL,
  `Deleted` tinyint(1) NOT NULL DEFAULT '0',
  `Tables` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
