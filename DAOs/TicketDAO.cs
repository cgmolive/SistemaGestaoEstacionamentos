using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Controller
{
    public class TicketDAO
    {
        public void GerarTicket(Tickets ticket)
        {

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Tickets.Add(ticket);
                repo.SaveChanges();
            }
        }
        public IList<Tickets> Lista()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                return repo.Tickets.ToList();
            }
        }
        public void Valida(Tickets ticket)
        {
            
        }
    }
}
