--QUESTION 1.	firstName, lastName and departmentName of all employees. (department name column must be displayed as “departmentName

SELECT firstName , lastName , DEP.name 'departmentName'
FROM employees EMP 
INNER JOIN departments DEP 
ON EMP.departmentId = DEP.id

--QUESTION 2.	all departments name,number of employees in each department, average salary in that department and order by average salary

-- the reason i used with was because i wanted to calculate the avarages and total and place them in a temp table first
-- then join the department table to the temp table
-- i used a left join because i did not want to leave out departments without employees

WITH 
	#TEMP (totalSalary, numberOfEmp , departmentId) 
	 as (SELECT  SUM(salary), COUNT(*) ,  departmentId 
	 FROM employees GROUP BY departmentId)

SELECT DEP.name 'DEPARTMENT', 
IIF(#TEMP.numberOfEmp IS NULL,0,#TEMP.numberOfEmp)
 'No. EMPLOYEES'  , IIF((#TEMP.totalSalary / #TEMP.numberOfEmp) IS NULL,0,
					(#TEMP.totalSalary / #TEMP.numberOfEmp)) AVG_SALARY
FROM departments DEP LEFT JOIN #TEMP
ON #TEMP.departmentId = DEP.id
ORDER BY AVG_SALARY

-- QUESTION 3.	firstName, lastName, departmentName, salary, salary + 10% increase order by salary increase.

SELECT firstName , lastName , DEP.name 'departmentName' , salary , salary + (salary * 0.01) increase
FROM employees EMP 
INNER JOIN departments DEP 
ON EMP.departmentId = DEP.id
ORDER BY increase

-- QUESTION 4.	departmentName, highest salary in that department

WITH 
	#TEMP (totalSalary, departmentId) 
	 as (SELECT  SUM(salary), departmentId 
	 FROM employees GROUP BY departmentId)

SELECT TOP 1 MAX(totalSalary) , DEP.name
FROM departments DEP INNER JOIN #TEMP
ON #TEMP.departmentId = DEP.id
GROUP BY  DEP.name
ORDER BY MAX(totalSalary) DESC

-- QUESTION 5.	A millennial is anyone born between 1981 – 1996. Considering this display, the following   firstName, lastName, isMillennial (yes or no) 


SELECT firstName , lastName , 
IIF(dateOfBirth between DATEFROMPARTS(1981,1,1) and DATEFROMPARTS(1996,1,1),'Yes', 'No') isMillennial
FROM employees  

