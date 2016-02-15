namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System.Web.Mvc;
    using Base;
    using Data.Models;
    using Models.Messages;
    using Services.Data.Contracts;

    [Authorize]
    public class MessageController : BaseController
    {
        private IMessageService messageService;

        public MessageController(IUserService userService, IMessageService messageService)
            :base(userService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public ActionResult Send(MessageSaveViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageSaveViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var newMessage = AutoMapper.Mapper.Map<Message>(model);

                newMessage.FromUserId = this.CurrentUser.Id;

                var result = this.messageService.AddMessage(newMessage);

                return this.RedirectToAction("Index", "User", new { area = "Private"});
            }

            return this.View(model);
        }
    }
}