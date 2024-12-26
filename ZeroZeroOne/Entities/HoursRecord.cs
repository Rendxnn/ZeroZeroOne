namespace ZeroZeroOne.Entities
{
    public class HoursRecord
    {
        public string ProjectId { get; set; } = null!;
        public string ActivityId { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string Date { get; set; } = DateTime.Now.ToString();
        public int Minutes { get; set; }
        public string Observation { get; set; } = null!;
    }
}
