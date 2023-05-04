namespace PackageDelivery.Repository.Contracts.DbModels.Core
{
    public class PackageDbModel
    {
        public int Id { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public float depth { get; set; }
        public float width { get; set; }
        public int idOffice { get; set; }

    }
}