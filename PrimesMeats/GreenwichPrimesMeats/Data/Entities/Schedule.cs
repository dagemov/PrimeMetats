using System.Data;

namespace GreenwichPrimesMeats.Data.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime BreakStart { get; set; }
        public DateTime BreakEnd { get; set; }
        public TimeSpan TotalHour => ((DateEnd-DateStart)-(BreakEnd-BreakStart));

    }
}
