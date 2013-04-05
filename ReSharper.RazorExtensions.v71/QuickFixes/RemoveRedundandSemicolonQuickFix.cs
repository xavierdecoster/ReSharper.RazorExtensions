using System;
using System.Diagnostics;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Intentions.Extensibility.Menu;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Util;
using JetBrains.ReSharper.Psi.ExtensionsAPI;
using JetBrains.ReSharper.Psi.Razor.CSharp.Utils;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.Util;
using JetBrains.Util;

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

        public void CreateBulbItems(BulbMenu menu, Severity severity)
        {
            menu.ArrangeQuickFix(new RemoveRedundantSemicolonBulbItem(_highlighting.HtmlToken), Severity.WARNING);
        }

        public bool IsAvailable(IUserDataHolder cache)
        {
            return _highlighting.IsValid();
        }
    }
}