using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace MISDGit
{
    public class P : Dictionary<string,object>
    {
        public int RecordCount { get; set; }
        public string Exception { get; set; }
        public bool HasException { get { return !string.IsNullOrEmpty(Exception); } }
        public SqlDataAdapter da { get; set; }
        public DataTable dt { get; set; }
    }
    public class dbcontrol : P
    {
        SqlConnection cn = new SqlConnection("server=DESKTOP-DNK5REP;database=dbsample;user=sa;pwd=1234");
        SqlCommand cm;
        List<SqlParameter> param = new List<SqlParameter>();
        void q(string _query, CommandType _type)
        {
            RecordCount = 0;
            Exception = null;
            try
            {
                cn.Open();
                cm = new SqlCommand(_query, cn);
                cm.CommandType = _type;
                param.ForEach(p => cm.Parameters.Add(p));
                param.Clear();
                da = new SqlDataAdapter(cm);
                RecordCount = da.Fill(dt = new DataTable());
            }
            catch (Exception e)
            {
                Exception = $"Error: {e.Message}";
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        void p(string _name, object _value)
        {
            param.Add(new SqlParameter(_name.Contains("@") ? _name : "@"+_name, _value));
        }

        public DataTable Query(string _command, Action<P> _data = null, CommandType _type = CommandType.Text)
        {
            if (_data != null)
            {
                P data = new P();
                _data(data);
                foreach (KeyValuePair<string,object> d in data)
                {
                    p(d.Key, d.Value);
                }
            }
            q(_command, _type);
            return dt;
        }

        public void Insert(string Table, Action<P> _data)
        {
            string column = "", value = "";
            P data = new P();
            _data(data);
            foreach (KeyValuePair<string,object> d in data)
            {
                column += $"[{d.Key}],";
                value += $"@{d.Key},";
            }
            string command = $"INSERT INTO {Table} ({column.Substring(0, column.Length - 1)}) VALUES ({value.Substring(0, value.Length - 1)})";
            Query(command, _data);
        }

        public void Update(string Table, int ID, Action<P> _data)
        {
            string colval = "";
            P data = new P();
            _data(data);
            foreach (KeyValuePair<string,object> d in data)
            {
                colval += $"[{d.Key}]=@{d.Key},";
            }
            string command = $"UPDATE {Table} SET {colval.Substring(0, colval.Length - 1)} WHERE ID = @ID";
            Query(command, p => { _data(p); p.Add("@ID", ID); });
        }
    }
}
