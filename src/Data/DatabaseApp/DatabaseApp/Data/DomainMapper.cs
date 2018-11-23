namespace DatabaseApp.Data
{
    public static class DomainMapper
    {
        public static DTO.EmployeeDTO ToDTO(this Model.Employee employee)
        {
            return new DTO.EmployeeDTO()
            {
                Department = employee.Department,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Salary = employee.Salary,
                ID = employee.ID
            };
        }

        public static Model.Employee ToModel(this DTO.EmployeeDTO dto)
        {
            return new Model.Employee(dto.ID)
            {
                Department = dto.Department,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Salary = dto.Salary
            };
        }
    }
}
