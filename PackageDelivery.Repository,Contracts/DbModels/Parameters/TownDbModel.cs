using System;

namespace PackageDelivery.Repository.Contracts.DbModels.Parameters
{
    public class TownDbModel
    {
        public long Id { get; set; }
        public string name{ get; set; }
        public int IdDepartment { get; set; }

    }
}