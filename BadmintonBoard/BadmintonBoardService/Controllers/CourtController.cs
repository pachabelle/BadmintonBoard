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
    public class CourtController : TableController<CourtItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BadmintonBoardContext context = new BadmintonBoardContext();
            DomainManager = new EntityDomainManager<CourtItem>(context, Request);
        }

        // GET tables/Court
        public IQueryable<CourtItem> GetAllCourtItems()
        {
            return Query();
        }

        // GET tables/Court/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<CourtItem> GetCourtItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Court/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<CourtItem> PatchCourtItem(string id, Delta<CourtItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Court
        public async Task<IHttpActionResult> PostCourtItem(CourtItem item)
        {
            CourtItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Court/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCourtItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}