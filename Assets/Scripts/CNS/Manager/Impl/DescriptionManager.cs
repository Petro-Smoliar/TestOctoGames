using System.Collections.Generic;
using CNS.Installer;
using Loader;
using Zenject;

namespace CNS.Manager.Impl
{
    [Bind(Scope.AsSingle)]
    public class DescriptionManager : IDescriptionManager
    {
        private Dictionary<int, string> descriptions;
        [Inject]
        private readonly IExcelLoader excelLoader;
        
        public void LoadDescription()
        {
            var language = SettingsManager.LoadLanguage();
            descriptions = excelLoader.LoadDescriptionsFromExcel(language);
        }

        public string GetDescription(int? id)
        {
            return id == null ? null : descriptions[id.Value];
        }
    }
}