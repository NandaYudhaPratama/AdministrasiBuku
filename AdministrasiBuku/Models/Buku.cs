using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdministrasiBuku.Models
{
    public partial class Buku
    {
        [MaxLength(13, ErrorMessage = "ISBN maksimal 13 angka")]
        public string Isbn { get; set; }

        [Required (ErrorMessage = "Judul buku tidak boleh kosong")]
        public string JudulBuku { get; set; }

        [Required(ErrorMessage = "Nama Pengarang tidak boleh kosong")]
        public string Pengarang { get; set; }

        [Required(ErrorMessage = "Nama Penerbit tidak boleh kosong")]
        public string Penerbit { get; set; }

        [Required(ErrorMessage = "TahunTerbit tidak boleh kosong")]
        public string TahunTerbit { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage ="Masukkan angka!")]
        public int? Jumlah { get; set; }
    }
}
