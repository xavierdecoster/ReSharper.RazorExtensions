using JetBrains.Application.Settings;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Razor.CSharp;
using JetBrains.ReSharper.Psi.Tree;
using System.Collections.Generic;
using System.Linq;

namespace ReSharper.RazorExtensions
{
    [DaemonStage(StagesBefore = new[] { typeof(LanguageSpecificDaemonStage) })]
    public class UseOfSemicolonLiteralInRazorSyntaxDaemonStage : IDaemonStage
    {
        public IEnumerable<IDaemonStageProcess> CreateProcess(IDaemonProcess process, IContextBoundSettingsStore settings, DaemonProcessKind processKind)
        {
            IFile psiFile = process.SourceFile.GetTheOnlyPsiFile(RazorCSharpLanguage.Instance);
            if (psiFile == null)
                return Enumerable.Empty<IDaemonStageProcess>();

            return new[] { new UseOfSemicolonLiteralInRazorSyntaxDaemonProcess(process) };
        }

        public ErrorStripeRequest NeedsErrorStripe(IPsiSourceFile sourceFile, IContextBoundSettingsStore settingsStore)
        {
            return ErrorStripeRequest.STRIPE_AND_ERRORS;
        }
    }
}