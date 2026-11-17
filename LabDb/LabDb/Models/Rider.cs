using System.ComponentModel.DataAnnotations.Schema;

namespace LabDb.Models
{
    [Table("Riders")]
    public class Rider
    {
        // RiderName RiderID TotalDelivery TotalWorking Rating TotalDistance

        public string name { get; set; }
        public int id { get; set; }
        public int totalDelivery { get; set; }
        public int totalWorking { get; set; }
        public double rating { get; set; }
        public int totalDistance { get; set; }
    }
}
