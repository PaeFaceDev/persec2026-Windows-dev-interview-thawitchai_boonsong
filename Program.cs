using InterviewCodeLogic.Example4;
using InterviewCodeLogic.Example5;
using InterviewCodeLogic.Example6;
using InterviewCodeLogic.StartUp.Example_1;
using InterviewCodeLogic.StartUp.Example_1.Entity;
using InterviewCodeLogic.StartUp.Example_2;
using InterviewCodeLogic.StartUp.Example_2.Entity;
using InterviewCodeLogic.StartUp.Example_3;
using System;
namespace InserviewCodeLogic
{
    class Program
    {
        static void Main()
        {
            // Example 1
            IsValid exam_1 = new IsValid();
            InputType input = new InputType()
            {
                Input = "([[{}]]]"
            };
            bool checkIsValid = exam_1.CheckIsValid(input);
            Console.WriteLine($@"{input.Input} => {checkIsValid}");

            // Example 2
            PrefixRequest request = new PrefixRequest
            {
                Input = new[]
                    {
                        "TH10", "TH3Netflix" , "TH1", "TH7"
                    }
            };
            var response = new Prefix().SortArray(request);
            Console.WriteLine(string.Join(", ", response.Result));
            
            // Example 3
            string[] items = new[]
                {
                "Mother",
                "Think",
                "Worthy",
                "Apple",
                "Android"
            };

            var result = new Autocomplete().Search("th", items, 2);
            Console.WriteLine(string.Join(", ", result));

            // Example 4
            RomanNumeralConverter converter = new RomanNumeralConverter();

            Console.WriteLine(converter.ToRoman(1989));
            Console.WriteLine(converter.ToRoman(2000));
            Console.WriteLine(converter.ToRoman(68));
            Console.WriteLine(converter.ToRoman(109));

            Console.WriteLine();

            Console.WriteLine(converter.ToInteger("MCMLXXXIX"));
            Console.WriteLine(converter.ToInteger("MM"));
            Console.WriteLine(converter.ToInteger("LXVIII"));
            Console.WriteLine(converter.ToInteger("CIX"));


            // Example 5
            NumberSorter sorter = new NumberSorter();

            Console.WriteLine(sorter.SortDescending(3008));
            Console.WriteLine(sorter.SortDescending(1989));
            Console.WriteLine(sorter.SortDescending(2679));
            Console.WriteLine(sorter.SortDescending(9163));

            // Example 6
            Tribonacci tribonacci = new Tribonacci();

            tribonacci.Print(tribonacci.Generate(new List<int> { 1, 3, 5 }, 5));

            tribonacci.Print(tribonacci.Generate(new List<int> { 2, 2, 2 }, 3));

            tribonacci.Print(tribonacci.Generate(new List<int> { 10, 10, 10 }, 4));

        }


    }
}