using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using Clapgemini.EMS.BusinessLayer;
using System;

namespace Capgemini.EMS.PL
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {


                Console.WriteLine("1 Add employee, 2 Employee List, 3 Update Employee, 4 Delete Employee , 5 Exit");

                Console.WriteLine("Enter you choice");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        Employeelist();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                     case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("invlid input");
                        break;



                }

            }
        }

        private static void DeleteEmployee()
        {
            //empid
            string input;
            int empId;
            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            //emp-id check
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("employye not found");
                return;
            }
            //delete
            var isDeleted= EmployeeBL.Delete(empId);
            if (isDeleted)
            {
                Console.WriteLine("Employee Deleted successfully");

            }
            else
            {
                Console.WriteLine("failed to delete");
            }

        }


        private static void UpdateEmployee()
        {
           
           //emp id
             
            //update

            string input;
            int empId;
            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            //emp id- check
            var existingEmployee = EmployeeBL.GetById(empId);
            if(existingEmployee == null)
            {
                Console.WriteLine("employee not found");
                return;
            }
            // name/ dateofjoining
            Employee newEmp = new Employee();
            newEmp.Id = empId;
            
            do
            {
                Console.WriteLine("Enter employee name");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmp.Name = input;

            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter date of joining");
                input = Console.ReadLine();

            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmp.DateOfJoining = dateOfJoining;
            //update
            var isUpdated = EmployeeBL.Update(existingEmployee);
            if(isUpdated)
            {
                Console.WriteLine("Employee updated successfully");

            }
            else
            {
                Console.WriteLine("Employee update failed");
            }
        }

        private static void Employeelist()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine("employee list");
            foreach(var emp in list)
            {
                Console.WriteLine(emp);
            }
        }

        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();
           
            string input;
            int empId;
            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));
            newEmployee.Id = empId;

            do
            {
                Console.WriteLine("Enter employee name");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmployee.Name= input;

            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter date of joining");
                input = Console.ReadLine();
                
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmployee.DateOfJoining = dateOfJoining;


            //call BL
            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);
                if (isAdded)
                {
                    Console.WriteLine("Employee added successfully");
                }
                else
                {
                    Console.WriteLine( "failed");
                }

            }
            catch (EmsException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
