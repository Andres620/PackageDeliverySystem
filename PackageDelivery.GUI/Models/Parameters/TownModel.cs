using System;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class TownModel
    {
        [Key]
        public long Id { get; set; }
        public string name { get; set; }
        public int IdDepartment { get; set; }

    }
}