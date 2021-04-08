using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AAJdbController;
namespace SampleWinForms
{
    public class dbcontrol : AAJControl
    {
        public dbcontrol() : base(DatabaseType.SQLServer, @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|dbsample.mdf';Integrated Security=True")
        {

        }
    }
}
