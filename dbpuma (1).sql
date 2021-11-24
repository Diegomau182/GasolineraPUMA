-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 18-11-2021 a las 00:44:37
-- Versión del servidor: 10.4.19-MariaDB
-- Versión de PHP: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dbpuma`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `idCategoria` int(11) NOT NULL,
  `nombreCategoria` varchar(50) DEFAULT NULL,
  `descricpionCategoria` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detallecompra`
--

CREATE TABLE `detallecompra` (
  `idDetalleCompra` int(11) NOT NULL,
  `idEncabezadoCompra` int(11) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `subTotal` decimal(10,2) DEFAULT NULL,
  `producto` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalleventa`
--

CREATE TABLE `detalleventa` (
  `idDetalleVenta` int(11) NOT NULL,
  `idEncabezadoVenta` int(11) DEFAULT NULL,
  `idProducto` int(11) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `subTotal` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encabezadocompra`
--

CREATE TABLE `encabezadocompra` (
  `idEncabezadoCompra` int(11) NOT NULL,
  `fecha` date DEFAULT NULL,
  `idProveedor` varchar(14) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encabezadoventa`
--

CREATE TABLE `encabezadoventa` (
  `idEncabezadoVenta` int(11) NOT NULL,
  `fecha` date DEFAULT current_timestamp(),
  `cliente` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `idProducto` int(11) NOT NULL,
  `nombreProducto` varchar(45) DEFAULT NULL,
  `descripcionProducto` varchar(45) DEFAULT NULL,
  `idCategoria` int(11) DEFAULT NULL,
  `idProveedor` varchar(14) DEFAULT NULL,
  `precioProducto` decimal(10,2) DEFAULT NULL,
  `cantidadProducto` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `RTNProveedor` varchar(14) NOT NULL,
  `empresaProveedor` varchar(100) DEFAULT NULL,
  `nombreProveedor` varchar(50) DEFAULT NULL,
  `apellidoProveedor` varchar(50) DEFAULT NULL,
  `emailProveedor` varchar(50) DEFAULT NULL,
  `telefonoProveedor` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`idCategoria`);

--
-- Indices de la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  ADD PRIMARY KEY (`idDetalleCompra`),
  ADD KEY `DETALLEC_ENCABEZADOC_idx` (`idEncabezadoCompra`),
  ADD KEY `detalle_producto_idx` (`producto`);

--
-- Indices de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  ADD PRIMARY KEY (`idDetalleVenta`),
  ADD KEY `PRODUCTO_DVENTA_idx` (`idProducto`),
  ADD KEY `ENV_VENTA_idx` (`idEncabezadoVenta`);

--
-- Indices de la tabla `encabezadocompra`
--
ALTER TABLE `encabezadocompra`
  ADD PRIMARY KEY (`idEncabezadoCompra`),
  ADD KEY `COMPRA_PROVEEDOR_idx` (`idProveedor`);

--
-- Indices de la tabla `encabezadoventa`
--
ALTER TABLE `encabezadoventa`
  ADD PRIMARY KEY (`idEncabezadoVenta`);

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`idProducto`),
  ADD KEY `PRODUCTO_PROVEEDOR_idx` (`idProveedor`),
  ADD KEY `PRODUCTO_CATEGORIA_idx` (`idCategoria`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`RTNProveedor`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  MODIFY `idDetalleCompra` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  MODIFY `idDetalleVenta` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  ADD CONSTRAINT `DETALLEC_ENCABEZADOC` FOREIGN KEY (`idEncabezadoCompra`) REFERENCES `encabezadocompra` (`idEncabezadoCompra`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `detalle_producto` FOREIGN KEY (`producto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  ADD CONSTRAINT `ENV_VENTA` FOREIGN KEY (`idEncabezadoVenta`) REFERENCES `encabezadoventa` (`idEncabezadoVenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `PRODUCTO_DVENTA` FOREIGN KEY (`idProducto`) REFERENCES `producto` (`idProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `encabezadocompra`
--
ALTER TABLE `encabezadocompra`
  ADD CONSTRAINT `COMPRA_PROVEEDOR` FOREIGN KEY (`idProveedor`) REFERENCES `proveedor` (`RTNProveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `PRODUCTO_CATEGORIA` FOREIGN KEY (`idCategoria`) REFERENCES `categoria` (`idCategoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `PRODUCTO_PROVEEDOR` FOREIGN KEY (`idProveedor`) REFERENCES `proveedor` (`RTNProveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
