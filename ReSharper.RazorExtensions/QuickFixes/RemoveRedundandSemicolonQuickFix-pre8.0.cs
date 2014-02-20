using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Intentions.Extensibility.Menu;

namespace ReSharper.RazorExtensions.QuickFixes
{
    public partial class RemoveRedundantSemicolonQuickFix
    {
        public void CreateBulbItems(BulbMenu menu, Severity severity)
        {
            menu.ArrangeQuickFix(new RemoveRedundantSemicolonBulbItem(_highlighting.HtmlToken), Severity.WARNING);
        }
    }
}