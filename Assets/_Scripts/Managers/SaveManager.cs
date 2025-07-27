using UnityEngine;


public static class SaveManager 
{

    public static void Save(int score)
    {
        GameData data = new GameData(score);
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("data",json);
      
    }

    public static GameData Load()
    {
        string json = PlayerPrefs.GetString("data",JsonUtility.ToJson(new GameData(0)));
       
        return JsonUtility.FromJson<GameData>(json);
    }
}

public class GameData
{
    public int bestScore;

    public GameData( int bestScore)
    {
        this.bestScore = bestScore;
    }
}