using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace dbhelper
{
    interface Iconnection
    {
        void load();
        void deleteLastRow();
        void updateTable();
        void addRowToTable();
    }
}
