using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hahn.ApplicationProcess.February2021.Data.Models
{
    public class Asset
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string AssetName { get; set; }
        public string Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EmailAddressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broker { get; set; } = false;

    }
}
