using System;

namespace AdministrasiBuku.Models
{
    /// <summary>
    /// akan di tampilkan jika terjadi error
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}