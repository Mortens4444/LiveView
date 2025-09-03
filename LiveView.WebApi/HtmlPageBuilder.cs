using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LiveView.WebApi
{
    public static class HtmlPageBuilder
    {
        public static Task ResourceHtmlPage(HttpContext ctx, string resource)
        {
            ctx.Response.ContentType = "text/html; charset=utf-8";

            return ctx.Response.WriteAsync($@"<!DOCTYPE html>
    <html lang=""hu"">
    <head>
      <meta charset=""UTF-8"">
      <title>LiveView {resource}</title>
      <link rel=""stylesheet"" href=""/styles/Index.css"">
    </head>
    <body>
      <h1>{resource}</h1>
      <ul id=""{resource.ToLower()}List""></ul>
<script>
fetch('/api/{resource.ToLower()}')
    .then(response => response.json())
    .then(data => {{
        const list = document.getElementById('{resource.ToLower()}List');
        data.forEach(x => {{
            const li = document.createElement('li');
            li.innerHTML = x.html + '<hr>';
            list.appendChild(li);
        }});
    }})
    .catch(error => {{
        document.getElementById('{resource.ToLower()}List').innerHTML = '<li>Error occurred during loading {resource.ToLower()} list.</li>';
        console.error('Fetch error:', error);
    }});
</script>
    </body>
    </html>");
        }

        public static Task RootHtmlPage(HttpContext ctx)
        {
            var asm = typeof(Program).Assembly;
            const string controller = nameof(Controller);
            const string ctrlNamespace = "LiveView.WebApi.Controllers";

            var controllers = asm.GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.IsSubclassOf(typeof(ControllerBase)) &&
                    t.Namespace == ctrlNamespace)
                .OrderBy(t => t.Name);

            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html><head>");
            sb.AppendLine("  <meta charset=\"utf-8\" />");
            sb.AppendLine("  <title>LiveView API</title>");
            sb.AppendLine("  <link rel=\"stylesheet\" href=\"/styles/Index.css\">");
            sb.AppendLine("</head><body>");
            sb.AppendLine("  <h1>LiveView API endpoints</h1>");
            sb.AppendLine("  <ul>");

            foreach (var ctrl in controllers)
            {
                var resource = ctrl.Name.EndsWith(controller) ? ctrl.Name[..^controller.Length] : ctrl.Name;
                sb.AppendLine($"    <li><a href=\"{resource}.html\">{resource}</a></li>");
            }

            sb.AppendLine("    <li><a href=\"/api-docs/index.html\">Swagger UI</a> - <a href=\"/openapi/v1.json\">JSON</a></li>");
            sb.AppendLine("  </ul>");
            sb.AppendLine("</body></html>");

            ctx.Response.ContentType = "text/html; charset=utf-8";
            return ctx.Response.WriteAsync(sb.ToString());
        }
    }
}
