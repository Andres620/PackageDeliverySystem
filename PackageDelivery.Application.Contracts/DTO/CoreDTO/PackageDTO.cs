namespace PackageDelivery.Application.Contracts.DTO.CoreDTO
{
    public class PackageDTO
    {
        public int Id { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public float depth { get; set; }
        public float width { get; set; }
        public int idOffice { get; set; }

    }
}