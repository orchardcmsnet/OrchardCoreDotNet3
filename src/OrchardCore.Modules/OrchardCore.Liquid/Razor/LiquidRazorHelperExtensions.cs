using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Fluid;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore;
using OrchardCore.Liquid;

public static class LiquidRazorHelperExtensions
{
    /// <summary>
    /// Parses a liquid string to HTML.
    /// </summary>
    /// <param name="liquid"></param>
    /// <returns></returns>
    public static Task<IHtmlContent> LiquidToHtmlAsync(this IOrchardHelper orchardHelper, string liquid)
    {
        return orchardHelper.LiquidToHtmlAsync(liquid, null);
    }

    /// <summary>
    /// Parses a liquid string to HTML.
    /// </summary>
    /// <param name="liquid">The liquid to parse.</param>
    /// <param name="model">A model to bind against.</param>
    /// <summary>
    public static async Task<IHtmlContent> LiquidToHtmlAsync(this IOrchardHelper orchardHelper, string liquid, object model)
    {
        var serviceProvider = orchardHelper.HttpContext.RequestServices;

        var liquidTemplateManager = serviceProvider.GetRequiredService<ILiquidTemplateManager>();
        var htmlEncoder = serviceProvider.GetRequiredService<HtmlEncoder>();

        var context = new TemplateContext();

        if (model != null)
        {
            context.MemberAccessStrategy.Register(model.GetType());
            context.SetValue("Model", model);
        }

        liquid = await liquidTemplateManager.RenderAsync(liquid, htmlEncoder, context);
        return new HtmlString(liquid);
    }
}
