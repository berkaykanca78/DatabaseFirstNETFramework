//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirstNETFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oyuncu
    {
        public int ID { get; set; }
        public int TakimID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Yasi { get; set; }
        public int Mevki { get; set; }
        public decimal Maas { get; set; }
        public int SozlesmeSuresi { get; set; }
        public int Ulke { get; set; }
    
        public virtual Mevki Mevki1 { get; set; }
        public virtual Takim Takim { get; set; }
        public virtual Ulke Ulke1 { get; set; }
    }
}
