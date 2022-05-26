using CSVHelperDemo;
using System;
public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Reading the Data from the File");
        PersonData data = new PersonData();
        data.ImplementationCsv();
        data.ImplementationJson();
    }
}