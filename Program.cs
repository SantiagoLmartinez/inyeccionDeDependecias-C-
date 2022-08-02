using inyeccionDeDependencias.Services;
using inyeccionDeDependencias.Repositories;

using System;

namespace inyeccionDeDependencias
{
    class Program
    {
    static void Main(string[] args) {
            //dependecies
            var sender = new SmsService();
            var connection = new OracleConnection(); 
            var repository = new CustomerRepository(connection);

            var customerService = new CustomerService(repository);
            var communicationService = new CommunicationService(sender);
           
            var customers = customerService.GetCustomers();
            var message = "";

            foreach (var customer in customers)
            {
                communicationService.SendMessage(customer, message);
            };
    }

    }
}