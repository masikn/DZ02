using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            Kadrovik one = new Kadrovik("З.Ф.П.");
            Console.WriteLine(one.GetFio());
            Console.WriteLine(one.GetDol() + "\n");
            Student four = one.GetCosdaetSt("М.Р.Р.", "М-21-19");
            Console.WriteLine(four.GetFio());
            Console.WriteLine(four.GetGropp() + "\n");
            Propodavatel five = one.GetCosdaetPr("Р.И.Н.", Prepod.Assistant);
            Console.WriteLine(five.GetFio());
            Console.WriteLine(five.GetDol() + "\n");
            Propodavatel two = new Propodavatel("А.Х.Г.", Prepod.StLecturer);
            Console.WriteLine(two.GetFio());
            Console.WriteLine(two.GetDol());
            Console.WriteLine(two.GetLekcee() + "\n");
            Console.ReadKey();
        }
    }

    interface IFio
    {
        string GetFio();
    }
    interface IDolsnoct : IFio
    {
        string GetDol();
    }
    interface IGropp : IFio
    {
        string GetGropp();
    }
    interface ICosdaet : IDolsnoct
    {
        Student GetCosdaetSt(string name, string grup);
        Propodavatel GetCosdaetPr(string name, Prepod dolj);
    }
    interface ILekcee : IDolsnoct
    {
        string GetLekcee();
    }
    interface IZayavlen : IGropp
    {
        string GetZayavlen();
    }
    public abstract class Person
    {
        string Name;
        public Person(string name)
        {
            this.Name = name;
        }
        public string GetFio()
        {
            return Name;
        }
    }
    public class Sotrudnik : Person
    {
        string dolj;
        public Sotrudnik(string name, string dolj) : base(name)
        {
            this.dolj = dolj;
        }
        public string GetDol()
        {
            return dolj;
        }
    }
    public class Kadrovik : Sotrudnik, ICosdaet
    {
        public Kadrovik(string name) : base(name, "кадровик")
        {

        }
        public Student GetCosdaetSt(string nameS, string grup)
        {
            return new Student(nameS, grup);
        }
        public Propodavatel GetCosdaetPr(string namePr, Prepod dolj)
        {
            return new Propodavatel(namePr, dolj);
        }
    }
    public enum Prepod
    {
        Assistant = 0,
        StLecturer = 1
    }

    public class Propodavatel : Sotrudnik, ILekcee
    {
        static string[] dol = new string[] { "Ассистент", "Старший преподаватель" };
        public Propodavatel(string Name, Prepod dolj) : base(Name, dol[(int)dolj])
        {

        }
        public string GetLekcee()
        {
            return "проводит лекции";
        }
    }
    public class Student : Person, IZayavlen
    {
        string grup;
        public Student(string Name, string Grup) : base(Name)
        {
            this.grup = Grup;
        }
        public string GetGropp()
        {
            return grup;
        }
        public string GetZayavlen()
        {
            return "заявление на отчисление";
        }
    }
}

