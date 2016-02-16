namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Base;
    using Models.Messages;
    using Models.Users;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    [Authorize]
    public class UserController : BaseController
    {
        private IMessageService messageService;
        private ICacheService cacheService;

        public UserController(IUserService userService, IMessageService messageService, ICacheService cacheService)
            : base(userService)
        {
            this.messageService = messageService;
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserProfilePartial()
        {
            var userName = this.CurrentUser.UserName;

            var userData =
                this.cacheService.Get(
                    userName,
                    () => this.usersService
                        .UserById(this.CurrentUser.Id)
                        .ProjectTo<UserViewModel>()
                        .FirstOrDefault(),
                    5 * 60);

            return this.PartialView("_UserProfilePartial", userData);
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

        [Authorize]
        public ActionResult Update(int id)
        {
            this.messageService.MarkAsRead(id);

            return this.GetInboxMessagesPartial();
        }
    }
}