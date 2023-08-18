using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
   public static GameManager instance;
   public string currentUsername;
   public string bestUsername;
   public int bestScore;

   private void Awake () {
      if (instance == null) {
         instance = this;
         DontDestroyOnLoad(gameObject);
         LoadBestUser();
      } else {
         Destroy(gameObject);
      }
   }

   [Serializable] class BestScore {
      public string name;
      public int score;
   }


   public void SaveBestSocre () {
      BestScore data = new BestScore();
      data.name = bestUsername = currentUsername;
      data.score = bestScore;

      string json = JsonUtility.ToJson(data);
      File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
   }
   public void LoadBestUser () {
      string path = Application.persistentDataPath + "/bestScore.json";
      if (File.Exists(path)) {
         string json = File.ReadAllText(path);
         BestScore data = JsonUtility.FromJson<BestScore>(json);

         bestUsername = data.name;
         bestScore = data.score;
      }
   }
}
