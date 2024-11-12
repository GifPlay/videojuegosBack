-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3306
-- Tiempo de generación: 12-11-2024 a las 23:53:58
-- Versión del servidor: 8.0.30
-- Versión de PHP: 8.2.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `videogames`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clasificacion`
--

CREATE TABLE `clasificacion` (
  `idClasificacion` int NOT NULL,
  `clasificacion` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `edad` int NOT NULL,
  `descripcion` varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `clasificacion`
--

INSERT INTO `clasificacion` (`idClasificacion`, `clasificacion`, `edad`, `descripcion`, `created_at`, `updated_at`) VALUES
(1, 'PEGI 3', 3, ' Todas las edades. El juego no contiene sonidos e imágenes susceptibles de asustar a los más pequeños', NULL, NULL),
(2, 'PEGI 7', 7, ' Niños pequeños', NULL, '2024-11-12 08:52:23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `consolas`
--

CREATE TABLE `consolas` (
  `idConsola` int NOT NULL,
  `empresa` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `lanzamiento` year NOT NULL,
  `nombre` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `consolas`
--

INSERT INTO `consolas` (`idConsola`, `empresa`, `lanzamiento`, `nombre`, `created_at`, `updated_at`) VALUES
(1, 'Nintendo', '2017', 'NINTENDO SWITCH 1.0', '2024-11-12 06:35:53', NULL),
(4, 'SONY', '2023', 'PLAYSTATION5', NULL, '2024-11-12 20:45:00'),
(5, 'SONY', '2013', 'PLAYSTATION4', NULL, '2024-11-12 07:39:48');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `generos`
--

CREATE TABLE `generos` (
  `idGenero` int NOT NULL,
  `nombre` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `descripcion` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `generos`
--

INSERT INTO `generos` (`idGenero`, `nombre`, `descripcion`, `created_at`, `updated_at`) VALUES
(1, 'Acción', 'Género caracterizado por el frenetismo y una gran inmersión. Implican realizar alguna acción repetitiva como pulsar mucho ciertas combinaciones de botones para realizar un movimiento. Debido a esto, suelen exigir una alta concentración.', '2024-11-12 04:09:06', NULL),
(2, 'Aventura', 'El protagonista del juego debe atravesar extensos niveles repletos de muchos enemigos y valerse de diferentes ítems para lograr sus objetivos. Suelen tener un buen argumento y una duración moderada.', '2024-11-12 04:09:06', NULL),
(3, 'Arcade', 'Se trata de juegos sencillos que manejan elementos de poca complejidad como una aventura, laberintos o plataformas. Es necesario atravesar diferentes pantallas para avanzar. Su ritmo facilita adaptarse rápido al juego por primera vez.', NULL, NULL),
(4, 'Deportes', 'Tal y como indica su nombre, se trata de juegos basados en deportes reales como fútbol, boxeo, golf, tenis o baloncesto, entre otros.', NULL, '2024-11-12 04:39:55'),
(6, 'Simulación', 'Permiten experimentar situaciones como pilotar naves, construir universos o diseñar personajes. Todo simulado', NULL, '2024-11-12 09:27:12');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `juegos`
--

CREATE TABLE `juegos` (
  `idJuego` int NOT NULL,
  `titulo` varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  `descripcion` varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  `anio` year NOT NULL,
  `calificacion` double NOT NULL,
  `jugadores` int NOT NULL,
  `franquicia` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `idConsola` int NOT NULL,
  `idClasificacion` int NOT NULL,
  `idGenero` int NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `juegos`
--

INSERT INTO `juegos` (`idJuego`, `titulo`, `descripcion`, `anio`, `calificacion`, `jugadores`, `franquicia`, `idConsola`, `idClasificacion`, `idGenero`, `created_at`, `updated_at`) VALUES
(1, 'The Legend of Zelda ', 'Echoes of Wisdom', '2024', 9, 1, 'The Legend of Zelda ', 1, 1, 2, NULL, '2024-11-12 19:25:51'),
(2, 'Emio – The Smiling Man', 'Famicom Detective Club', '2023', 8, 1, 'Famicom Detective Club', 1, 2, 1, NULL, '2024-11-12 20:18:21'),
(3, 'Super Mario Bros.™ Wonder', 'Super Mario Bros.™ Wonder', '2021', 10, 2, 'Super Mario Bros', 1, 2, 3, NULL, '2024-11-12 20:18:26'),
(4, 'GRAN TURISMO 7', 'GRAN TURISMO', '2007', 6, 2, 'GRAN TURISMO', 5, 2, 6, NULL, '2024-11-12 20:45:21'),
(5, 'Returnal 2', 'Tras un aterrizaje forzoso en este mundo cambiante, Selene debe explorar el paisaje desolado de una antigua civilización para escapar.', '2021', 8, 2, 'Retunal', 4, 2, 2, NULL, '2024-11-12 20:52:48'),
(6, 'GRAN TURISMO 7', 'GRAN TURISMO', '2007', 6, 2, 'GRAN TURISMO', 4, 2, 6, NULL, NULL),
(7, 'GRAN TURISMO 7', 'GRAN TURISMO', '2007', 6, 2, 'GRAN TURISMO', 4, 2, 6, NULL, NULL),
(8, 'GRAN TURISMO 7', 'GRAN TURISMO', '2007', 6, 2, 'GRAN TURISMO', 4, 2, 6, NULL, NULL),
(11, 'Returnal', 'Tras un aterrizaje forzoso en este mundo cambiante, Selene debe explorar el paisaje desolado de una antigua civilización para escapar.', '2021', 8, 1, 'Retunal', 4, 2, 2, NULL, NULL),
(12, 'GRAN TURISMO 7', 'GRAN TURISMO', '2007', 6, 2, 'GRAN TURISMO', 4, 2, 6, NULL, NULL),
(14, 'Returnal', 'Tras un aterrizaje forzoso en este mundo cambiante, Selene debe explorar el paisaje desolado de una antigua civilización para escapar.', '2021', 8, 1, 'Retunal', 1, 1, 2, NULL, NULL),
(17, 'Returnal 2', 'Tras un aterrizaje forzoso en este mundo cambiante, Selene debe explorar el paisaje desolado de una antigua civilización para escapar.', '2021', 8, 1, 'Retunal', 4, 2, 1, NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `juego_genero`
--

CREATE TABLE `juego_genero` (
  `idJuegoGenero` int NOT NULL,
  `idJuego` int NOT NULL,
  `idGenero` int NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `view_juegos_consola_clasificacion`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `view_juegos_consola_clasificacion` (
`idJuego` int
,`titulo` varchar(250)
,`descripcion` varchar(250)
,`anio` year
,`calificacion` double
,`jugadores` int
,`franquicia` varchar(100)
,`idConsola` int
,`idClasificacion` int
,`created_at` timestamp
,`updated_at` timestamp
,`nombre` varchar(150)
,`empresa` varchar(100)
,`clasificacion` varchar(20)
,`edad` int
,`genero` varchar(50)
,`idGenero` int
);

-- --------------------------------------------------------

--
-- Estructura para la vista `view_juegos_consola_clasificacion`
--
DROP TABLE IF EXISTS `view_juegos_consola_clasificacion`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_juegos_consola_clasificacion`  AS SELECT `juegos`.`idJuego` AS `idJuego`, `juegos`.`titulo` AS `titulo`, `juegos`.`descripcion` AS `descripcion`, `juegos`.`anio` AS `anio`, `juegos`.`calificacion` AS `calificacion`, `juegos`.`jugadores` AS `jugadores`, `juegos`.`franquicia` AS `franquicia`, `juegos`.`idConsola` AS `idConsola`, `juegos`.`idClasificacion` AS `idClasificacion`, `juegos`.`created_at` AS `created_at`, `juegos`.`updated_at` AS `updated_at`, `consolas`.`nombre` AS `nombre`, `consolas`.`empresa` AS `empresa`, `clasificacion`.`clasificacion` AS `clasificacion`, `clasificacion`.`edad` AS `edad`, `generos`.`nombre` AS `genero`, `juegos`.`idGenero` AS `idGenero` FROM (((`juegos` join `consolas` on((`consolas`.`idConsola` = `juegos`.`idConsola`))) join `clasificacion` on((`clasificacion`.`idClasificacion` = `juegos`.`idClasificacion`))) join `generos` on((`generos`.`idGenero` = `juegos`.`idGenero`))) ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `clasificacion`
--
ALTER TABLE `clasificacion`
  ADD PRIMARY KEY (`idClasificacion`);

--
-- Indices de la tabla `consolas`
--
ALTER TABLE `consolas`
  ADD PRIMARY KEY (`idConsola`);

--
-- Indices de la tabla `generos`
--
ALTER TABLE `generos`
  ADD PRIMARY KEY (`idGenero`);

--
-- Indices de la tabla `juegos`
--
ALTER TABLE `juegos`
  ADD PRIMARY KEY (`idJuego`);

--
-- Indices de la tabla `juego_genero`
--
ALTER TABLE `juego_genero`
  ADD PRIMARY KEY (`idJuegoGenero`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `clasificacion`
--
ALTER TABLE `clasificacion`
  MODIFY `idClasificacion` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `consolas`
--
ALTER TABLE `consolas`
  MODIFY `idConsola` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `generos`
--
ALTER TABLE `generos`
  MODIFY `idGenero` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `juegos`
--
ALTER TABLE `juegos`
  MODIFY `idJuego` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `juego_genero`
--
ALTER TABLE `juego_genero`
  MODIFY `idJuegoGenero` int NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
