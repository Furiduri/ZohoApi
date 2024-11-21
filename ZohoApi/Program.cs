using global::ZohoApi.ZohoAPI.Models;
using Microsoft.Extensions.Configuration;
using ZohoApi.ZohoAPI.Managers;

namespace ZohoApi;
internal class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
        var config = configuration.Build();
        var setting = config.GetSection("ZohoConfig").Get<ZohoConfig>();

        var apiTicket = new TicketManager(setting);
        var tikect = apiTicket.Post(new TicketZoho
        {
            DepartmentId = 254878,
            Subject = "Test API - Customs Fields",
            Description = "prueba de api zoho desde c#. prueba",
            Channel = "Web",
            Language = "Spanish",
            Contact = new() { 
                Email = "test.perez@hotmail.com", 
                FirstName = "Jorge", 
                LastName = "Luis" 
            },
            Priority = "Alto",
            Classification = "Otro",
            Cf = new TicketZoho.CustomField
            {
                Cf_severidad = "Baja",
                Cf_esfuerzo = "2",
                Cf_modulo_error = "Servicios"
            }
        });
    }
}