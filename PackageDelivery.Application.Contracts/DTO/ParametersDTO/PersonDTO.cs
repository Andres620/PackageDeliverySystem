namespace PackageDelivery.Application.Contracts.DTO.ParametersDTO
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string firstName { get; set; }
        public string otherNames { get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public string identificationNumber { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public long IdAddress { get; set; }
        public int IdDocumentType { get; set; }

    }
}