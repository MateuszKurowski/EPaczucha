create table package (
	ID int NOT NULL,
	name VARCHAR(50),
	start_date DATE,
	type INT,
	method INT,
	city VARCHAR(50),
	street VARCHAR(50),
	building_number VARCHAR(50),
	zip_code VARCHAR(50),
	flat_number INT,
	end_date DATE,
	price DECIMAL,
	PRIMARY KEY (ID)
);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (0, 'Easy Off Oven Cleaner', '2022-08-14 02:24:43', 0, 1, 'Santa Teresita', 'Talmadge', '95', '4206', 8, '2022-08-14 00:00:00', 18);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (1, 'Worcestershire Sauce', '2022-08-29 18:19:15', 0, 1, 'Si Khoraphum', 'Helena', '7301', '67160', 51, '2022-09-02 00:00:00', 18);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (2, 'Wine - Pinot Noir Latour', '2022-07-17 14:38:31', 0, 1, 'Granada', 'Thompson', '2956', '18010', 4, '2022-02-21 00:00:00', 18);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (3, 'Cup - Translucent 7 Oz Clear', '2022-07-29 00:03:27', 2, 1, 'Piedecuesta', 'Fuller', '44', '681027', 55, '2022-08-02 00:00:00', 27);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (4, 'Wine - Lamancha Do Crianza', '2022-08-14 13:59:11', 0, 2, 'Osieczany', 'Hudson', '30268', '32-432', 94, '2022-08-16 00:00:00', 23);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (5, 'Fork - Plastic', '2022-07-30 18:10:58', 1, 1, 'Chornobay', 'Myrtle', '27', null, 2, '2022-08-03 00:00:00', 22);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (6, 'Red Cod Fillets - 225g', '2022-10-23 05:55:33', 1, 0, 'Santa Elena', 'Toban', '321', null, 44, '2022-10-30 00:00:00', 17);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (7, 'Bread - Granary Small Pull', '2022-08-26 19:39:19', 1, 1, 'Hayang', 'Bartelt', '6', null, 7, '2022-08-30 00:00:00', 22);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (8, 'Country Roll', '2022-07-07 18:05:21', 0, 2, 'Longnawang', 'Toban', '891', null, 31, '2022-07-09 00:00:00', 23);
insert into package (ID, name, start_date, type, method, city, street, building_number, zip_code, flat_number, end_date, price) values (9, 'Beans - Kidney White', '2022-10-02 13:00:42', 2, 1, 'Chaniá', 'Dexter', '481', null, 32, '2022-10-06 00:00:00', 27);
