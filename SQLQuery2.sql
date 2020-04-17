CREATE PROCEDURE GetDepartment2
	AS
begin
	SELECT tblEmployee.ID,tblEmployee.Name,tblEmployee.Email,tblEmployee.Gender,tblDepartment.DepartmentName,tblDesignation.DesignationName,tblEmployee.DOB,tblEmployee.Salary from tblDepartment,tblDesignation,tblEmployee where tblDepartment.DepartmentID=tblEmployee.Department and tblDesignation.DesignationID=tblEmployee.Designation;
End