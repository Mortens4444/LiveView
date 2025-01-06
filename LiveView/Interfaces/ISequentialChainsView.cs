using Database.Models;
using System.Windows.Forms;

namespace LiveView.Interfaces
{
    public interface ISequentialChainsView : IView
    {
        ComboBox CbGrids { get; }

        ComboBox CbSequences { get; }

        ListView LvGrids { get; }

        TextBox TbSequenceName { get; }

        GridInSequence GetGridInSequence();

        Database.Models.Sequence GetSequence();
    }
}
