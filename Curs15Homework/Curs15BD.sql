CREATE OR ALTER PROCEDURE DeletePublisher(@PublisherID INT)
AS
	DELETE FROM Book WHERE PublisherID=@PublisherID;
	DELETE FROM Publisher WHERE PublisherID=@PublisherID;
GO

DROP TABLE Book;
DROP TABLE Publisher;

CREATE TABLE Publisher
(
	PublisherID INT IDENTITY(1,1) PRIMARY KEY,
	NameOfPublisher VARCHAR(100) NOT NULL
)

CREATE TABLE Book
(
	BookID INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(200) UNIQUE NOT NULL,
	YearOfPublish INT NOT NULL,
	Price INT,
	PublisherID INT NOT NULL,
	CONSTRAINT FK_Book_PublisherID FOREIGN KEY (PublisherID) REFERENCES Publisher
)

INSERT INTO Publisher(NameOfPublisher) VALUES('POLIROM');
INSERT INTO Publisher(NameOfPublisher) VALUES('FOR YOU');
INSERT INTO Publisher(NameOfPublisher) VALUES('LITERA');
INSERT INTO Publisher(NameOfPublisher) VALUES('NEMIRA');
INSERT INTO Publisher(NameOfPublisher) VALUES('RAO');
INSERT INTO Publisher(NameOfPublisher) VALUES('TREI');
INSERT INTO Publisher(NameOfPublisher) VALUES('ASA');
INSERT INTO Publisher(NameOfPublisher) VALUES('ART');

INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('De veghe in lanul de secara',2016,17,1);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Fluturi',2016,13,2);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Proza',2011,8,3);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Portretul lui Dorian Grey',2013,18,1);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Urzeala tronurilor',2017,30,4);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Numele vantului',2017,35,5);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Cartea vietii',2017,24,3);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Chimista',2016,33,6);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Baltagul',2014,22,7);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Harry Potter vol. 5',2017,64,8);
INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) VALUES ('Puterea armelor',2017,35,3);

/*select * from Publisher;
select * from Book;*/

--EXEC DeletePublisher @PublisherID=2;