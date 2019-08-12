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
        public void GerarTicket()
        {
            Tickets t = new Tickets();

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Tickets.Add(t);
                repo.SaveChanges();
            }
        }
        public void Recuperar()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Tickets> tickets = repo.Tickets.ToList();
            }
        }
        public void Valida(Tickets ticket)
        {
            
        }
    }
}
