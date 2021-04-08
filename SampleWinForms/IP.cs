using System.Data;
using System.Data.SqlClient;

namespace SampleWinForms
{
    public interface IP
    {
        SqlDataAdapter da { get; set; }
        DataTable dt { get; set; }
        string Exception { get; set; }
        bool HasException { get; }
        int RecordCount { get; set; }
    }
}