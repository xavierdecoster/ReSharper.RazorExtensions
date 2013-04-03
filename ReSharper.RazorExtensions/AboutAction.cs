using System.Windows.Forms;
using JetBrains.ActionManagement;
using JetBrains.Application.DataContext;

namespace ReSharper.RazorExtensions
{
  [ActionHandler("ReSharper.RazorExtensions.About")]
  public class AboutAction : IActionHandler
  {
    public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      // return true or false to enable/disable this action
      return true;
    }

    public void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      MessageBox.Show(
        "ReSharper.RazorExtensions\nXavier Decoster\n\nA ReSharper plug-in for semicolon-free HTML in Razor views.",
        "About ReSharper.RazorExtensions",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
    }
  }
}
