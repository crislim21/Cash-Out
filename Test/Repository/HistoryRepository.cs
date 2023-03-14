using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Repository
{
    internal class HistoryRepository
    {
        private static List<History> listHistory = null;
        public static List<History> getListHistory()
        {
            if (listHistory == null)
            {
                listHistory = new List<History>();
            }
            return listHistory;

        }
    }
}
