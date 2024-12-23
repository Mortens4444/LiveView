using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Services
{
    public class FormFactory
    {
        private readonly IServiceProvider serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T CreateForm<T>(params object[] parameters) where T : Form
        {
            return (T)ActivatorUtilities.CreateInstance(serviceProvider, typeof(T), parameters);
        }
    }
}
