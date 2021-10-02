using System;
using System.Collections.Generic;

class PersonList
{
	private List<Person> personList;
	public PersonList()
	{
		this.personList = new List<Person>();
	}
	public void AddNewPerson(Person person) //เพิ่มผู้ใช้
    {
		this.personList.Add(person);
    }
    public bool CheckPersonList(Person user) //เช็คชื่อ-รหัส
    {
        bool check = false;
        foreach (Person person in this.personList)
        {
            if (user.name == person.name && user.passWord == person.passWord)
            {
                check = true;
            }
            else
            {
                check = false;
            }
        }
        return check;

    }
    
    public int CheckType(Person user) //เช็คกลุ่ม
    {
        int groupNum = 0;
        foreach(Person userCheck in this.personList)
        {
            if((user.name == userCheck.name && user.passWord == userCheck.passWord) && userCheck is Student)
            {
                groupNum = 1;
            }
            else if ((user.name == userCheck.name&&user.passWord == userCheck.passWord)&& userCheck is Employee)
            {
                groupNum = 2;
            }
        }
        return groupNum;
    }

    



}
