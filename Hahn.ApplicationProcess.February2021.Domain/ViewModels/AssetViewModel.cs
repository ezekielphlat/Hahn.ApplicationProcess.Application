using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Domain.ViewModels
{
    public class AssetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public bool isBroken { get; set; } 
    }
}
