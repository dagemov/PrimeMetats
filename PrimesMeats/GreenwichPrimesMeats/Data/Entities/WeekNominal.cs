namespace GreenwichPrimesMeats.Data.Entities
{
    public class WeekNominal
    {
        public int Id{ get; set; }
        public  double HourValue{ get; set; }
        public int TotalHour {  get; set; }
        public int TotalMinute { get; set; }
        public double TotalPay { get; set; }
        public ICollection<DailyNominal> Days { get; set; }
        public User User { get; set; }

        public DateTime DateTimeCreation { get; set; }
        //Hacer calculo de que si alguien entre un miercoles se le cuenten cuantos dias faltan para el sabado y darlo de alta 
    }
}
