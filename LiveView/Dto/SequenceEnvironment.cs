using LiveView.Core.Dto;
using System.Windows.Forms;

namespace LiveView.Dto
{
    public class SequenceEnvironment
    {
        public DisplayDto Display { get; set; }

        public long SequenceId { get; set; }

        public Button CloseButton { get; set; }
    }
}
