-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 11, 2026 at 03:29 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `khaokaijeow_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `name`) VALUES
(3, 'กลุ่มซอสน้ำแกง'),
(6, 'กลุ่มทะเล'),
(7, 'กลุ่มผลไม้'),
(2, 'กลุ่มผัก'),
(5, 'กลุ่มอาหารสำเร็จ'),
(1, 'กลุ่มเนื้อไข่'),
(4, 'อื่นๆ');

-- --------------------------------------------------------

--
-- Table structure for table `customitems`
--

CREATE TABLE `customitems` (
  `item_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock` int(11) NOT NULL,
  `image_path` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customitems`
--

INSERT INTO `customitems` (`item_id`, `category_id`, `name`, `price`, `stock`, `image_path`) VALUES
(1, 1, 'หมูสับ', 10.00, 14, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\90997dfc-1c1c-479f-84fa-6c15fde569e4_หมูสับ.png'),
(2, 2, 'ผักกาด', 5.00, 26, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\c6a6c79d-bb11-4e10-b2f5-efd236a26ba8_ผักกาด.png'),
(3, 2, 'แครอท', 7.00, 30, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\46df47d9-3a3d-4d91-8202-2f27a999fc3c_แครอท.png'),
(4, 2, 'กระเทียม', 4.00, 65, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\96eb2b90-8d3b-456d-a510-89c13db47400_กระเทียม.png'),
(5, 6, 'กุ้ง', 10.00, 52, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\542fb894-4300-416f-8d22-140c086cea4d_กุ้ง.png'),
(6, 2, 'ข้าวโพด', 6.00, 29, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\8affb6e2-a4b4-4e5d-a134-3633a7903463_ข้าวโพด.png'),
(7, 2, 'ขิง', 4.00, 55, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\87203768-e434-42d5-8f08-7d0c9690f743_ขิง.png'),
(8, 5, 'ชีส', 8.00, 59, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\294b3aa4-1821-4f94-b5da-3ab469139752_ชีส.png'),
(9, 6, 'แซลมอน', 12.00, 86, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\f33d31c6-d29e-4952-acf7-3e91ef25eb0f_แซลมอน.png'),
(10, 2, 'ต้นหอม', 3.00, 72, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\9a73c1d1-77da-4be5-97de-9c3b2ce72b6f_ต้นหอม.png'),
(11, 2, 'ถั่วเขียว', 3.00, 197, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\2a152ce5-52dd-481b-a5c7-e95b12e3c873_ถั่วเขียว.png'),
(12, 1, 'เนื้อวัว', 12.00, 89, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\3eafd992-6401-4d93-bd61-e2b7e0ece903_เนื้อวัว.png'),
(13, 1, 'เนื้อหมูชิ้น', 10.00, 83, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\0d0e0d44-b5a1-403e-82a3-b6a0781281a5_เนื้อหมู.png'),
(14, 1, 'เนื้อปลา', 9.00, 56, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\ffaab8d1-b8e2-472b-85ac-a7ef737cdffb_ปลา.png'),
(15, 5, 'เนื้อซาดีนกระป๋อง', 8.00, 86, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\88099d0b-edaa-4ebf-9403-cfdfe514f642_ปลาซาดีน.png'),
(16, 5, 'ปูอัด', 5.00, 68, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\f70c932b-6ee0-4678-b5e5-6f1d0a012976_ปูอัด.png'),
(17, 2, 'พริก', 2.00, 44, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\f6dccb6e-2f3f-4089-b315-aef9e29d2a79_พริก.png'),
(18, 7, 'มะเทศ', 5.00, 24, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\8c2cb383-0779-4a0e-9508-93010d8ad006_มะเขือเทศ.png'),
(19, 1, 'ปลาหมึก', 9.00, 67, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\f241b44a-8a09-449f-8dd6-6903184b23b2_หมึก.png'),
(20, 6, 'สาหร่าย', 5.00, 60, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\f4a8b85a-de85-40e9-a378-ce54b07ea024_สาหร่าย.png'),
(21, 7, 'มันฝรั่ง', 10.00, 100, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\b2ab7e9a-c9b5-4cb5-8480-991f70355e85_มัน.png');

-- --------------------------------------------------------

--
-- Table structure for table `menu`
--

CREATE TABLE `menu` (
  `menu_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `stock` int(11) NOT NULL,
  `image_path` varchar(255) NOT NULL,
  `is_hot` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `menu`
--

INSERT INTO `menu` (`menu_id`, `name`, `price`, `stock`, `image_path`, `is_hot`) VALUES
(1, 'ข้าวไข่เจียว', 40.00, 83, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\1_ข้าวไข่เจียว.png', 0),
(2, 'ข้าวไข่เจียวรวมมิตร', 35.00, 27, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\2_ข้าวไข่เจียวรวมมิตร.png', 0),
(3, 'ข้าวไข่เจียวชีส', 40.00, 41, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\33382618-c6f2-43ad-a4ce-a61bff79fbe7_ข้าวไข่เจียวชีส.png', 0),
(4, 'ข้าวไข่เจียวบลูเบอรี่', 50.00, 15, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\1d1ae24a-ac9d-4bd9-8eba-0c6bb9bd346f_ข้าวไข่เจียวบลูเบอรี่.png', 0),
(5, 'ข้าวไข่เจียวเบค่อน', 50.00, 38, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\7c217e49-a107-406a-9300-df1f5947e878_ข้าวไขเจียวเบค่อน.png', 0),
(6, 'ข้าวไข่เจียวหอย', 50.00, 94, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\a91836e7-a74f-4438-bb86-86f6aec2e311_ข้าวไข่เจียวหอย.png', 0),
(7, 'ข้าวไข่เจียวขจรใส่แหนม', 55.00, 97, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\aa1adc7b-38b8-42e4-be22-b468936f2d62_ไข่เจียวขจรใส่แหนม-1.png', 0),
(9, 'ข้าวยำไข่เจียว', 50.00, 95, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\cc78fba1-5f6b-4699-96e1-f7c7c9f65ccd_ยำไข่เจียว.png', 0),
(10, 'ข้าวไข่เจียวห่อไก่', 50.00, 29, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\8197708a-0446-4951-8b0e-3a403b32256f_ไข่เจียวห่อไก่.png', 0),
(11, 'ข้าวไข่เจียวหอมแดง', 45.00, 50, 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\Resources\\524b4e3d-ca94-445b-9899-8b3417d5bdb5_ไข่เจียวหอมแดง.png', 0);

-- --------------------------------------------------------

--
-- Table structure for table `orderdetails`
--

CREATE TABLE `orderdetails` (
  `detail_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `product_name` varchar(255) NOT NULL,
  `item_type` varchar(20) NOT NULL,
  `custom_details` varchar(255) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `price_at_sale` decimal(10,2) NOT NULL,
  `net_price_at_sale` decimal(10,2) NOT NULL DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orderdetails`
--

INSERT INTO `orderdetails` (`detail_id`, `order_id`, `product_id`, `product_name`, `item_type`, `custom_details`, `quantity`, `price_at_sale`, `net_price_at_sale`) VALUES
(1, 5, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: หมูสับ x2', 2, 60.00, 0.00),
(2, 5, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 2, 35.00, 0.00),
(3, 6, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 3, 40.00, 0.00),
(4, 6, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 2, 35.00, 0.00),
(5, 7, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: หมูสับ x4', 2, 80.00, 0.00),
(6, 7, 1, 'ข้าวไข่เจียว', 'Menu', '', 3, 35.00, 0.00),
(7, 8, 9999, 'ข้าวไข่เจียวพื้นฐาน', 'CustomNew', 'เสริม: หมูสับ x2, ผักกาด x2', 2, 55.00, 0.00),
(8, 8, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 0.00),
(9, 9, 5, 'ข้าวไข่เจียวเบค่อน', 'Menu', '', 3, 50.00, 0.00),
(10, 9, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 2, 50.00, 0.00),
(11, 9, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: ผักกาด x1, หมูสับ x2', 1, 65.00, 0.00),
(12, 10, 5, 'ข้าวไข่เจียวเบค่อน', 'Menu', '', 1, 50.00, 46.73),
(13, 10, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(14, 10, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 1, 35.00, 32.71),
(15, 11, 5, 'ข้าวไข่เจียวเบค่อน', 'Menu', '', 1, 50.00, 46.73),
(16, 11, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(17, 11, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(18, 11, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(19, 11, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'CustomizedMenu', 'เสริม: ผักกาด x3, หมูสับ x3, แครอท x4', 1, 123.00, 114.95),
(20, 12, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(21, 12, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: หมูสับ x1, ผักกาด x1, แครอท x1', 1, 62.00, 57.94),
(22, 13, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(23, 13, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(24, 13, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 1, 35.00, 32.71),
(25, 13, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'CustomizedMenu', 'เสริม: แครอท x2, ผักกาด x3, หมูสับ x1', 1, 89.00, 83.18),
(26, 14, 5, 'ข้าวไข่เจียวเบค่อน', 'Menu', '', 1, 50.00, 46.73),
(27, 14, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(28, 14, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 1, 35.00, 32.71),
(29, 14, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: แครอท x1, ผักกาด x1, หมูสับ x3', 1, 82.00, 76.64),
(30, 15, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(31, 15, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(32, 15, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: แครอท x2, ผักกาด x3, หมูสับ x4', 1, 109.00, 101.87),
(33, 20, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(34, 20, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(35, 20, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: แครอท x1, ผักกาด x1, หมูสับ x1', 1, 62.00, 57.94),
(36, 21, 1, 'ข้าวไข่เจียว', 'CustomizedMenu', 'เสริม: หมูสับ x1, แซลมอน x1, เนื้อวัว x1, เนื้อหมูชิ้น x1, ปูอัด x1, เนื้อซาดีนกระป๋อง x1, ผักกาด x1, แครอท x1, กระเทียม x3', 1, 121.00, 113.08),
(37, 21, 8, 'ข้าวไข่เจียวใบกุยช่าย', 'CustomizedMenu', 'เสริม: ชีส x1, เนื้อวัว x3, เนื้อซาดีนกระป๋อง x5, แครอท x4, กระเทียม x3, ปูอัด x2, ผักกาด x4', 1, 209.00, 195.33),
(38, 21, 8, 'ข้าวไข่เจียวใบกุยช่าย', 'Menu', '', 1, 55.00, 51.40),
(39, 21, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(40, 21, 6, 'ข้าวไข่เจียวหอย', 'Menu', '', 1, 50.00, 46.73),
(41, 21, 8, 'ข้าวไข่เจียวใบกุยช่าย', 'CustomizedMenu', 'เสริม: กุ้ง x7, เนื้อวัว x7, ปูอัด x7, ผักกาด x5', 1, 269.00, 251.40),
(42, 21, 5, 'ข้าวไข่เจียวเบค่อน', 'CustomizedMenu', 'เสริม: กระเทียม x5, หมูสับ x4, แซลมอน x6, เนื้อปลา x3', 1, 209.00, 195.33),
(43, 21, 5, 'ข้าวไข่เจียวเบค่อน', 'Menu', '', 1, 50.00, 46.73),
(44, 22, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 1, 35.00, 32.71),
(45, 23, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(46, 23, 1, 'ข้าวไข่เจียว', 'CustomizedMenu', 'เสริม: กุ้ง x1, แครอท x1, ผักกาด x1', 1, 62.00, 57.94),
(47, 23, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: ข้าวโพด x1, ผักกาด x1, แครอท x1, แซลมอน x1', 1, 70.00, 65.42),
(48, 23, 1, 'ข้าวไข่เจียว', 'CustomizedMenu', 'เสริม: เนื้อหมูชิ้น x1, ชีส x1', 1, 58.00, 54.21),
(49, 24, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(50, 24, 9, 'ข้าวยำไข่เจียว', 'Menu', '', 1, 50.00, 46.73),
(51, 25, 5, 'ข้าวไข่เจียวเบค่อน', 'Menu', '', 3, 50.00, 46.73),
(52, 26, 9, 'ข้าวยำไข่เจียว', 'Menu', '', 1, 50.00, 46.73),
(53, 26, 9, 'ข้าวยำไข่เจียว', 'CustomizedMenu', 'เสริม: กระเทียม x30', 1, 170.00, 158.88),
(54, 26, 4, 'กระเทียม', 'Ingredient', '', 30, 4.00, 3.74),
(55, 27, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 2, 40.00, 37.38),
(56, 27, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(57, 27, 3, 'ข้าวไข่เจียวชีส', 'CustomizedMenu', 'เสริม: กุ้ง x1, ชีส x1, เนื้อหมูชิ้น x3, ปลาหมึก x2, พริก x2, มะเทศ x1, ต้นหอม x1', 1, 118.00, 110.28),
(58, 27, 5, 'กุ้ง', 'Ingredient', '', 1, 10.00, 9.35),
(59, 27, 8, 'ชีส', 'Ingredient', '', 1, 8.00, 7.48),
(60, 27, 13, 'เนื้อหมูชิ้น', 'Ingredient', '', 3, 10.00, 9.35),
(61, 27, 19, 'ปลาหมึก', 'Ingredient', '', 2, 9.00, 8.41),
(62, 27, 17, 'พริก', 'Ingredient', '', 2, 2.00, 1.87),
(63, 27, 18, 'มะเทศ', 'Ingredient', '', 1, 5.00, 4.67),
(64, 27, 10, 'ต้นหอม', 'Ingredient', '', 1, 3.00, 2.80),
(65, 27, 2, 'ข้าวไข่เจียวรวมมิตร', 'Menu', '', 1, 35.00, 32.71),
(66, 27, 2, 'ข้าวไข่เจียวรวมมิตร', 'CustomizedMenu', 'เสริม: ปูอัด x4, เนื้อวัว x1, แซลมอน x3, เนื้อปลา x2, เนื้อซาดีนกระป๋อง x4', 1, 153.00, 142.99),
(67, 27, 16, 'ปูอัด', 'Ingredient', '', 4, 5.00, 4.67),
(68, 27, 12, 'เนื้อวัว', 'Ingredient', '', 1, 12.00, 11.21),
(69, 27, 9, 'แซลมอน', 'Ingredient', '', 3, 12.00, 11.21),
(70, 27, 14, 'เนื้อปลา', 'Ingredient', '', 2, 9.00, 8.41),
(71, 27, 15, 'เนื้อซาดีนกระป๋อง', 'Ingredient', '', 4, 8.00, 7.48),
(72, 27, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(73, 27, 7, 'ข้าวไข่เจียวขจรใส่แหนม', 'CustomizedMenu', 'เสริม: ปูอัด x1, มะเทศ x2, พริก x9, ข้าวโพด x2, กระเทียม x1, ต้นหอม x1, ถั่วเขียว x1, ขิง x3', 1, 122.00, 114.02),
(74, 27, 16, 'ปูอัด', 'Ingredient', '', 1, 5.00, 4.67),
(75, 27, 18, 'มะเทศ', 'Ingredient', '', 2, 5.00, 4.67),
(76, 27, 17, 'พริก', 'Ingredient', '', 9, 2.00, 1.87),
(77, 27, 6, 'ข้าวโพด', 'Ingredient', '', 2, 6.00, 5.61),
(78, 27, 4, 'กระเทียม', 'Ingredient', '', 1, 4.00, 3.74),
(79, 27, 10, 'ต้นหอม', 'Ingredient', '', 1, 3.00, 2.80),
(80, 27, 11, 'ถั่วเขียว', 'Ingredient', '', 1, 3.00, 2.80),
(81, 27, 7, 'ขิง', 'Ingredient', '', 3, 4.00, 3.74),
(82, 28, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(83, 28, 1, 'ข้าวไข่เจียว', 'CustomizedMenu', 'เสริม: กุ้ง x1, หมูสับ x1, ข้าวโพด x2, แครอท x2, เนื้อซาดีนกระป๋อง x2', 1, 102.00, 95.33),
(84, 28, 5, 'กุ้ง', 'Ingredient', '', 1, 10.00, 9.35),
(85, 28, 1, 'หมูสับ', 'Ingredient', '', 1, 10.00, 9.35),
(86, 28, 6, 'ข้าวโพด', 'Ingredient', '', 2, 6.00, 5.61),
(87, 28, 3, 'แครอท', 'Ingredient', '', 2, 7.00, 6.54),
(88, 28, 15, 'เนื้อซาดีนกระป๋อง', 'Ingredient', '', 2, 8.00, 7.48),
(89, 28, 6, 'ข้าวไข่เจียวหอย', 'Menu', '', 1, 50.00, 46.73),
(90, 28, 9, 'ข้าวยำไข่เจียว', 'Menu', '', 1, 50.00, 46.73),
(91, 28, 7, 'ข้าวไข่เจียวขจรใส่แหนม', 'Menu', '', 1, 55.00, 51.40),
(92, 28, 7, 'ข้าวไข่เจียวขจรใส่แหนม', 'CustomizedMenu', 'เสริม: ผักกาด x2, เนื้อซาดีนกระป๋อง x2', 1, 81.00, 75.70),
(93, 28, 2, 'ผักกาด', 'Ingredient', '', 2, 5.00, 4.67),
(94, 28, 15, 'เนื้อซาดีนกระป๋อง', 'Ingredient', '', 2, 8.00, 7.48),
(95, 29, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(96, 29, 6, 'ข้าวไข่เจียวหอย', 'Menu', '', 1, 50.00, 46.73),
(97, 29, 6, 'ข้าวไข่เจียวหอย', 'CustomizedMenu', 'เสริม: หมูสับ x3, แซลมอน x3, เนื้อปลา x3, ผักกาด x2, กระเทียม x2, ข้าวโพด x2', 1, 173.00, 161.68),
(98, 29, 1, 'หมูสับ', 'Ingredient', '', 3, 10.00, 9.35),
(99, 29, 9, 'แซลมอน', 'Ingredient', '', 3, 12.00, 11.21),
(100, 29, 14, 'เนื้อปลา', 'Ingredient', '', 3, 9.00, 8.41),
(101, 29, 2, 'ผักกาด', 'Ingredient', '', 2, 5.00, 4.67),
(102, 29, 4, 'กระเทียม', 'Ingredient', '', 2, 4.00, 3.74),
(103, 29, 6, 'ข้าวโพด', 'Ingredient', '', 2, 6.00, 5.61),
(104, 29, 9, 'ข้าวยำไข่เจียว', 'CustomizedMenu', 'เสริม: แครอท x3, เนื้อปลา x2, ปลาหมึก x2, ขิง x2, เนื้อซาดีนกระป๋อง x2, พริก x3', 1, 137.00, 128.04),
(105, 29, 3, 'แครอท', 'Ingredient', '', 3, 7.00, 6.54),
(106, 29, 14, 'เนื้อปลา', 'Ingredient', '', 2, 9.00, 8.41),
(107, 29, 19, 'ปลาหมึก', 'Ingredient', '', 2, 9.00, 8.41),
(108, 29, 7, 'ขิง', 'Ingredient', '', 2, 4.00, 3.74),
(109, 29, 15, 'เนื้อซาดีนกระป๋อง', 'Ingredient', '', 2, 8.00, 7.48),
(110, 29, 17, 'พริก', 'Ingredient', '', 3, 2.00, 1.87),
(111, 29, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'CustomizedMenu', 'เสริม: แซลมอน x2, เนื้อซาดีนกระป๋อง x2, มะเทศ x3, พริก x5', 1, 115.00, 107.48),
(112, 29, 9, 'แซลมอน', 'Ingredient', '', 2, 12.00, 11.21),
(113, 29, 15, 'เนื้อซาดีนกระป๋อง', 'Ingredient', '', 2, 8.00, 7.48),
(114, 29, 18, 'มะเทศ', 'Ingredient', '', 3, 5.00, 4.67),
(115, 29, 17, 'พริก', 'Ingredient', '', 5, 2.00, 1.87),
(116, 29, 5, 'ข้าวไข่เจียวเบค่อน', 'CustomizedMenu', 'เสริม: ต้นหอม x3, ข้าวโพด x2, กระเทียม x2, ถั่วเขียว x2', 1, 85.00, 79.44),
(117, 29, 10, 'ต้นหอม', 'Ingredient', '', 3, 3.00, 2.80),
(118, 29, 6, 'ข้าวโพด', 'Ingredient', '', 2, 6.00, 5.61),
(119, 29, 4, 'กระเทียม', 'Ingredient', '', 2, 4.00, 3.74),
(120, 29, 11, 'ถั่วเขียว', 'Ingredient', '', 2, 3.00, 2.80),
(121, 30, 1, 'ข้าวไข่เจียว', 'Menu', '', 1, 40.00, 37.38),
(122, 30, 3, 'ข้าวไข่เจียวชีส', 'Menu', '', 1, 40.00, 37.38),
(123, 30, 4, 'ข้าวไข่เจียวบลูเบอรี่', 'Menu', '', 1, 50.00, 46.73),
(124, 30, 5, 'ข้าวไข่เจียวเบค่อน', 'CustomizedMenu', 'เสริม: เนื้อหมูชิ้น x4, ปลาหมึก x3, เนื้อปลา x3, พริก x7', 1, 158.00, 147.66),
(125, 30, 13, 'เนื้อหมูชิ้น', 'Ingredient', '', 4, 10.00, 9.35),
(126, 30, 19, 'ปลาหมึก', 'Ingredient', '', 3, 9.00, 8.41),
(127, 30, 14, 'เนื้อปลา', 'Ingredient', '', 3, 9.00, 8.41),
(128, 30, 17, 'พริก', 'Ingredient', '', 7, 2.00, 1.87),
(129, 30, 10, 'ข้าวไข่เจียวห่อไก่', 'CustomizedMenu', 'เสริม: หมูสับ x3, ปลาหมึก x4, ข้าวโพด x3, ต้นหอม x3', 1, 143.00, 133.64),
(130, 30, 1, 'หมูสับ', 'Ingredient', '', 3, 10.00, 9.35),
(131, 30, 19, 'ปลาหมึก', 'Ingredient', '', 4, 9.00, 8.41),
(132, 30, 6, 'ข้าวโพด', 'Ingredient', '', 3, 6.00, 5.61),
(133, 30, 10, 'ต้นหอม', 'Ingredient', '', 3, 3.00, 2.80),
(134, 30, 6, 'ข้าวไข่เจียวหอย', 'Menu', '', 1, 50.00, 46.73),
(135, 30, 6, 'ข้าวไข่เจียวหอย', 'CustomizedMenu', 'เสริม: ปูอัด x3, กุ้ง x6, แซลมอน x6, ปลาหมึก x2, เนื้อปลา x3', 1, 242.00, 226.17),
(136, 30, 16, 'ปูอัด', 'Ingredient', '', 3, 5.00, 4.67),
(137, 30, 5, 'กุ้ง', 'Ingredient', '', 6, 10.00, 9.35),
(138, 30, 9, 'แซลมอน', 'Ingredient', '', 6, 12.00, 11.21),
(139, 30, 19, 'ปลาหมึก', 'Ingredient', '', 2, 9.00, 8.41),
(140, 30, 14, 'เนื้อปลา', 'Ingredient', '', 3, 9.00, 8.41);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `order_time` datetime NOT NULL,
  `order_type` varchar(20) NOT NULL,
  `total_price` decimal(10,2) NOT NULL,
  `status` varchar(50) NOT NULL DEFAULT 'Pending',
  `payment_slip` varchar(255) DEFAULT NULL,
  `notes` varchar(500) DEFAULT NULL,
  `total_vat` decimal(10,2) NOT NULL DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_id`, `user_id`, `order_time`, `order_type`, `total_price`, `status`, `payment_slip`, `notes`, `total_vat`) VALUES
(5, 1, '2025-11-04 15:48:16', '', 190.00, 'Completed', 'Slip_Order_25681104154816.jpg', NULL, 0.00),
(6, 1, '2025-11-04 16:29:17', '', 190.00, 'Completed', 'Slip_Order_25681104162916.jpg', NULL, 0.00),
(7, 1, '2025-11-04 16:39:10', '', 265.00, 'Completed', 'Slip_Order_25681104163910.jpg', NULL, 0.00),
(8, 1, '2025-11-04 18:15:40', '', 150.00, 'Completed', 'Slip_Order_25681104181539.jpg', NULL, 0.00),
(9, 1, '2025-11-22 19:52:36', '', 315.00, 'Completed', 'Slip_Order_25681122195235.jpg', NULL, 0.00),
(10, 1, '2025-11-22 20:30:28', '', 125.00, 'Completed', 'Slip_Order_25681122203028.jpg', NULL, 8.18),
(11, 1, '2025-11-22 22:10:53', '', 303.00, 'Completed', 'Slip_Order_25681122221053.jpg', NULL, 19.83),
(12, 1, '2025-11-22 22:16:15', '', 102.00, 'Completed', 'Slip_Order_25681122221615.jpg', NULL, 6.68),
(13, 4, '2025-11-22 22:28:12', '', 214.00, 'Completed', 'Slip_Order_25681122222812.jpg', NULL, 14.00),
(14, 4, '2025-11-22 22:38:25', '', 207.00, 'Completed', 'Slip_Order_25681122223824.jpg', NULL, 13.54),
(15, 2, '2025-11-22 23:04:56', '', 199.00, 'Completed', 'Slip_Order_25681122230456.jpg', NULL, 13.02),
(20, 4, '2025-11-23 00:00:21', '', 152.00, 'Completed', 'Slip_Order_25681123000021.jpg', NULL, 9.95),
(21, 5, '2025-11-23 00:38:23', '', 1003.00, 'Completed', 'Slip_Order_25681123003823.jpg', NULL, 65.62),
(22, 2, '2026-01-11 02:00:11', '', 35.00, 'Completed', 'Slip_Order_25690111020010.jpg', NULL, 2.29),
(23, 2, '2026-01-11 02:15:29', '', 240.00, 'Completed', 'Slip_Order_25690111021529.jpg', NULL, 15.70),
(24, 2, '2026-01-11 02:28:32', '', 90.00, 'Completed', 'Slip_Order_25690111022832.jpg', NULL, 5.89),
(25, 2, '2026-01-11 16:29:21', '', 150.00, 'Completed', 'Slip_Order_25690111162920.jpg', NULL, 9.81),
(26, 2, '2026-01-11 17:13:37', '', 220.00, 'Completed', 'Slip_Order_25690111171337.jpg', NULL, 14.39),
(27, 6, '2026-01-11 17:30:28', '', 598.00, 'Completed', 'Slip_Order_25690111173028.jpg', NULL, 39.13),
(28, 7, '2026-01-11 18:22:16', '', 378.00, 'Completed', 'Slip_Order_25690111182216.jpg', NULL, 24.73),
(29, 9, '2026-01-11 19:23:07', '', 600.00, 'Completed', 'Slip_Order_25690111192307.jpg', NULL, 39.25),
(30, 10, '2026-01-11 19:37:04', '', 723.00, 'Completed', 'Slip_Order_25690111193704.jpg', NULL, 47.31);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(20) NOT NULL DEFAULT 'Customer',
  `date_joined` datetime NOT NULL,
  `last_login` datetime DEFAULT NULL,
  `profile_image` varchar(255) DEFAULT NULL,
  `phone_number` varchar(20) DEFAULT NULL,
  `address` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `first_name`, `last_name`, `email`, `password`, `role`, `date_joined`, `last_login`, `profile_image`, `phone_number`, `address`) VALUES
(1, 'Thana', 'Thanasin', 'Ongart', 'thanasin.on@gmail.com', '36305000', 'Admin', '2568-11-02 12:46:39', '2568-11-02 12:46:39', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_1_639037440311373452.jpg', NULL, NULL),
(2, 'Nj', 'nj', 'koko', 'nj@gmail.com', 'nj36305000', 'Customer', '2568-11-02 12:58:07', '2568-11-02 12:58:07', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_2_639037460348935883.jpg', '0918643961', '123/10 ต.เมือง อ.เมือง จ.ของเเก่น'),
(3, 'NJney', 'Thanasin', 'Ongart', 'Thanasin@gmail.com', 'nj123456', 'Admin', '2568-11-04 18:10:00', '2568-11-04 18:10:00', NULL, NULL, NULL),
(4, 'Mo', 'MoMo', 'Mame', 'Momo@gmail.com', 'mo123456', 'Customer', '2568-11-22 22:09:45', '2568-11-22 22:09:45', NULL, NULL, NULL),
(5, 'loop', 'loop', 'op', 'loop@gmail.com', 'loop1234', 'Customer', '2568-11-23 00:34:48', '2568-11-23 00:34:48', NULL, NULL, NULL),
(6, 'jo', 'jojo', 'mimi', 'jojo@gmail.com', 'jo123456', 'Customer', '2569-01-11 17:24:18', '2569-01-11 17:24:18', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_6_639037491582832707.jpg', '0121234567', '123/13 ถ.มิตรภาพ อ.ในเมือง จ.ขอนแก่น'),
(7, 'banana', 'Banana', 'mala', 'banana@gmail.com', 'ba123456', 'Customer', '2569-01-11 18:18:54', '2569-01-11 18:18:54', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_7_639037524170465223.jpg', '0918643961', '123/1 ถ.มิตรภาพ อ.ในเมือง จ.ขอนแก่น 40000'),
(8, 'nano', 'nano', 'mono', 'nano@gmail.com', 'na123456', 'Customer', '2569-01-11 19:14:45', '2569-01-11 19:14:45', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_8_639037557891152956.jpeg', '0231234567', '123/1 อ.ในเมือง จ.ขอนแก่น 40000'),
(9, 'kono', 'kono', 'mona', 'kono@gmail.com', 'ko123456', 'Customer', '2569-01-11 19:20:42', '2569-01-11 19:20:42', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_9_639037561022261854.jpeg', '0918643961', '123/1 อ.ในเมือง จ.ขอนแก่น 40000'),
(10, 'joon', 'joon', 'lee', 'joon@gmail.com', 'joon1234', 'Customer', '2569-01-11 19:34:23', '2569-01-11 19:34:23', 'D:\\Project C#\\Project_C#\\khaoKaijeow shop\\khaoKaijeow shop\\bin\\Debug\\UserImages\\User_10_639037573380083217.jpg', '0918643961', '123/1 ถ.มิตรภาพ อ.ในเเมือง จ.ขอนแก่น 40000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `customitems`
--
ALTER TABLE `customitems`
  ADD PRIMARY KEY (`item_id`),
  ADD UNIQUE KEY `name` (`name`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `menu`
--
ALTER TABLE `menu`
  ADD PRIMARY KEY (`menu_id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD PRIMARY KEY (`detail_id`),
  ADD KEY `order_id` (`order_id`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `customitems`
--
ALTER TABLE `customitems`
  MODIFY `item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `menu`
--
ALTER TABLE `menu`
  MODIFY `menu_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `orderdetails`
--
ALTER TABLE `orderdetails`
  MODIFY `detail_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=141;

--
-- AUTO_INCREMENT for table `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customitems`
--
ALTER TABLE `customitems`
  ADD CONSTRAINT `customitems_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`);

--
-- Constraints for table `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD CONSTRAINT `orderdetails_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
