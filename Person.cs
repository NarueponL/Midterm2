using System;

class Person
{
	public string name;
	public string passWord;
	public Person(string name,string passWord)
	{
		this.name = name;
		this.passWord = passWord;
	}

	public string Getname() //ส่งชื่อ
    {
		return this.name;
    }

}
