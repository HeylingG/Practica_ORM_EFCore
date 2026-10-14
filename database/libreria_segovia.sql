-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         12.3.3-MariaDB - MariaDB Server
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.20.0.7320
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para libreria_segovia
CREATE DATABASE IF NOT EXISTS `libreria_segovia` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `libreria_segovia`;

-- Volcando estructura para tabla libreria_segovia.categorias
CREATE TABLE IF NOT EXISTS `categorias` (
  `id_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(60) NOT NULL,
  PRIMARY KEY (`id_categoria`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Volcando datos para la tabla libreria_segovia.categorias: ~4 rows (aproximadamente)
INSERT INTO `categorias` (`id_categoria`, `nombre`) VALUES
	(1, 'Papelería'),
	(2, 'Útiles escolares'),
	(3, 'Arte y manualidades'),
	(4, 'Tecnología');

-- Volcando estructura para tabla libreria_segovia.productos
CREATE TABLE IF NOT EXISTS `productos` (
  `id_producto` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `precio` decimal(10,2) NOT NULL DEFAULT 0.00,
  `existencia` int(11) NOT NULL DEFAULT 0,
  `id_categoria` int(11) NOT NULL,
  `version_fila` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id_producto`),
  KEY `fk_producto_categoria` (`id_categoria`),
  CONSTRAINT `fk_producto_categoria` FOREIGN KEY (`id_categoria`) REFERENCES `categorias` (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Volcando datos para la tabla libreria_segovia.productos: ~6 rows (aproximadamente)
INSERT INTO `productos` (`id_producto`, `nombre`, `precio`, `existencia`, `id_categoria`, `version_fila`) VALUES
	(1, 'Cuaderno universitario 100 hojas', 85.00, 40, 1, 1),
	(2, 'Resma de papel carta', 260.00, 25, 1, 1),
	(3, 'Lapicero azul (unidad)', 12.00, 300, 2, 1),
	(4, 'Mochila escolar', 650.00, 12, 2, 1),
	(5, 'Caja de témperas 12 colores', 145.00, 18, 3, 1),
	(6, 'Memoria USB 32 GB', 320.00, 10, 4, 1);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
