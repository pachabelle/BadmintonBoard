using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using BadmintonBoardService.DataObjects;
using BadmintonBoardService.Models;
using Microsoft.Azure.Mobile.Server;

namespace BadmintonBoardService.Controllers
{
    [Authorize]
    public class VenueController : TableController<VenueItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BadmintonBoardContext context = new BadmintonBoardContext();
            DomainManager = new EntityDomainManager<VenueItem>(context, Request);
        }

        // GET tables/Venue
        public IQueryable<VenueItem> GetAllVenueItems()
        {
            return Query();
        }

        // GET tables/Venue/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<VenueItem> GetVenueItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Venue/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<VenueItem> PatchVenueItem(string id, Delta<VenueItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Venue
        public async Task<IHttpActionResult> PostVenueItem(VenueItem item)
        {
            VenueItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Venue/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteVenueItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}