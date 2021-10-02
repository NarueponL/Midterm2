using System;

class Employee : Person
{
	private string employeeID;
	public Employee(string name, string passWord, string employeeID)
		: base(name, passWord)
	{
		this.employeeID = employeeID;
	}
}
