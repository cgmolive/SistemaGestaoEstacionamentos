using SistemaDeEstacionamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEstacionamentos.Controller
{
    public class TicketController
    {
        private static void Gravar()
        {
            Tickets t = new Tickets();

            using (var repo = new SistemaEstacionamentosContext())
            {
                repo.Tickets.Add(t);
                repo.SaveChanges();
            }
        }
        private static void Recuperar()
        {
            using (var repo = new SistemaEstacionamentosContext())
            {
                IList<Tickets> tickets = repo.Tickets.ToList();
            }
        }
        
    }
}
