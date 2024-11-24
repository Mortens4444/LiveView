using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class UserAndGroupManagement : Form, IUserAndGroupManagementView
    {
        private readonly ILogger<UserAndGroupManagement> logger;

        public UserAndGroupManagement(ILogger<UserAndGroupManagement> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
