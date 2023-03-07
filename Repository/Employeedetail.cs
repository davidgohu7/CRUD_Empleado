using CRUD_Empleado.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Empleado.Repository
{
    public class Employeedetail : IEmployee
    {
        private readonly Empdbcontext _context;

        public Employeedetail(Empdbcontext context)
        {
            _context = context;
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            if (employee != null)
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.id;
            }
            return 0;
        }

        public async Task<int> DeleteEmployee(int? id)
        {
            int Getresult = 0;

            try
            {
                if (id != null)
                {
                    _context.Remove(_context.Employee.Single(Empid => Empid.id == id));
                    Getresult = await _context.SaveChangesAsync();
                    return Getresult;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Getresult;
        }


        public async Task<int> UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                return employee.id;
            }
            return 0;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            if (_context != null)
            {
                return await _context.Employee.ToListAsync();
            }

            return null;
        }

        public Employee GetEmployeeById(int id)
        {

            if (_context != null)
            {
                return _context.Employee.FirstOrDefault(e => e.id == id);

            }
            return null;
        }
    }
}
