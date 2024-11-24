using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class PersonalOptions : Form, IPersonalOptionsView
    {
        private readonly ILogger<PersonalOptions> logger;

        public PersonalOptions(ILogger<PersonalOptions> logger)
        {
            InitializeComponent();
            this.logger = logger;
            Translator.Translate(this);
        }
    }
}
