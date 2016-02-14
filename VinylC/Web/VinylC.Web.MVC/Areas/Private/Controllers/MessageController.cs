namespace VinylC.Web.MVC.Areas.Private.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Base;
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
    }
}