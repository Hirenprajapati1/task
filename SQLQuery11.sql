CREATE procedure Getemployee2
as
begin

select DepartmentID,DepartmentName,DesignationID,DesignationName,ID,Name,Gender,Email,DOB,EmployeeCode,Salary,Department,Designation from tblEmployee left join tblDepartment on tblDepartment.DepartmentID=tblEmployee.Department left join tblDesignation on tblDesignation.DesignationID=tblEmployee.Designation;
end



