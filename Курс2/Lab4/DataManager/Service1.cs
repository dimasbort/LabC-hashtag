using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.ServiceProcess;
using ConfigurationManager;
using DataAccessLayer.Repositories;
using DBModels.Entities;
using DirectoryMonitorService;
using ServiceLayer.Services;

namespace DataManager
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            var manager = new ConfigManager();

            var pathOption = manager.GetOption<PathOption>(appPath + "config.xml");
            var logs = manager.GetOption<Logs>(appPath + "config.xml");

            try
            {
                var repositories = new UnitOfWork(pathOption.DBPath1);
                PersonService employeeService = new PersonService(repositories);
                var employeesInfo = employeeService.GetListOfEmployees();

                XmlGenerateService<Persons> persons = new XmlGenerateService<Persons>(pathOption.SourceDirectory + "\\Persons.xml");
                persons.XmlGenerate(employeesInfo);
            }
            catch (Exception trouble)
            {
                using (var writer = new StreamWriter(logs.Log, true))
                {
                    writer.WriteLine(trouble.Message);
                }
            }
        }

        protected override void OnStop()
        {

        }
    }
}
