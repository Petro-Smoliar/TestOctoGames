using CNS.Enum;
using UnityEngine;

namespace CNS.Manager.Impl
{
    public static class SettingsManager
    {
        public static global::System.Action ActionMinigame { get; set; }
        public static void SaveLanguage(string language)
        {
            PlayerPrefs.SetString("SelectedLanguage", language);
            PlayerPrefs.Save();
        }

        public static void SaveNpcRelationship(Marker marker, string relationship)
        {
            PlayerPrefs.SetString(marker.ToString(), relationship);
            PlayerPrefs.Save();
        }
        
        public static string LoadLanguage()
        {
            return PlayerPrefs.GetString("SelectedLanguage", "en");
        }

        public static string LoadNpcRelationship(Enum.Marker marker)
        {
            return PlayerPrefs.GetString(marker.ToString(), "normal");
        }
    }
}