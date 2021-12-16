using System;
using System.Threading.Channels;
using Business;
using Business.Concrete;
using ConsoleUI.Console;
using DataAccess.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerConsole customerConsole = new CustomerConsole();
            customerConsole.GetAll();
            customerConsole.Get(1);

            ProductConsole productConsole = new ProductConsole();
            productConsole.GetAll();
            productConsole.Get(6);


            OrderConsole orderConsole = new OrderConsole();
            orderConsole.GetAll();
            orderConsole.Get(6);



        }

    }

}

