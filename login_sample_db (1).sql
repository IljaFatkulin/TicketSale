-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Янв 10 2023 г., 23:09
-- Версия сервера: 10.4.27-MariaDB
-- Версия PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `login_sample_db`
--

-- --------------------------------------------------------

--
-- Структура таблицы `news`
--

CREATE TABLE `news` (
  `id` int(11) NOT NULL,
  `text` varchar(10000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Дамп данных таблицы `news`
--

INSERT INTO `news` (`id`, `text`) VALUES
(1, 'gasfask,djmnas kldmas\r\nsa\r\ndsl;?dklas\r\ndasdas\r\nfd\r\nas,\r\nf\r\nmas.faslkglp231\r\n12\r\n4\r\nas;\r\n\r\nl;\r\n;l2'),
(2, 'bbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb f4444444444444444444444444bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbbbbbbbbbbbbbbbb bbbbbbb bbbbbbb bbbbbbb');

-- --------------------------------------------------------

--
-- Структура таблицы `tickets`
--

CREATE TABLE `tickets` (
  `ticket_id` bigint(20) NOT NULL,
  `price` bigint(20) NOT NULL,
  `departure_date` varchar(100) NOT NULL,
  `arrival_date` varchar(100) NOT NULL,
  `departure_city` varchar(100) NOT NULL,
  `arrival_city` varchar(100) NOT NULL,
  `purchases` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Дамп данных таблицы `tickets`
--

INSERT INTO `tickets` (`ticket_id`, `price`, `departure_date`, `arrival_date`, `departure_city`, `arrival_city`, `purchases`) VALUES
(12, 87, '2022-12-08', '2022-12-08', 'Riga', 'Tallin', 11),
(13, 66, '2023-01-01', '2023-01-01', 'Riga', 'New York', 6),
(14, 88, '2023-01-03', '2023-01-04', 'k', 'g', 0),
(15, 1, '2023-01-01', '2023-01-01', 'T', 'R', 0),
(16, 5, '2023-12-01', '2023-12-01', 't', 'y', 0),
(17, 5, '2023-12-01', '2023-12-01', '2', '', 0),
(18, 5, '2023-12-01', '2023-12-01', 'r', 'r', 0),
(19, 88, '2023-12-01', '2023-12-01', 'g', 'r', 0),
(20, 44, '2022-12-01', '2022-12-01', 't', 'y', 0),
(21, 55, '2023-12-01', '2023-12-01', 'a2', '2', 0),
(22, 5, '2023-01-01', '2023-01-01', 'Tallin', 'Riga', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` bigint(20) NOT NULL,
  `user_id` bigint(20) NOT NULL,
  `user_name` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Admin` int(1) NOT NULL DEFAULT 0,
  `Tickets` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `user_id`, `user_name`, `password`, `date`, `Admin`, `Tickets`) VALUES
(5, 226274, 'Danila', '1234', '2022-12-21 21:50:49', 0, '9 3 '),
(7, 6673977553411, 'Platon', '1234', '2022-12-20 20:38:15', 0, ''),
(8, 1365182171387136, 'Ilja', '1234', '2022-12-22 17:48:35', 1, '13 13 13 13 13 13 12 12 '),
(9, 3035786681732, 'Kristaps', '1234', '2022-12-21 21:46:47', 0, '6 5 '),
(10, 1481975, 'a', '123', '2022-12-21 21:55:39', 0, '5 5 2 '),
(11, 34112125018241, 'ab', '123', '2022-12-20 20:38:15', 0, ''),
(12, 472359987018831016, 'ggg', '1234', '2022-12-20 20:38:15', 0, '');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `tickets`
--
ALTER TABLE `tickets`
  ADD PRIMARY KEY (`ticket_id`);

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `date` (`date`),
  ADD KEY `user_name` (`user_name`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
