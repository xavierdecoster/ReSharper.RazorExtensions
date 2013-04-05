using System;
using JetBrains.Application;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Intentions.Extensibility;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Html.Impl.Tree;
using JetBrains.ReSharper.Psi.Razor.Parsing;
using JetBrains.TextControl;

namespace ReSharper.RazorExtensions.QuickFixes
{
    public class RemoveRedundantSemicolonBulbItem : BulbActionBase
    {
        private readonly HtmlToken<IRazorTokenNodeTypes> _htmlToken;

        public RemoveRedundantSemicolonBulbItem(HtmlToken<IRazorTokenNodeTypes> htmlToken)
        {
            _htmlToken = htmlToken;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            WriteLockCookie.Execute(() => ModificationUtil.DeleteChild(_htmlToken));
            return null;
        }

        public override string Text
        {
            get { return "Remove redundant semicolon"; }
        }
    }
}