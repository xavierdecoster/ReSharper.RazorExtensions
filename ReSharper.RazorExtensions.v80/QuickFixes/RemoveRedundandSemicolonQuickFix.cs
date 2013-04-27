using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Intentions.Extensibility.Menu;
using JetBrains.Util;
using System.Collections.Generic;

namespace ReSharper.RazorExtensions.QuickFixes
{
    [QuickFix]
    public class RemoveRedundantSemicolonQuickFix : IQuickFix
    {
        private readonly UseOfSemicolonLiteralInRazorSyntaxHighlighting _highlighting;

        public RemoveRedundantSemicolonQuickFix(UseOfSemicolonLiteralInRazorSyntaxHighlighting highlighting)
        {
            _highlighting = highlighting;
        }

        public IEnumerable<IntentionAction> CreateBulbItems()
        {
            var bulbItem = new RemoveRedundantSemicolonBulbItem(_highlighting.HtmlToken);
            return new List<BulbActionBase> {bulbItem}.ToContextAction();
        }

        public bool IsAvailable(IUserDataHolder cache)
        {
            return _highlighting.IsValid();
        }
    }
}