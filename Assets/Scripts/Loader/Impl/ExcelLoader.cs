using System;
using System.Collections.Generic;
using System.IO;
using CNS.Enum;
using CNS.Installer;
using CNS.Manager;
using Dialogs;
using Entities;
using OfficeOpenXml;
using UnityEngine;
using Zenject;

namespace Loader.Impl
{
    [Bind(Scope.AsSingle)]
    public class ExcelLoader : IExcelLoader
    {
        [Inject]
        private readonly IEntityManager entityManager;
        private string FilePath = Path.Combine(Application.dataPath, "../dialogs.xlsx");
        
        public Dictionary<int, Dialog> LoadDialoguesFromExcel(string lang)
        {
            Dictionary<int, Dialog> dialogues = new ();
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using var package = new ExcelPackage(new FileInfo(FilePath));
            
            var worksheet = package.Workbook.Worksheets[$"Dialog_{lang}"];
            
            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var id = int.Parse(worksheet.Cells[row, 1].Text);
                if (!dialogues.ContainsKey(id))
                {
                    dialogues.Add(id, new Dialog());
                    var npcName = worksheet.Cells[row, 4].Text;
                    var marker = ConvertStringToEnum<Marker>(npcName);
                    if (marker != null)
                    {
                        dialogues[id].Npc = (Npc) entityManager.GetEntity(marker.Value); 
                    }
                    
                }    
                
                var textNpc = new TextNpc();
                textNpc.Text = worksheet.Cells[row, 2].Text;
                textNpc.Relationship = worksheet.Cells[row, 3].Text; ;
                dialogues[id].TextNpcs.Add(textNpc);
            }

            var worksheetAnswer = package.Workbook.Worksheets[$"Answer_{lang}"];
            
            for (var row = 2; row <= worksheetAnswer.Dimension.End.Row; row++)
            {
                var id = int.Parse(worksheetAnswer.Cells[row, 2].Text);
                
                var textPlayer = new TextPlayer();
                textPlayer.Text = worksheetAnswer.Cells[row, 1].Text;
                var dialogAction = 
                    ConvertStringToEnum<DialogTriggerAction>(worksheetAnswer.Cells[row, 3].Text);
                if (dialogAction != null)textPlayer.Action = dialogAction.Value;
                
                dialogues[id].TextPlayers.Add(textPlayer);
            }

            return dialogues;
        }

        public Dictionary<int, string> LoadDescriptionsFromExcel(string lang)
        {
            Dictionary<int, string> descriptions = new ();
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using var package = new ExcelPackage(new FileInfo(FilePath));
            
            var worksheet = package.Workbook.Worksheets[$"Quest_description_{lang}"];

            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var id = int.Parse(worksheet.Cells[row, 1].Text);
                var description = worksheet.Cells[row, 2].Text;
                descriptions.Add(id, description);
            }
            return descriptions;
        }

        private T? ConvertStringToEnum<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, true, out T result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}