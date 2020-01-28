using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace T___обобщенный_тип
{
    class Program
    {



        static void Main(string[] args)
        {
            Account<string> Persona = new Account<string> { Sum = 5000 };
            Persona.Id = "Persona1";
           // Account<string>.session= "Persona1";
            Persona.Job = "Bank worrker";
            string s = Persona.Job == null ? "Dont have a job" : $"{Persona.Job}";
            Console.WriteLine($"ID: {Persona.Id} , SUM: {Persona.Sum}, is {s}");

            Account<string> Persona2 = new Account<string> { Sum = 1000 };
            Account<string>.session = "Persona2";
            string s2 = Persona2.Job == null ? "Dont have job" : $"{Persona2.Job}";
            Console.WriteLine($"ID: {Account<string>.session} , SUM: {Persona2.Sum}, is {s2}");


            //Использование нескольких универсальных параметров


            Transaction<Account<string>, string> transaction1 = new Transaction<Account<string>, string>
            {
                FromAccount = Persona,
                ToAccount = Persona2,
                Code = "45478758",
                Sum = 900
            };

            Persona.Sum -= transaction1.Sum;
            Persona2.Sum += transaction1.Sum;

            Console.WriteLine($"ID: {Persona.Id} , SUM: {Persona.Sum}, is {s}");
            Console.WriteLine($"ID: {Account<string>.session} , SUM: {Persona2.Sum}, is {s2}");

            
 
            Console.ReadLine();
        }


        class Account<T>
        {
            public static T session; //Статические поля обобщенных классов
            public T Id { get; set; }
            public int Sum { get; set; }
            public T Job = default(T);
        }
        class Transaction<U, V>
        {
            public U FromAccount { get; set; }  // с какого счета перевод 
            public U ToAccount { get; set; }    // на какой счет перевод
            public V Code { get; set; }         // код операции
            public int Sum { get; set; }        // сумма перевода
        }

    }
}
