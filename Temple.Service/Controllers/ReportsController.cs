using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Temple.Service.Database;
using Temple.Service.Models;

namespace Temple.Service.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        private readonly ITempleDbContext _dbContext;

        public ReportsController(ITempleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("getalldonors")]
        public async Task<IHttpActionResult> GetAllDonors()
        {
            var servicesGroupedByDonors = await _dbContext.Purchases.GroupBy(t => t.DonorId)
                    .ToListAsync();

            return Ok(servicesGroupedByDonors
                    .Select(q => new DonorModel
                    {
                        FirstName = q.First().FirstName,
                        LastName = q.First().LastName,
                        Email = q.First().Email,
                        MemberId = q.First().MemberId,
                        DonorId = q.Key,
                        TotalDonation = q.Sum(t => t.ActualDonation)
                    }).ToList());
        }

        [HttpGet]
        [Route("getalldonations/{startday}/{endday}")]
        public async Task<IHttpActionResult> GetAllDonations(DateTime startday, DateTime endday)
        {
            var services =
                await _dbContext.Purchases
                      .Where(t => t.ServiceDate >= startday && t.ServiceDate <= endday)
                      .ToListAsync();
            return Ok(services.Select(q => new DonorModel
            {
                LastName = q.LastName,
                FirstName = q.FirstName,
                Email = q.Email,
                MemberId = q.MemberId,
                DonorId = q.DonorId,
                TotalDonation = q.ActualDonation
            }).ToList());
        }

        [HttpGet]
        [Route("getallserviesperformed")]
        public async Task<IHttpActionResult> GetAllPerformedServices()
        {
            var services = await _dbContext.Purchases.GroupBy(t=>t.OfferedServiceId).ToListAsync();
            return Ok(services.Select(q => new PerformedServiceReportModel
            {
                Name = q.First().OfferedServiceName,
                Count = q.Count(),
                ServiceId = q.Key,
                TotalDonations = q.Sum(t => t.ActualDonation)
            }).ToList());
        }

        [HttpGet]
        [Route("getallservicesperformed/{startdate}/{enddate}")]
        public async Task<IHttpActionResult> GetAllServicesPerformedInARange(DateTime startdate, DateTime enddate)
        {
            var services =
                await
                    _dbContext.Purchases.Where(t => t.ServiceDate >= startdate && t.ServiceDate <= enddate)
                        .GroupBy(t => t.OfferedServiceId)
                        .ToListAsync();
            return Ok(services.Select(q => new PerformedServiceReportModel
            {
                Name = q.First().OfferedServiceName,
                Count = q.Count(),
                ServiceId = q.Key,
                TotalDonations = q.Sum(t => t.ActualDonation)
            }).ToList());
        }
    }
}
