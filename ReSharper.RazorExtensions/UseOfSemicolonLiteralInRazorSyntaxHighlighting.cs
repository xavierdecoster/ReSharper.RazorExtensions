using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Psi.Html.Impl.Tree;
using JetBrains.ReSharper.Psi.Razor.CSharp.Mvc;
using JetBrains.ReSharper.Psi.Razor.Parsing;
using ReSharper.RazorExtensions;

[assembly: RegisterConfigurableSeverity(UseOfSemicolonLiteralInRazorSyntaxHighlighting.SeverityId,
  null,
  HighlightingGroupIds.CodeSmell,
  "Suspicious usage of semicolons found in Razor syntax.",
  "Use of literal semicolon in Razor views can cause undesired rendering of semicolon in HTML pages.",
  Severity.WARNING,
  false)]

namespace ReSharper.RazorExtensions
{
  [ConfigurableSeverityHighlighting(SeverityId, RazorCSharpMvcLanguage.Name, OverlapResolve = OverlapResolveKind.WARNING)]
  public class UseOfSemicolonLiteralInRazorSyntaxHighlighting : IHighlighting
  {
    private readonly HtmlToken<IRazorTokenNodeTypes> _htmlToken;

    public const string SeverityId = "UseOfSemicolonLiteralInRazorSyntax";

    public UseOfSemicolonLiteralInRazorSyntaxHighlighting(HtmlToken<IRazorTokenNodeTypes> htmlToken)
    {
      _htmlToken = htmlToken;
    }

    public HtmlToken<IRazorTokenNodeTypes> HtmlToken
    {
        get { return _htmlToken; }
    }

    public string ToolTip
    {
      get { return "Use of literal semicolon in Razor views can cause undesired rendering of semicolon in HTML pages."; }
    }

    public string ErrorStripeToolTip
    {
      get { return "Suspicious usage of semicolons found in Razor syntax."; }
    }

    public int NavigationOffsetPatch
    {
      get { return 0; }
    }

    public bool IsValid()
    {
      return _htmlToken != null && _htmlToken.IsValid();
    }
  }
}