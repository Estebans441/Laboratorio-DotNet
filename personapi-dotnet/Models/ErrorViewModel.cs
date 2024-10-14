// Scaffold-DbContext "Server=localhost,1433;Database=persona_db;User Id=sa;Password=Password123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/Entities
namespace personapi_dotnet.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
