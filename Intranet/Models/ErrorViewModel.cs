// W pliku Models/ErrorViewModel.cs
using System; // Potrzebne dla String.IsNullOrEmpty

namespace Intranet.Models // Upewnij się, że przestrzeń nazw jest poprawna
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
