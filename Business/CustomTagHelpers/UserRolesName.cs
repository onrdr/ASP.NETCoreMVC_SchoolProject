using Entities.Concrete.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Business.CustomTagHelpers
{
    [HtmlTargetElement("td", Attributes = "user-roles")]
    public class UserRolesName : TagHelper
    {
        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }
        public UserManager<AppUser> UserManager { get; set; }

        public UserRolesName(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await UserManager.FindByIdAsync(UserId);
            var roles = await UserManager.GetRolesAsync(user);

            string html = string.Empty;
            roles.ToList().ForEach(x =>
            {
                html += $" <span class='badge bg-success'> {x} </span>";
            });

            output.Content.SetHtmlContent(html);
        }
    }
}
