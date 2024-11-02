using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazerTest.Helper
{
    public class PageFinder
    {
        public static List<string> GetAllBlazorPages()
        {
            var assembly = Assembly.GetExecutingAssembly();

            // فیلتر کردن تمام کلاس‌هایی که از ComponentBase ارث برده و RouteAttribute دارند
            var pageTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ComponentBase))
                            && !t.IsAbstract
                            && t.GetCustomAttributes(typeof(RouteAttribute), false).Any())
                .Select(t => new
                {
                    Name = t.Name,
                    Route = ((RouteAttribute)t.GetCustomAttributes(typeof(RouteAttribute), false).First()).Template
                })
                .Where(t => t.Route.StartsWith("/")) // فقط صفحاتی که مسیر دارند
                .Select(t => t.Name)
                .ToList();

            return pageTypes;
        }
    }
}
