using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Queeries.DestinationQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class DestinationCQRSController : Controller
    { 
        private readonly GetAllDestinationQueryHandler _queryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQuery;
        public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationByIdQueryHandler getDestinationByIdQuery)
        {
            _queryHandler = queryHandler;
            _getDestinationByIdQuery = getDestinationByIdQuery;
        }

        public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        } 
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIdQuery.Handle(new GetDestinationByIdQuery(id)); 
            return View(values);

        }
    }
}
