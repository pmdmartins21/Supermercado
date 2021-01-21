using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Supermercado
{
    enum EmployeeRole
    {
        Gerente,
        Repositor,
        Caixa
    }

    public class Employee
    {
        //attributes
        private string id;
        private string name;
        private string password;
        private EmployeeRole employeeRole;

        //properties
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        internal EmployeeRole EmployeeRole //internal
        {
            get { return employeeRole; }
            set { employeeRole = value; }
        }


        //constructors
        internal Employee(string id, string name, string password, EmployeeRole employeeRole)
        {
            Id = id;
            Name = name;
            Password = password;
            EmployeeRole = employeeRole;
        }
        internal Employee()
        {}

    }

    class EmployeeList
    {
        public List<Employee> employeeList;

        public EmployeeList()
        {
            this.employeeList = new List<Employee>();
        }

        public override string ToString()
        {
            string result = "ID   | NOME    | PASSWORD  | Tipo de Funcionário  \n";
            foreach (Employee f in this.employeeList)
            {
                result += f.Id + "   |  " + f.Name + "    |    " + f.Password + " | " + f.EmployeeRole + "\n";
            }
            return result;
        }
        public void ClearList()
        {
            this.employeeList.Clear();
        }
        public void LerFicheiro()
        {
            string path = Directory.GetCurrentDirectory();
            string filename = "/../../../employeelist.txt";

            StreamReader streamReader = new StreamReader(path + filename);

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                string id = line.Split(",")[0];
                string name = line.Split(",")[1];
                string password = line.Split(",")[2];
                Enum.TryParse(line.Split(",")[3], out EmployeeRole employeeRole);


                employeeList.Add(new Employee(id, name, password, employeeRole));
                //Console.WriteLine(streamReader.ReadLine());
            }

            streamReader.Close();
        }

        
        public void GravarParaFicheiro()
        {
            //Escolher directorio
            string path = Directory.GetCurrentDirectory();

            //nome do ficheiro
            string fileName = "/../../../employeelist.txt";

            //abrir a Stream para escrita
            StreamWriter streamWriter = new StreamWriter(path + fileName, false);


            //Percorrer e escrever a lista
            foreach (Employee item in this.employeeList)
            {
                streamWriter.Write(item.Id + "," + item.Name + "," + item.Password + "," + item.EmployeeRole + "\n");
                //streamWriter.Write(item.ToString());
            }


            //Fechar a stream de escrit
            streamWriter.Close();
        }


        public Employee FindEmployee(string id)
        {

            foreach (Employee e in this.employeeList)
            {
                if (e.Id.Equals(id))
                {
                    return e;
                }
            }

            return null;

        }

        public Employee EditEmployee(string id, string newName, string newPassword, EmployeeRole newEmployeeRole)
        {
            Employee e = FindEmployee(id);

            if (e != null)
            {
                if (!newName.Equals(""))  // if (String.IsNullOrEmpty(novoNome)
                {
                    e.Name = newName;
                }
                if (!newPassword.Equals(""))  // if (String.IsNullOrEmpty(novoNome)
                {
                    e.Password = newPassword;
                }
                if (!newEmployeeRole.Equals(""))  // if (String.IsNullOrEmpty(novoNome)
                {
                    e.EmployeeRole = newEmployeeRole;
                }
                GravarParaFicheiro();
                return e;
            }
            return null;
        }

        public bool RemoveEmployee(string id)
        {
            int indexAremover = -1;
            for (int i = 0; i < this.employeeList.Count; i++)
            {
                if (this.employeeList[i].Id.Equals(id))
                {
                    indexAremover = i;
                }
            }
            if (indexAremover != -1)
            {
                this.employeeList.RemoveAt(indexAremover);
                return true;
            }

            return false;
        }
        public bool ValidateEntry(string id, string password)
        {
            Employee empregadoAValidar = FindEmployee(id); // empregado ou null
            if (empregadoAValidar != null)
            {
                if (empregadoAValidar.Id == id && empregadoAValidar.Password == password) // ver com passes diferentes.
                {
                    Console.WriteLine("You have successfully logged in !!!");
                    return true;
                }
                else
                {
                    Console.WriteLine("User/Pass incorrecto");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("User/Pass incorrecto");
                return false;
            }
        
        }
        public Employee NewEmployee(string newId, string newName, string newPassword, EmployeeRole employeeRole)
        {
            Employee newEmployee = new Employee(newId, newName, newPassword, employeeRole);
            this.employeeList.Add(newEmployee);
            return newEmployee;
        }
    }
}