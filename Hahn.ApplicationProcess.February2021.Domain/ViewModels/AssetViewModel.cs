using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Domain.ViewModels
{
    public class AssetViewModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of Asset
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Department of Asset
        /// </summary>
        public Department Department { get; set; }
        /// <summary>
        /// Country of Department
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Email of Department
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Date Asset was purchaced
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Broken condition of asset
        /// </summary>
        public bool isBroken { get; set; } 
    }
}
