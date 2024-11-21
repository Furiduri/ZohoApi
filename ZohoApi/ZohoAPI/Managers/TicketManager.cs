using ZohoApi.ZohoAPI.Models;

namespace ZohoApi.ZohoAPI.Managers
{
    public class TicketManager : ZohoApi.ZohoApi
    {
        private readonly string MethodApi = "/api/v1/tickets";
        public TicketManager(ZohoConfig setting) : base(setting)
        {
        }

        /// <summary>
        /// Create Ticket.
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>Ticket created.</returns>
        /// <exception cref="HttpRequestException"></exception>
        public TicketZoho? Post(TicketZoho ticket)
        {
            if (ticket.Channel == null)
            {
                ticket.Channel = "Web";
            }
            ZohoApiResponse<TicketZoho?> res = this.RunDeskPost(ticket, this.MethodApi);
            if (res.Status)
            {
                return res.Data;
            }
            else
            {
                throw new HttpRequestException($"Code: {res.Code}, Msg: {res.ErrorMessage}");
            }
        }
    }
}
