using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<int, List<string>> school = new Dictionary<int, List<string>>();

    public bool Add(string student, int grade)
    {
        if (school.Values.Any(s => s.Contains(student)))
        {
            Console.WriteLine($"Student {student} is already in the roster.");
            return false;
        }

        if (!school.ContainsKey(grade))
        {
            school[grade] = new List<string>();
        }

        school[grade].Add(student);
        school[grade].Sort(); 
        Console.WriteLine($"Added {student} to grade {grade}.");
        return true;
    }

    public IEnumerable<string> Roster()
    {
        var allStudents = school.OrderBy(g => g.Key) 
                                 .SelectMany(g => g.Value) 
                                 .ToList();

        Console.WriteLine("All students in school:");
        foreach (var student in allStudents)
        {
            Console.WriteLine(student);
        }

        return allStudents;
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (school.ContainsKey(grade))
        {
            Console.WriteLine($"Students in grade {grade}:");
            foreach (var student in school[grade])
            {
                Console.WriteLine(student);
            }
            return school[grade];
        }
        else
        {
            Console.WriteLine($"No students in grade {grade}.");
            return new List<string>();
        }
    }
}

class Program
{
    static void Main()
    {
        GradeSchool school = new GradeSchool();

        school.Add("Raity", 2);
        school.Add("Zahra", 1);
        school.Add("Baran", 1);
        school.Add("Darya", 2);
        school.Add("Abbas", 2);
        school.Add("Abbas", 5);  
        
        school.Grade(2);

        school.Roster();
    }
}
