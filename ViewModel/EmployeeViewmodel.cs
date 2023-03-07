using CRUD_Empleado.Models;

namespace CRUD_Empleado.ViewModel
{
    public class EmployeeViewmodel
    {
        public Employee viewEmployee { get; set; }
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? job { get; set; }
        public float? salary { get; set; }
        public DateTime? hiredate { get; set; }
    }
}
