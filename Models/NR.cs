//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasaNR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NR
    {
        public int OBJECTID { get; set; }
        public string Reference_ { get; set; }
        public string Prenom { get; set; }
        public string Societe { get; set; }
        public string Qualite { get; set; }
        public string Nature_ter { get; set; }
        public string Zonage { get; set; }
        public string indice_Equ { get; set; }
        public string Voirie { get; set; }
        public string Autres { get; set; }
        public string NR_Id { get; set; }
        public string Etat { get; set; }
        public decimal SHAPE_STAr { get; set; }
        public decimal SHAPE_STLe { get; set; }
        public System.Data.Entity.Spatial.DbGeometry SHAPE { get; set; }
    }
}
