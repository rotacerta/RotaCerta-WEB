using PBP_Frontend.Models;
using PBP_Frontend.Enums;
using System.Collections.Generic;
using System;

namespace PBP_Frontend.Service
{
    public class ChangeLogService
    {
        private ApplicationContext db;

        public ChangeLogService(ApplicationContext context)
        {
            db = context;
        }

        public List<string> InsertChangeLog(ListStatusEnum status, int listId)
        {
            List<string> errors = new List<string>();
            try
            {
                db.ChangeLogs.Add(new ChangeLog { Date = DateTime.Now, ListId = listId, ListStatusId = (int) status });
                db.SaveChanges();
            }catch(Exception e)
            {
                errors.Add("Erro ao adicionar Log de alterações.");
            }
            return errors;
        }
    }
}