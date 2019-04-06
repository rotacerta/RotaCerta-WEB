using PBP_Frontend.Enums;
using PBP_Frontend.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PBP_Frontend.Repository
{
    public class ListRepository
    {
        private ApplicationContext db;

        public ListRepository(ApplicationContext context)
        {
            db = context;
        }

        public List<List> GetAvailableLists()
        {
            List<List> availablelists = new List<List>();
            string query = "SELECT ListId, Name, Requester, RunningTime FROM (SELECT l.*, MAX(cl.ListStatusId) AS StatusId " +
                                "FROM Lists AS l " +
                                "INNER JOIN ChangeLogs AS cl ON cl.ListId = l.ListId " +
                                "GROUP BY l.ListId, l.Name, l.Requester, l.RunningTime) AS LastListsStatus WHERE StatusId = @StatusId";
            availablelists = db.Database.SqlQuery<List>(query, new SqlParameter("@StatusId", ListStatusEnum.AVAILABLE)).ToList();
            return availablelists;
        }
    }
}