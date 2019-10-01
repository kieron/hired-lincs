using System.Web.Mvc;

namespace hiredlincs.core
{
    class RegisterHiredLincsController
    {
        public ActionResult Register(RegisterHiredLincsModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var memberService = Services.MemberService;

            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "A member with that email already exists");
                return CurrentUmbracoPage();
            }

            var member = memberService.CreateMember(model.Email, model.Email, model.Name, "registeredMember");
            memberService.SavePassword(member, model.Password);
            Members.Login(model.Email, model.Password);
            memberService.Save(member);
            return Redirect("/");
        }
    }
}
