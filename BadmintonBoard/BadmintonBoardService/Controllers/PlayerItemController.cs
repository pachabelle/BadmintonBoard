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
    public class PlayerController : TableController<PlayerItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            BadmintonBoardContext context = new BadmintonBoardContext();
            DomainManager = new EntityDomainManager<PlayerItem>(context, Request);
        }

        // GET tables/Player
        public IQueryable<PlayerItem> GetAllPlayerItems()
        {
            return Query();
        }

        // GET tables/Player/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PlayerItem> GetPlayerItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Player/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PlayerItem> PatchPlayerItem(string id, Delta<PlayerItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/Player
        public async Task<IHttpActionResult> PostPlayerItem(PlayerItem item)
        {
            PlayerItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Player/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePlayerItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}