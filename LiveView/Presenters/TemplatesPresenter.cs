using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class TemplatesPresenter : BasePresenter
    {
        private ITemplatesView view;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateProcessRepository templateProcessRepository;
        private readonly ILogger<Templates> logger;

        public TemplatesPresenter(TemplatesPresenterDependencies templatesPresenterDependencies)
            : base(templatesPresenterDependencies)
        {
            templateProcessRepository = templatesPresenterDependencies.TemplateProcessRepository;
            templateRepository = templatesPresenterDependencies.TemplateRepository;
            logger = templatesPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ITemplatesView;
        }

        public void Delete()
        {
            var itemsToDelete = new List<ListViewItem>();
            foreach (ListViewItem selectedItem in view.LvTemplates.SelectedItems)
            {
                if (selectedItem.Tag is Template template)
                {
                    templateRepository.Delete(template.Id);
                    itemsToDelete.Add(selectedItem);
                }
            }
            foreach (var item in itemsToDelete)
            {
                view.LvTemplates.Items.Remove(item);
            }
        }

        public void Save()
        {
            var templateId = templateRepository.InsertAndReturnId<long>(new Template
            {
                TemplateName = view.TbTemplateName.Text
            });
            SaveProcesses(templateId, Process.GetProcessesByName("Sequence"));
            SaveProcesses(templateId, Process.GetProcessesByName("Camera"));
            logger.LogInfo($"Template '{0}' has been saved.", view.TbTemplateName.Text);
            Load();
        }

        private void SaveProcesses(long templateId, Process[] processes)
        {
            foreach (var process in processes)
            {
                using (var searcher = new ManagementObjectSearcher($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        var commandLine = obj["CommandLine"]?.ToString() ?? String.Empty;
                        var processNameWithExtension = $"{process.ProcessName}.exe";
                        var parameters = commandLine.Replace($"\"{process.MainModule.FileName}\"", String.Empty).Trim();

                        templateProcessRepository.Insert(new TemplateProcess
                        {
                            TemplateId = templateId,
                            ProcessName = processNameWithExtension,
                            ProcessParameters = parameters
                        });
                    }
                }
            }
        }

        public override void Load()
        {
            view.LvTemplates.AddItems(templateRepository.SelectAll(), template => new ListViewItem(template.TemplateName) { Tag = template });
        }
    }
}
