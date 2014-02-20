using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Intentions.Extensibility.Menu;
using System.Collections.Generic;

namespace ReSharper.RazorExtensions.QuickFixes
{
    public partial class RemoveRedundantSemicolonQuickFix
    {
        public IEnumerable<IntentionAction> CreateBulbItems()
        {
            var bulbItem = new RemoveRedundantSemicolonBulbItem(_highlighting.HtmlToken);
            return new List<BulbActionBase> {bulbItem}.ToContextAction();
        }
    }
}