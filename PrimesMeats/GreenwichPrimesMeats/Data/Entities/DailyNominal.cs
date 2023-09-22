namespace GreenwichPrimesMeats.Data.Entities
{
    public class DailyNominal
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan TotalHourDay => End - Start;

        WeekNominal WeekNominal { get; set; }
    }
}
