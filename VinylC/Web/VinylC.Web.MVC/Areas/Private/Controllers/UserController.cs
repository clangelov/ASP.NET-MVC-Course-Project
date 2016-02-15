namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Base;
    using Models.Messages;
    using Models.Users;
    using Services.Data.Contracts;

    [Authorize]
    public class UserController : BaseController
    {
        private IMessageService messageService;

        public UserController(IUserService userService, IMessageService messageService)
            :base(userService)
        {
            this.messageService = messageService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        [OutputCache(Duration = 5 * 60)]
        public ActionResult GetUserProfilePartial()
        {
            var model = this.usersService
              .UserById(this.CurrentUser.Id)
              .ProjectTo<UserViewModel>()
              .FirstOrDefault();

            return this.PartialView("_UserProfilePartial", model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetInboxMessagesPartial()
        {
            var model = this.messageService
                .AllToUserId(this.CurrentUser.Id)
                .ProjectTo<MessageViewModel>();

            return this.PartialView("_InboxMessagesPartial", model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOutboxMessagesPartial()
        {
            var model = this.messageService
                .AllFromUserId(this.CurrentUser.Id)
                .ProjectTo<MessageViewModel>();

            return this.PartialView("_OutboxMessagesPartial", model);
        }
    }
}