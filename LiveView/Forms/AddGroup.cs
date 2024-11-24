using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddGroup : Form, IAddGroupView
    {
        private readonly ILogger<AddGroup> logger;

        public AddGroup(ILogger<AddGroup> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
