//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TutorAppBak.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<int> tutor_id { get; set; }
        public Nullable<System.DateTime> reservation_date { get; set; }
        public Nullable<System.TimeSpan> reservation_time_start { get; set; }
        public Nullable<System.TimeSpan> reservation_time_end { get; set; }
        public Nullable<int> subject_id { get; set; }
    }
}
