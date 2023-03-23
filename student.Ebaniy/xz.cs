﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private int age;
    private double average;

    public string getFirstName()
    {
        return firstName;
    }
    public void setFirstName(string name)
    {
        bool pivo = false;
        while (!pivo)
        {
            try
            {
                if (name.Length == 0)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid firstname");
                name = Console.ReadLine();
            }
            firstName = name;
        }
    }

    public string getLastName() { return lastName; }
    public void setLastName(string name)
    {
        bool pivo = false;
        while (!pivo)
        {
            try
            {
                if (name.Length == 0)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalide lastname");
                name = Console.ReadLine();
            }
            lastName = name;
        }
    }

    public int getAge() { return age; }
    public void setAge(int age)
    {
        bool pivo = false;
        while (!pivo)
        {
            try
            {
                if (age <= 17 || age > 25)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalide age");
                age = Int32.Parse(Console.ReadLine());
            }
            this.age = age;
        }
    }

    public double getAverage() { return average; }
    public void setAverage(double average)
    {
        bool pivo = false;
        while (!pivo)
        {
            try
            {
                if (average <= 0 || average > 12)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong average mark");
                average = double.Parse(Console.ReadLine());
            }
            this.average = average;
        }
    }

    public Student()
    {
        lastName = GenerateName();
        firstName = GenerateName();
        age = GenerateAge();
        average = GenerateAverage();
    }

    private static readonly Random rand = new Random();
    private static string GenerateName()
    {
        string[] names = { "James", "Javier", "Stuart", "Michael", "Amy", "Susan", "Adams", "Sarah", "Connor", "Jamal" };
        return names[rand.Next(names.Length)];
    }
    private static int GenerateAge()
    {
        return rand.Next(17, 25);
    }
    private static double GenerateAverage()
    {
        return Math.Round(rand.NextDouble() * 2 + 3, 2);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
    public static bool operator ==(Student st1, Student st2)
    {
        if (st1.average == st2.average) return true;
        else return false;
    }
    public static bool operator !=(Student st1, Student st2)
    {
        return !(st1 == st2);
    }
}

public class Group    
{
    private List<Student> students = new List<Student>();
    private string name;
    private string specialization;
    private int course;

    public Group()
    {
        name = "Group П11";
        specialization = "Computer Science";
        course = 1;
        for (int i = 0; i < 10; i++)
        {
            AddStudent();
        }
    }

    public Group(List<Student> students)
    {
        name = "Group П11";
        specialization = "Computer Science";
        course = 1;
        this.students = students;
    }

    public Group(Group group)
    {
        name = group.name;
        specialization = group.specialization;
        course = group.course;
        students = new List<Student>(group.students);
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Group name is {name}");
        Console.WriteLine($"Specialization is {specialization}");
        Console.WriteLine($"Course {course}");
        Console.WriteLine("Pivohlebi:");
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i].getLastName()} {students[i].getFirstName()}");
        }
    }

    public void AddStudent()
    {
        students.Add(new Student());
    }

    public void EditGroup(string name, string specialization, int course)
    {
        bool pivo = false;
        while (!pivo)
        {
            try
            {
                if (name.Length == 0)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not valide group name");
                name = Console.ReadLine();
            }
            this.name = name;
        }

        pivo = false;
        while (!pivo)
        {
            try
            {
                if (specialization.Length == 0)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("unacceptable specialization");
                specialization = Console.ReadLine();
            }
            this.specialization = specialization;
        }


        pivo = false;
        while (!pivo)
        {
            try
            {
                if ((course <= 0) || (course > 5))
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalide course");
                course = Int32.Parse(Console.ReadLine());
            }
            this.course = course;
        }
    }

    public void EditStudent(int id, string lastName, string firstName, int age, double average)
    {
        bool pivo = false;
        while (!pivo)
        {
            try
            {
                if (id < 0 || id > students.Count)
                    throw new Exception();
                else pivo = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalide index");
                id = Int32.Parse(Console.ReadLine());
            }
        }
        students[id].setLastName(lastName); students[id].setFirstName(firstName); students[id].setAge(age); students[id].setAverage(average);
    }

    public void TransferStudent(int index, Group group)
    {
        group.students.Add(students[index]);
        students.RemoveAt(index);
    }

    public void ExpelFailedStudents()
    {
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].getAverage() < 3.0)
            {
                students.RemoveAt(i);
                i--;
            }
        }
    }

    public void ExpelWorstStudent()
    {
        int worstIndex = 0;
        double worstAverage = students[0].getAverage();
        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].getAverage() < worstAverage)
            {
                worstIndex = i;
                worstAverage = students[i].getAverage();
            }
        }
        students.RemoveAt(worstIndex);
    }

    public bool checkEqualStudents(int st1, int st2)
    {
        if (students[st1] == students[st2]) return true;
        else return false;
    }

    public static bool operator ==(Group g1, Group g2)
    {
        if (g1.students.Count == g2.students.Count)
            return true;
        else
            return false;
    }
    public static bool operator !=(Group g1, Group g2)
    {
        return !(g1 == g2);
    }
}