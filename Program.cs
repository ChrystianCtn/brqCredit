using brqCredit;
using brqCredit.Application.Class;
using brqCredit.Application.Interface;
using brqCredit.Application.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        var start = new Startup(args);
        var dateFormat = start.Configuration["dateFormat"]?.ToString();

        try
        {
            Console.WriteLine("Reference date (MM/dd/yyyy):");
            DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);

            Console.WriteLine("Trades's number:");
            int tradesNumber = int.Parse(Console.ReadLine());

            List<ITrade> trades = new List<ITrade>();

            for (int i = 0; i < tradesNumber; i++)
            {
                Console.WriteLine($"Enter trade: {i + 1}");
                string[] tradeDetails = Console.ReadLine().Split(' ');

                double value = double.Parse(tradeDetails[0]);
                string sector = tradeDetails[1];
                DateTime nextPaymentDate = DateTime.ParseExact(tradeDetails[2], dateFormat, CultureInfo.InvariantCulture);

                trades.Add(new Trade { Value = value, ClientSector = sector, NextPaymentDate = nextPaymentDate });
            }

            Console.WriteLine();
            var validador = new CategoryValidation(start.Configuration);

            foreach (var trade in trades)
            {
                Console.WriteLine(validador.ValidateCategory(trade, referenceDate));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro: " + ex.Message);
        }
    }
}