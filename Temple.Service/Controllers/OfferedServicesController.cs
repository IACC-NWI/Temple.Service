using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Temple.Service.Database;
using Temple.Service.Database.Model;
using Temple.Service.Models;

namespace Temple.Service.Controllers
{
    [RoutePrefix("api/offeredservices")]
    public class OfferedServicesController: ApiController
    {
        private readonly ITempleDbContext _dbContext;

        public OfferedServicesController(ITempleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("addnewfestival")]
        public async Task<IHttpActionResult> AddNewFestival(FestivalModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Festivals.Add(new Festival
            {
                Description = model.Description,
                FestivalId = model.FestivalId,
                Name = model.Name
            });
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }
        [HttpPost]
        [Route("updatefestival")]
        public async Task<IHttpActionResult> UpdateFestival(FestivalModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var modelToUpdate = await _dbContext.Festivals.FirstAsync(t => t.FestivalId == model.FestivalId);
            modelToUpdate.FestivalId = model.FestivalId;
            modelToUpdate.Description = model.Description;
            modelToUpdate.Name = model.Name;
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet]
        [Route("getallfestivals")]
        public async Task<IHttpActionResult> GetAllFestivals()
        {
            var festivals = await _dbContext.Festivals.ToListAsync();
            return Ok(festivals.Select(t => new FestivalModel
            {
                FestivalId = t.FestivalId,
                Name = t.Name,
                Description = t.Description
            }).ToList());
        }
        [HttpPost]
        [Route("addnewservice")]
        public async Task<IHttpActionResult> AddNewService(OfferedServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.OfferedServices.Add(new OfferedService
            {
                FestivalId = model.FestivalId,
                Description = model.Description,
                Name = model.Name,
                FestivalName = model.FestivalName,
                ServiceId = model.ServiceId,
                SuggestedDonation = model.SuggestedDonation
            });
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPost]
        [Route("updateservice")]
        public async Task<IHttpActionResult> UpdateService(OfferedServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = await _dbContext.OfferedServices.FirstAsync(t => t.ServiceId == model.ServiceId);
            service.FestivalId = model.FestivalId;
            service.ServiceId = model.ServiceId;
            service.Description = model.Description;
            service.FestivalName = model.FestivalName;
            service.Name = model.Name;
            service.SuggestedDonation = model.SuggestedDonation;
            await _dbContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpGet]
        [Route("getallservices")]
        public async Task<IHttpActionResult> GetAllServices()
        {
            var services = await _dbContext.OfferedServices.ToListAsync();
            return Ok(services.Select(t => new OfferedServiceModel
            {
                FestivalId = t.FestivalId,
                ServiceId = t.ServiceId,
                Name = t.Name,
                Description = t.Description,
                FestivalName = t.FestivalName,
                SuggestedDonation = t.SuggestedDonation
            }).ToList());
        }

        [HttpPost]
        [Route("purchaseoffering")]
        public async Task<IHttpActionResult> PurchaseOffering(PurchaseOfferingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var state = model.State.ToUpper();
            var fName = model.FirstName.Trim();
            var lName = model.LastName.Trim();
            var donorId = Guid.NewGuid();
            var donor = _dbContext.Donors.FirstOrDefault(t => t.FirstName == fName && t.LastName == lName);
            if (donor == null)
            {
                _dbContext.Donors.Add(new Donor
                {
                    Email = model.Email,
                    FirstName = fName,
                    LastName = lName,
                    DonorId = donorId
                });
            }
            else
            {
                donorId = donor.DonorId;
            }
            _dbContext.Purchases.Add(new Purchase
            {
                FestivalId = model.FestivalId,
                DonorId =  donorId,
                SuggestedDonation = model.SuggestedDonation,
                FestivalName = model.FestivalName,
                ActualDonation = model.ActualDonation,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MemberId = model.MemberId,
                OfferedServiceId = model.OfferedServiceId,
                OfferedServiceName = model.OfferedServiceName,
                PurchaseId = model.PurchaseId,
                ServiceDate = model.ServiceDate,
                State = state,
                Zip = model.Zip
            });
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return Ok(model);
        }

        [HttpGet]
        [Route("getallpurchases")]
        public async Task<IHttpActionResult> GetAllOfferingPurchases()
        {
            var purchases = await _dbContext.Purchases.ToListAsync();
            return Ok(purchases.Select(t => new PurchaseOfferingModel
            {
                FestivalId = t.FestivalId,
                SuggestedDonation = t.SuggestedDonation,
                FestivalName = t.FestivalName,
                AddressLine2 = t.AddressLine2,
                State = t.State,
                MemberId = t.MemberId,
                ActualDonation = t.ActualDonation,
                PurchaseId = t.PurchaseId,
                ServiceDate = t.ServiceDate,
                OfferedServiceId = t.OfferedServiceId,
                FirstName = t.FirstName,
                LastName = t.LastName,
                City = t.City,
                Email = t.Email,
                OfferedServiceName = t.OfferedServiceName,
                AddressLine1 = t.AddressLine1,
                Zip = t.Zip
            }).ToList());
        }

        
    }
}
