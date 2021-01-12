using System;
using System.Collections.Generic;

namespace AdministrasiBuku.Models
{
    public partial class Petugas
    {
        //public Petugas()
        //{
          //  Petugas = new HashSet<Petugas>();
        //}

        public int IdPetugas { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //public ICollection<Petugas> Petugas { get; set; }
    }
}
