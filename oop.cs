using System;
using System.Collections.Generic;

class Student
{
    // Private fields
    private int studentId;
    private string name;
    private int age;

    // Properties with encapsulation
    public int StudentId
    {
        get { return studentId; }
        set { studentId = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 16 && value <= 60)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Invalid age! Must be between 16 and 60.");
            }
        }
    }

    // Constructor
    public Student(int studentId, string name, int age)
    {
        this.StudentId = studentId;
        this.Name = name;
        this.Age = age;
    }

    // Virtual method for polymorphism
    public virtual string GetDetails()
    {
        return $"Student ID: {StudentId}, Name: {Name}, Age: {Age}";
    }
}

// Inheritance
class ITStudent : Student
{
    private string programmingLanguage;

    public string ProgrammingLanguage
    {
        get { return programmingLanguage; }
        set { programmingLanguage = value; }
    }

    // Constructor
    public ITStudent(int studentId, string name, int age, string programmingLanguage)
        : base(studentId, name, age)
    {
        this.ProgrammingLanguage = programmingLanguage;
    }

    // Override GetDetails
    public override string GetDetails()
    {
        return $"IT Student ID: {StudentId}, Name: {Name}, Age: {Age}, Language: {ProgrammingLanguage}";
    }
}

class Program 
{ 
    static void Main() 
    { 
        // Polymorphism & Collections 
        List<Student> students = new List<Student>(); 
        // Add one normal Student 
        students.Add(new Student(1, "Alice", 20)); 
        // Add two ITStudent objects 
        students.Add(new ITStudent(2, "Bob", 22, "C#")); 
        students.Add(new ITStudent(3, "Charlie", 25, "Java")); 
        // Display all students using polymorphism 
        foreach (Student s in students) 
        {
             Console.WriteLine(s.GetDetails()); 
        } 
        // Encapsulation & Validation demo 
        Student testStudent = new Student(4, "David", 15); 
        // Invalid age 
        Console.WriteLine(testStudent.GetDetails()); 
        testStudent.Age = 70; 
        // Invalid age 
        Console.WriteLine(testStudent.GetDetails());
        testStudent.Age = 30; 
        // Valid age 
        Console.WriteLine(testStudent.GetDetails()); 
        } 
}