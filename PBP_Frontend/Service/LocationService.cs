using PBP_Frontend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PBP_Frontend.Service
{
    public class LocationService
    {
        private ApplicationContext db;

        public LocationService(ApplicationContext context)
        {
            db = context;
        }

        public LocationService()
        {
            db = new ApplicationContext();
        }

        public SelectList GetLocationsToDropDownList()
        {
            List<Location> locations = db.Locations.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "(Selecione)", Selected = true }
            };
            foreach (Location location in locations)
            {
                selectList.Add(new SelectListItem { Value = location.LocationId.ToString(), Text = location.ToString() });
            }
            return new SelectList(selectList, "Value", "Text");
        }

        public List<Location> GetAll()
        {
            return db.Locations.ToList();
        }
    }
}