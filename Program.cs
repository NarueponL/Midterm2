using System;

namespace Midterm2
{
    enum Menu
    {
        Register = 1,
        Login = 2
    }
    enum Type
    {
        Student = 1,
        Employee = 2
    }
    class Program
    {
        static PersonList personList;
        
        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            WelcomePage();
        }

        static void WelcomePage()
        {
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyBoard();

        }
        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }

        //หน้าหลัก
        static void PrintHeader()
        {
            Console.WriteLine("Wekcome to Digital Library");
            Console.WriteLine("--------------------------");
        }
        static void PrintListMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
        }
        //เลือกเมนู
        static void InputMenuFromKeyBoard() //เลือกเมนูที่จะไป
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            
            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            Console.Clear();
            if (menu == Menu.Register)
            {
                ShowRegisterScreen();
            }
            else if (menu == Menu.Login)
            {
                ShowLoginScreen();
            }
            else
            {
                ShowMessageInputMenuIsIncorrect();
            }
        }
        //กรอกเมนูผิด
        static void ShowMessageInputMenuIsIncorrect() 
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again");

            WelcomePage();
        }
        //หน้าลงทะเบียน
        static void ShowRegisterScreen()
        {
            PrintRegisterHeader();
            Type input = InputType();
            if (input == Type.Student)
            {
                Student student = CreateStudent();
                Program.personList.AddNewPerson(student);
                Console.Clear();
                WelcomePage();
            }
            else if (input == Type.Employee)
            {
                Employee employee = CreateEmployee();
                Program.personList.AddNewPerson(employee);
                Console.Clear();
                WelcomePage();
            }

        }
        static void PrintRegisterHeader()
        {
            Console.WriteLine("Register new Person");
            Console.WriteLine("-------------------");
        }        
        //ลงทะเบียน
        static Student CreateStudent()
        {
            return new Student(InputUserName(),
                InputPassWord(),
                InputStudentID());
        }
        static Employee CreateEmployee()
        {
            return new Employee(InputUserName(),
                InputPassWord(),
                InputEmployeeID());
        }
        //หน้าล็อคอิน
        static void ShowLoginScreen()
        {
            PrintLoginHeader();
            CheckUserNameAndPassWord(InputUserName(),InputPassWord());
        }
        static void PrintLoginHeader()
        {
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------");
        }

        //เช็คชื่อและหหัส
        static void CheckUserNameAndPassWord(string userName,string passWord)
        {
            Person user = new Person(userName, passWord);
            bool userCheck = personList.CheckPersonList(user);
            int typeCheck = personList.CheckType(user);
            if (userCheck == true) //ผู้ใช้มีชื่อในระบบ?
            {
                if(typeCheck == 1) //ผู้ใช้เป็นกลุ่มไหน?
                {
                    ShowStudentManagementPage(user);
                }
                if(typeCheck == 2)
                {
                    ShowEmployeeManagementPage(user);
                }
            }
            else if(userCheck == false)
            {
                Console.Clear();
                WelcomePage();
            }

        }

        //หน้าเมนูแต่ละกลุ่ม
        static void ShowStudentManagementPage(Person user)
        {
            StudentManagementHeader(user);
        }
        static void ShowEmployeeManagementPage(Person user)
        {
            EmployeeManagementHeader(user);
        }

        static void StudentManagementHeader(Person user)
        {
            Console.WriteLine("Student Management");
            Console.WriteLine("------------------");
            Console.WriteLine("Name" + user);
        }

        static void EmployeeManagementHeader(Person user)
        {
            Console.WriteLine("Employee Management");
            Console.WriteLine("-------------------");
            Console.WriteLine("Name" + user);
        }


        //ส่วนInput
        static Type InputType()
        {
            Console.Write("Type(1=Student 2=Employee): ");
            return (Type)int.Parse(Console.ReadLine());
        }
        static string InputUserName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static string InputPassWord()
        {
            Console.Write("PassWord: ");
            return Console.ReadLine();
        }
        static string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");
            return Console.ReadLine();
        }
    }
}
