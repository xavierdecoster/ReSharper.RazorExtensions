using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Html.Impl.Tree;
using JetBrains.ReSharper.Psi.Razor.CSharp.Mvc;
using JetBrains.ReSharper.Psi.Razor.Impl.Parsing;
using JetBrains.ReSharper.Psi.Razor.Parsing;
using JetBrains.ReSharper.Psi.Tree;
using System;
using System.Collections.Generic;

namespace ReSharper.RazorExtensions
{
  public class UseOfSemicolonLiteralInRazorSyntaxDaemonProcess : IDaemonStageProcess
  {
    private readonly IDaemonProcess _process;

    public UseOfSemicolonLiteralInRazorSyntaxDaemonProcess(IDaemonProcess process)
    {
      _process = process;
    }

    public void Execute(Action<DaemonStageResult> commiter)
    {
      if (!_process.FullRehighlightingRequired)
        return;

      var highlightings = new List<HighlightingInfo>();

      IFile file = _process.SourceFile.GetNonInjectedPsiFile<RazorCSharpMvcLanguage>();
      if (file == null)
        return;

      file.ProcessChildren<ITreeNode>(
        treeNode =>
        {
          var htmlToken = treeNode as HtmlToken<IRazorTokenNodeTypes>;
          if (htmlToken != null && htmlToken.NodeType.ToString().Equals("TEXT"))
          {
            string text = htmlToken.GetText();
            if (text.Length == 1 && text == ";")
            {
              // lone wolf semicolon detected
              highlightings.Add(new HighlightingInfo(htmlToken.GetDocumentRange(), new UseOfSemicolonLiteralInRazorSyntaxHighlighting(htmlToken)));
            }
          }
        });

      commiter(new DaemonStageResult(highlightings));
    }

    public IDaemonProcess DaemonProcess { get { return _process; } }
  }
}