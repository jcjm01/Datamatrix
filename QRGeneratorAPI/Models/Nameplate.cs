namespace QRGeneratorAPI.Models
{
    public class Nameplate
    {
        public int Id { get; set; }
        public string SalesOrder { get; set; }
        public string UnitDescription { get; set; }
        public string SerialNumber { get; set; }
        public string Refrigerant { get; set; }
        public string ElectricalData { get; set; }
        public string WorkingPressures { get; set; }
        public string Diagrams { get; set; }
        public string CustomerPartNumber { get; set; }
    }
}
