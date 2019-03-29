using PBP_Frontend.Models;
using PBP_Frontend.ViewModels;
using System.Collections.Generic;

namespace PBP_Frontend.Service
{
    public class ListService
    {
        private ApplicationContext db = new ApplicationContext();

        public List<string> AddList(ListViewModel list)
        {
            List<string> errors = new List<string>();
            // TODO
            return errors;
        }
    }
}