using System;
using System.Collections;
using CNS.Manager.Impl;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

namespace Minigame
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;
        [SerializeField]
        private TMP_Text resultText;
        [SerializeField]
        private TMP_InputField inputField;
        [SerializeField] 
        private Button button;
        private string result;
        
        void Start()
        {
            var random = new Random();
            var randomNumber1 = random.Next(1, 10);
            var randomNumber2 = random.Next(1, 10);
            result = (randomNumber1 + randomNumber2).ToString();
            
            text.text = $"{randomNumber1} + {randomNumber2}";
            
            button.onClick.RemoveAllListeners();
            button
                .onClick
                .AddListener(Onclick);
        }

        private void Onclick()
        {
            resultText.text = result.Equals(inputField.text) ? "Super!" : "Wrong!";
            
            StartCoroutine(ActionCoroutine(SettingsManager.ActionMinigame));
        }
        
        private IEnumerator ActionCoroutine(Action action)
        {
            yield return new WaitForSeconds(1f);
            action?.Invoke();
            UnloadScene();
        }

        private void UnloadScene()
        {
            var currentScene = gameObject.scene;
            
            if (currentScene.isLoaded) SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
