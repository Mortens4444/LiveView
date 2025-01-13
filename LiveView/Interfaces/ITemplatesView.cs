using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ITemplatesView : IView
    {
        TextBox TbTemplateName { get; }

        ListView LvTemplates { get; }
    }
}
