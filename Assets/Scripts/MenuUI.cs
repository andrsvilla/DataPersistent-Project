using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {
   [SerializeField] private TextMeshProUGUI bestScore;
   [SerializeField] private InputField userName;
   private void Start () {
      bestScore.text = "Best Score: ";
      bestScore.text += GameManager.instance.bestUsername;
      bestScore.text += ": ";
      bestScore.text += GameManager.instance.bestScore;
   }
   public void StartGame () {
      if (userName.text.Length > 0) {
         GameManager.instance.currentUsername = userName.text;
         SceneManager.LoadScene(1);
      }
   }
   public void ExitGame () {
#if UNITY_EDITOR
      EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
   }
}
