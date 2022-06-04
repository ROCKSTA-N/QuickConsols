
CREATE TABLE departments (id INT IDENTITY(1,1),[name] VARCHAR(100));
CREATE TABLE employees (id INT IDENTITY(1,1),firstName VARCHAR(100),lastName VARCHAR(100),dateOfBirth DATE,departmentId INT,salary DECIMAL(18,2));


INSERT INTO departments ([name]) VALUES ('finance');
INSERT INTO departments ([name]) VALUES ('marketing');
INSERT INTO departments ([name]) VALUES ('executive');
INSERT INTO departments ([name]) VALUES ('it');
INSERT INTO departments ([name]) VALUES ('hr');
INSERT INTO departments ([name]) VALUES ('operations');


INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('sam','james','1980/07/25','3','68000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('tammy','smith','1985/03/15','1','32500');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('gary','barnes','1990/03/01','1','28900');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('mary','fray','1975/06/17','4','49000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('david','boyes','1995/04/29','4','32000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('nate','voster','1991/12/16','2','26000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('peter','prinsloo','1991/08/20','2','25000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('kate','roader','1988/09/21','2','34000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('stacy','grey','1996/05/08','2','19000');
INSERT INTO employees (firstname,lastname,dateofbirth,departmentId,salary) VALUES ('johan','hill','1989/11/25','3','65000');

