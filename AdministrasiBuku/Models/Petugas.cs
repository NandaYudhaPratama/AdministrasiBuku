using System;
using System.Collections.Generic;

namespace AdministrasiBuku.Models
{
    /// <summary>
    /// Petugas Models
    /// </summary>
    public partial class Petugas
    {
        //public Petugas()
        //{
          //  Petugas = new HashSet<Petugas>();
        //}
        /// <summary>
        /// mmendapatkan id petugas, username, dan password
        /// </summary>
        public int IdPetugas { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //public ICollection<Petugas> Petugas { get; set; }
    }
}
