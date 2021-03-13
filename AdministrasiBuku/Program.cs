using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AdministrasiBuku
{
    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Metode CreateWebHostBuilder digunakan oleh Tools Entity Framework Core
        /// </summary>
        /// <param name="args"> Digunakan untuk melewatkan sejumlah variabel argumen ke suatu fungsi</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Memisahkan CreateWebHostBuilder dari kode Utama
        /// </summary>
        /// <param name="args">Digunakan untuk melewatkan daftar argumen dengan panjang variabel yang tidak menggunakan kata kunci</param>
        /// <returns>
        /// Pemisahan ini diperlukan jika Anda menggunakan Tools Entity Framework Core.
        /// Tools tersebut berharap menemukan metode CreateWebHostBuilder yang dapat dipanggil pada waktu desain untuk mengonfigurasi host tanpa menjalankan aplikasi.
        /// </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
