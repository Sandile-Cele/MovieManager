﻿create table Users(
	User_Id int identity(1,1) not null primary key,
	Email varchar(255) not null,
	Firstname varchar(225) not null,
	Surname varchar(225),
	password varchar(225),
	FavoriteMovie varchar(255),
	DateOfBirth date
);
