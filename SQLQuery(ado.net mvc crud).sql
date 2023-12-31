Create Database ado_db

Use ado_db

Create Table employee_tbl
(
id Int Identity(1,1) Primary Key,
name Varchar(50),
gender Varchar(50),
age Varchar(50),
salary Int,
city Varchar(50)
)

INSERT INTO employee_tbl (name, gender, age, salary, city)
VALUES
    ('Alice Johnson', 'Female', '28', 60000, 'Los Angeles'),
    ('Bob Smith', 'Male', '35', 75000, 'Chicago'),
    ('Charlie Brown', 'Male', '40', 80000, 'San Francisco'),
    ('David Wilson', 'Male', '32', 70000, 'Houston'),
    ('Emily Davis', 'Female', '29', 65000, 'Miami'),
    ('Frank Miller', 'Male', '45', 90000, 'Seattle'),
    ('Grace White', 'Female', '27', 55000, 'Denver'),
    ('Henry Taylor', 'Male', '38', 85000, 'Boston'),
    ('Ivy Moore', 'Female', '31', 68000, 'Austin'),
    ('Jack Lee', 'Male', '33', 72000, 'Dallas');

  SELECT TOP (1000) [id]
      ,[name]
      ,[gender]
      ,[age]
      ,[salary]
      ,[city]
  FROM [ado_db].[dbo].[employee_tbl]

  Select * From employee_tbl

CREATE PROCEDURE spGetEmployes
AS
BEGIN
  Select * From employee_tbl
END

EXECUTE spGetEmployes;


-- Create Stored Procedure for Inserting Data
CREATE PROCEDURE spAddEmployes
    @name VARCHAR(50),
    @gender VARCHAR(50),
    @age VARCHAR(50),
    @salary INT,
    @city VARCHAR(50)
AS
BEGIN
    INSERT INTO employee_tbl (name, gender, age, salary, city)
    VALUES (@name, @gender, @age, @salary, @city);
END;

-- Example of Inserting Data using Stored Procedure
EXEC spAddEmployes 'John Doe', 'Male', '30', 50000, 'New York';



-- Create Stored Procedure for Updating Data
CREATE PROCEDURE spUpdateEmployes
    @id INT,
    @name VARCHAR(50),
    @gender VARCHAR(50),
    @age VARCHAR(50),
    @salary INT,
    @city VARCHAR(50)
AS
BEGIN
    UPDATE employee_tbl
    SET
        name = @name,
        gender = @gender,
        age = @age,
        salary = @salary,
        city = @city
    WHERE
        id = @id;
END;


EXEC spUpdateEmployes 3, 'John Doe', 'Male', '30', 60000, 'New York';


-- Create Stored Procedure for deleting Data
CREATE PROCEDURE spDeleteEmployes
    @id INT
AS
BEGIN
    DELETE FROM employee_tbl WHERE id = @id;
END;

EXEC spDeleteEmployes 15
