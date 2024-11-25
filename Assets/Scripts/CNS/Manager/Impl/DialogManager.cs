using System;
using System.Collections.Generic;
using CNS.Enum;
using CNS.Installer;
using Dialogs;
using Loader;
using Zenject;

namespace CNS.Manager.Impl
{
    [Bind(Scope.AsSingle)]
    public class DialogManager : IDialogManager
    {
        private Dictionary<int, Dialog> dialogs;
        private readonly Dictionary<Marker, Dialog> defaultDialogs = new();
        [Inject]
        private readonly IExcelLoader excelLoader;
        
        public void LoadDialogs()
        {
            var lang = SettingsManager.LoadLanguage();
            dialogs = excelLoader.LoadDialoguesFromExcel(lang);
            dialogs.Add(0, new Dialog());
        }

        public void AddDefaultDialog(Marker locationMarker, int id)
        {
            if (dialogs.TryGetValue(id, out var dialog))
            {
                defaultDialogs[locationMarker] = dialog;
            }
            else
            {
                throw new ArgumentException($"Dialog with ID {id} does not exist.", nameof(id));
            }
        }

        public void AddEmptyDefaultDialog(Marker locationMarker)
        {
            defaultDialogs[locationMarker] = new Dialog();
        }

        public Dialog GetDialog(int? id)
        {
            
            return id == null ? null : dialogs[id.Value];
        }

        public Dialog GetDefaultDialog(Marker locationMarker)
        {
            return defaultDialogs[locationMarker];
        }
    }
}