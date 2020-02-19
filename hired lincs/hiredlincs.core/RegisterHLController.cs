using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace hiredlincs.core
{
    class RegisterHLController : SurfaceController
    {
        public ActionResult RegisterHL(RegisterHLModel model)
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

            member.SetValue("userProfileBio", model.Biography);

            memberService.SavePassword(member, model.Password);
            Members.Login(model.Email, model.Password);

            memberService.Save(member);

            return Redirect("/");
        }
    }
}