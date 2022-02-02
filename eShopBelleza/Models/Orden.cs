using System.Collections.Generic;

namespace eShopBelleza.Models
{
    public class Orden
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public string ClientAddress { get; set; }

        public double Total { get; set; }

        public int Offers { get; set; } = 0;

        public List<int> IdProducts { get; set; }

        public Orden()
        {
            IdProducts = new List<int>();
        }
    }
}
