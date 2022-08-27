CREATE DATABASE companyDB CHARACTER SET utf8mb4;
USE companyDB;

drop table person;

CREATE TABLE person(
	id INT NOT NULL,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE address(
	id INT NOT NULL,
    street VARCHAR(50) NOT NULL,
    city VARCHAR(20) NULL,
    state VARCHAR(50) NULL,
    zip_code VARCHAR(50) NULL,
    PRIMARY KEY(id)
);

CREATE TABLE employee(
	id INT NOT NULL,
    address_id INT NOT NULL,
    person_id INT NOT NULL,
    company_name VARCHAR(20) NOT NULL,
    position VARCHAR(30) NULL,
    employee_name VARCHAR(100) NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(address_id) REFERENCES address(id),
    FOREIGN KEY(person_id) REFERENCES person(id)
);

CREATE TABLE company(
	id INT NOT NULL,
    name VARCHAR(20) NOT NULL,
    address_id INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(address_id) REFERENCES address(id)
);

SELECT * FROM address;

INSERT INTO person(id, first_name, last_name) VAlUES
	(1152, 'Homer', 'Simpson'),
	(5521, 'Moe', 'Szyslak'),
	(8008, 'Ned', 'Flanders'),
	(1236, 'Sideshow', 'Bob'),
	(8502, 'Marge', 'Simpson'),
	(1159, 'Apu', 'Nahasapeemapetilon');

INSERT INTO address(id, street, city, state, zip_code) VALUES
	(9558, 'Evergreen Terrace', 'Springfield', 'Oregon', '58008'),
	(1582, '330 Center Street', 'Springfield', 'Oregon', '58008'),
	(3544, 'Evergreen Terrace', 'Springfield', 'Oregon', '58008'),
	(5241, '4660 Buena Vista Avenue', 'Springfield', 'Oregon', '58008'),
	(5585, '1408 Counts Lane', 'Springfield', 'Oregon', '58008'),
	(3588, '4194 George Street', 'Springfield', 'Oregon', '58008');


SELECT
	employee.id AS 'Employee ID',
    CONCAT(person.first_name, ' ', person.last_name) AS 'Employee Full Name',
    CONCAT(address.zip_code, '_', address.state, ', ', address.city, '-', address.street) AS 'Employee Full Address',
    CONCAT(employee.company_name, employee.position) AS 'Employee Company Info'
FROM person
JOIN employee ON person.id = employee.person_id
JOIN address ON address.id = employee.address_id
JOIN company ON address.id = company.address_id
ORDER BY employee.company_name ASC, address.city ASC;

CREATE VIEW employee_info AS
	SELECT
	employee.id AS 'Employee ID',
    CONCAT(person.first_name, ' ', person.last_name) AS 'Employee Full Name',
    CONCAT(address.zip_code, '_', address.state, ', ', address.city, '-', address.street) AS 'Employee Full Address',
    CONCAT(employee.company_name, employee.position) AS 'Employee Company Info'
FROM person
JOIN employee ON person.id = employee.person_id
JOIN address ON address.id = employee.address_id
JOIN company ON address.id = company.address_id
ORDER BY employee.company_name ASC, address.city ASC;

SELECT * FROM employee_info;