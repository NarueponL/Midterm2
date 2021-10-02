using System;

class Student : Person
{
	
	public string studentID;
	public Student(string name,string passWord,string studentID)
		: base(name,passWord)
	{
		this.studentID = studentID;
	}

	public string GetStudentID()
    {
		return this.studentID;
    }
}
