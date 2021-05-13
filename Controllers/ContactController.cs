using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactTrackerApplication.Models;
using NLog;
using Microsoft.Extensions.Logging;
using ContactTrackerApplication.Interfaces;

namespace ContactTrackerApplication.Controllers
{
    [ApiController]
    public class ContactController : Controller
    {
        private ILog logger;
        LogNLog Newlog = new LogNLog();

        [Route("api/[controller]")]
        [HttpPost]
        public string InsertContactPersonDetails([FromBody] GnmContactPersonDetails ContactDetail)
        {
            try
            {
                using (CoreDbContext ContactEntities = new CoreDbContext())
                {
                    ContactEntities.GnmContactPersonDetails.Add(ContactDetail);
                    ContactEntities.SaveChanges();
                    return "Contact Person Details submitted successfully!";
                }
            }
            catch (Exception ex)
            {
                return "Unable To Save";
                Newlog.Error("Unable To Save");
            }
        }


        [Route("api/[controller]")]
        [HttpGet]
        public GnmContactPersonDetails GetDataBasedOnDate(DateTime InputDate)
        {
            try
            {
                using (CoreDbContext ContactEntities = new CoreDbContext())
                {
                    return ContactEntities.GnmContactPersonDetails.FirstOrDefault(e => e.EntryDateTime == InputDate);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                Newlog.Error("Unable To Fetch Details");
            }
        }
    }
}
