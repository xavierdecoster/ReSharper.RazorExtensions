using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.Util;

namespace ReSharper.RazorExtensions.QuickFixes
{
    [QuickFix]
    public partial class RemoveRedundantSemicolonQuickFix : IQuickFix
    {
        private readonly UseOfSemicolonLiteralInRazorSyntaxHighlighting _highlighting;

        public RemoveRedundantSemicolonQuickFix(UseOfSemicolonLiteralInRazorSyntaxHighlighting highlighting)
        {
            _highlighting = highlighting;
        }

        public bool IsAvailable(IUserDataHolder cache)
        {
            return _highlighting.IsValid();
        }
    }
}