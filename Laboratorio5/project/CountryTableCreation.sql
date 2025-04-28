USE countries

CREATE TABLE Country (
	Id int PRIMARY KEY IDENTITY,
	Name varchar(200) NOT NULL,
	Continent varchar(200) NOT NULL,
	Language nvarchar(100) NOT NULL
)