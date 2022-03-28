-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 28 mrt 2022 om 16:45
-- Serverversie: 10.4.24-MariaDB
-- PHP-versie: 8.1.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Database: `foodle`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `amount_type`
--

CREATE TABLE `amount_type` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `cuisine_label`
--

CREATE TABLE `cuisine_label` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `cuisine_label_filter`
--

CREATE TABLE `cuisine_label_filter` (
  `cuisine_label_id` int(11) NOT NULL,
  `filter_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `diet`
--

CREATE TABLE `diet` (
  `user_id` int(11) NOT NULL,
  `diet_name` varchar(50) NOT NULL,
  `diet_description` varchar(5000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `diet_label`
--

CREATE TABLE `diet_label` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `diet_label_filter`
--

CREATE TABLE `diet_label_filter` (
  `diet_label_id` int(11) NOT NULL,
  `filter_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `diet_nutrients`
--

CREATE TABLE `diet_nutrients` (
  `id` int(11) NOT NULL,
  `diet_id` int(11) NOT NULL,
  `nutrient_type_id` int(11) NOT NULL,
  `recommended_amount` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `dish_type`
--

CREATE TABLE `dish_type` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `dish_type_filter`
--

CREATE TABLE `dish_type_filter` (
  `dish_type_id` int(11) NOT NULL,
  `filter_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `filter`
--

CREATE TABLE `filter` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `text_filter` varchar(50) NOT NULL,
  `min_cal` int(11) NOT NULL,
  `max_cal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `food_amount`
--

CREATE TABLE `food_amount` (
  `id` int(11) NOT NULL,
  `date` date NOT NULL,
  `food_api_id` varchar(50) NOT NULL,
  `amount_type_id` int(11) NOT NULL,
  `amount_value` float NOT NULL,
  `user_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `health_label`
--

CREATE TABLE `health_label` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `health_label_filter`
--

CREATE TABLE `health_label_filter` (
  `health_label_id` int(11) NOT NULL,
  `filter_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `meal_type`
--

CREATE TABLE `meal_type` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `meal_type_filter`
--

CREATE TABLE `meal_type_filter` (
  `meal_type_id` int(11) NOT NULL,
  `filter_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `nutrient_type`
--

CREATE TABLE `nutrient_type` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `window_color_hex` varchar(6) NOT NULL,
  `username` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `workout`
--

CREATE TABLE `workout` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `workout_session`
--

CREATE TABLE `workout_session` (
  `id` int(11) NOT NULL,
  `workout_id` int(11) NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `calories_burned` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `amount_type`
--
ALTER TABLE `amount_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `cuisine_label`
--
ALTER TABLE `cuisine_label`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `cuisine_label_filter`
--
ALTER TABLE `cuisine_label_filter`
  ADD PRIMARY KEY (`cuisine_label_id`,`filter_id`),
  ADD KEY `fk_cuisine_label_filter_filter` (`filter_id`);

--
-- Indexen voor tabel `diet`
--
ALTER TABLE `diet`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexen voor tabel `diet_label`
--
ALTER TABLE `diet_label`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `diet_label_filter`
--
ALTER TABLE `diet_label_filter`
  ADD PRIMARY KEY (`diet_label_id`,`filter_id`),
  ADD KEY `diet_label_filter_filter_id` (`filter_id`);

--
-- Indexen voor tabel `diet_nutrients`
--
ALTER TABLE `diet_nutrients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_diet_nutrients_diet` (`diet_id`),
  ADD KEY `fk_diet_nutrients_nutrient_type` (`nutrient_type_id`);

--
-- Indexen voor tabel `dish_type`
--
ALTER TABLE `dish_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `dish_type_filter`
--
ALTER TABLE `dish_type_filter`
  ADD PRIMARY KEY (`dish_type_id`,`filter_id`),
  ADD KEY `fk_dish_type_filter_filter_id` (`filter_id`);

--
-- Indexen voor tabel `filter`
--
ALTER TABLE `filter`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_filter_user` (`user_id`);

--
-- Indexen voor tabel `food_amount`
--
ALTER TABLE `food_amount`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_food_amount_amount_type_id` (`amount_type_id`),
  ADD KEY `fk_food_amount_user_id` (`user_id`);

--
-- Indexen voor tabel `health_label`
--
ALTER TABLE `health_label`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `health_label_filter`
--
ALTER TABLE `health_label_filter`
  ADD PRIMARY KEY (`health_label_id`,`filter_id`),
  ADD KEY `fk_health_Label_filter_filter_id` (`filter_id`);

--
-- Indexen voor tabel `meal_type`
--
ALTER TABLE `meal_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `meal_type_filter`
--
ALTER TABLE `meal_type_filter`
  ADD PRIMARY KEY (`meal_type_id`,`filter_id`),
  ADD KEY `fk_meal_type_filter_filter` (`filter_id`);

--
-- Indexen voor tabel `nutrient_type`
--
ALTER TABLE `nutrient_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- Indexen voor tabel `workout`
--
ALTER TABLE `workout`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_workout_user` (`user_id`);

--
-- Indexen voor tabel `workout_session`
--
ALTER TABLE `workout_session`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_workout_session_workout` (`workout_id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `amount_type`
--
ALTER TABLE `amount_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `cuisine_label`
--
ALTER TABLE `cuisine_label`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `diet`
--
ALTER TABLE `diet`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `diet_label`
--
ALTER TABLE `diet_label`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `diet_nutrients`
--
ALTER TABLE `diet_nutrients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `dish_type`
--
ALTER TABLE `dish_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `filter`
--
ALTER TABLE `filter`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `food_amount`
--
ALTER TABLE `food_amount`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `health_label`
--
ALTER TABLE `health_label`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `meal_type`
--
ALTER TABLE `meal_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `nutrient_type`
--
ALTER TABLE `nutrient_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `workout`
--
ALTER TABLE `workout`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `workout_session`
--
ALTER TABLE `workout_session`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `cuisine_label_filter`
--
ALTER TABLE `cuisine_label_filter`
  ADD CONSTRAINT `fk_cuisine_label_filter_cuisine_label` FOREIGN KEY (`cuisine_label_id`) REFERENCES `cuisine_label` (`id`),
  ADD CONSTRAINT `fk_cuisine_label_filter_filter` FOREIGN KEY (`filter_id`) REFERENCES `filter` (`id`);

--
-- Beperkingen voor tabel `diet`
--
ALTER TABLE `diet`
  ADD CONSTRAINT `fk_diet_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Beperkingen voor tabel `diet_label_filter`
--
ALTER TABLE `diet_label_filter`
  ADD CONSTRAINT `diet_label_filter_filter_id` FOREIGN KEY (`filter_id`) REFERENCES `filter` (`id`) ,
  ADD CONSTRAINT `fk_diet_label_filter_diet_label_id` FOREIGN KEY (`diet_label_id`) REFERENCES `diet_label` (`id`) ;

--
-- Beperkingen voor tabel `diet_nutrients`
--
ALTER TABLE `diet_nutrients`
  ADD CONSTRAINT `fk_diet_nutrients_diet` FOREIGN KEY (`diet_id`) REFERENCES `diet` (`user_id`),
  ADD CONSTRAINT `fk_diet_nutrients_nutrient_type` FOREIGN KEY (`nutrient_type_id`) REFERENCES `nutrient_type` (`id`);

--
-- Beperkingen voor tabel `dish_type_filter`
--
ALTER TABLE `dish_type_filter`
  ADD CONSTRAINT `fk_dish_type_filter_dish_type_id` FOREIGN KEY (`dish_type_id`) REFERENCES `dish_type` (`id`) ,
  ADD CONSTRAINT `fk_dish_type_filter_filter_id` FOREIGN KEY (`filter_id`) REFERENCES `filter` (`id`);

--
-- Beperkingen voor tabel `filter`
--
ALTER TABLE `filter`
  ADD CONSTRAINT `fk_filter_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Beperkingen voor tabel `food_amount`
--
ALTER TABLE `food_amount`
  ADD CONSTRAINT `fk_food_amount_amount_type_id` FOREIGN KEY (`amount_type_id`) REFERENCES `amount_type` (`id`),
  ADD CONSTRAINT `fk_food_amount_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Beperkingen voor tabel `health_label_filter`
--
ALTER TABLE `health_label_filter`
  ADD CONSTRAINT `fk_health_Label_filter_filter_id` FOREIGN KEY (`filter_id`) REFERENCES `filter` (`id`) ,
  ADD CONSTRAINT `fk_health_label_filter_heal_label_id` FOREIGN KEY (`health_label_id`) REFERENCES `health_label` (`id`) ;

--
-- Beperkingen voor tabel `meal_type_filter`
--
ALTER TABLE `meal_type_filter`
  ADD CONSTRAINT `fk_meal_type_filter_filter` FOREIGN KEY (`filter_id`) REFERENCES `filter` (`id`),
  ADD CONSTRAINT `fk_meal_type_filter_meal_type` FOREIGN KEY (`meal_type_id`) REFERENCES `meal_type` (`id`);

--
-- Beperkingen voor tabel `workout`
--
ALTER TABLE `workout`
  ADD CONSTRAINT `fk_workout_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Beperkingen voor tabel `workout_session`
--
ALTER TABLE `workout_session`
  ADD CONSTRAINT `fk_workout_session_workout` FOREIGN KEY (`workout_id`) REFERENCES `workout` (`id`);
COMMIT;