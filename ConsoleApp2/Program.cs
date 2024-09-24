using System;

abstract class Document
{
    // Поля класу
    public string Title { get; set; }

    // Конструктор з параметром
    public Document(string title)
    {
        Title = title;
    }

    // Абстрактні методи
    public abstract void ShowInfo();
    public abstract void ShowShortInfo();
}

class Coursework : Document
{
    // Додаткові властивості для курсової
    public string Student { get; set; }
    public string Discipline { get; set; }
    public int Grade { get; set; }

    // Конструктор з параметрами
    public Coursework(string title, string student, string discipline, int grade)
        : base(title)
    {
        Student = student;
        Discipline = discipline;
        Grade = grade;
    }

    // Перший метод для роботи зі студентом та оцінкою
    public void UpdateGrade(string student, int grade)
    {
        if (Student == student)
        {
            Grade = grade;
            Console.WriteLine($"Курсова робота: {Title}\nСтудент: {Student}\nДисциплiна: {Discipline}\nОцiнка: {Grade}");
        }
        else
        {
            Console.WriteLine("Студента не знайдено.");
        }
    }

    // Другий метод для виведення короткої інформації
    public override void ShowShortInfo()
    {
        Console.WriteLine($"Назва роботи: {Title}, Оцiнка: {Grade}");
    }

    // Реалізація абстрактного методу для повної інформації
    public override void ShowInfo()
    {
        Console.WriteLine($"Назва роботи: {Title}\nСтудент: {Student}\nДисциплiна: {Discipline}\nОцiнка: {Grade}");
    }
}

class Diploma : Document
{
    // Додаткові властивості для дипломної роботи
    public string Student { get; set; }
    public int YearOfDefense { get; set; }
    public string Supervisor { get; set; }

    // Конструктор з параметрами
    public Diploma(string title, string student, int yearOfDefense, string supervisor)
        : base(title)
    {
        Student = student;
        YearOfDefense = yearOfDefense;
        Supervisor = supervisor;
    }

    // Метод для виведення інформації про диплом
    public void ShowDiplomaInfo(int yearOfDefense, string supervisor)
    {
        if (YearOfDefense == yearOfDefense && Supervisor == supervisor)
        {
            Console.WriteLine($"Назва: {Title}\nСтудент: {Student}\nРiк захисту: {YearOfDefense}\nКерiвник: {Supervisor}");
        }
        else
        {
            Console.WriteLine("Невiрний рiк або керiвник.");
        }
    }

    // Реалізація абстрактних методів
    public override void ShowInfo()
    {
        Console.WriteLine($"Назва: {Title}\nСтудент: {Student}\nРiк захисту: {YearOfDefense}\nКерiвник: {Supervisor}");
    }

    public override void ShowShortInfo()
    {
        Console.WriteLine($"Назва: {Title}, Студент: {Student}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо об'єкт класу Coursework
        Coursework coursework = new Coursework("Алгоритми i структури даних", "Iван Iванов", "Програмування", 85);

        // Викликаємо методи для курсової
        coursework.ShowInfo();
        coursework.UpdateGrade("Iван Iванов", 90);
        coursework.ShowShortInfo();

        // Створюємо об'єкт класу Diploma
        Diploma diploma = new Diploma("Розробка мобiльного додатку", "Марiя Петрiвна", 2023, "Олександр Сидорович");

        // Викликаємо методи для дипломної роботи
        diploma.ShowInfo();
        diploma.ShowDiplomaInfo(2023, "Олександр Сидорович");
    }
}
