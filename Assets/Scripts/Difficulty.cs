using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public string oreDiff = "Standard";
    public string landDiff = "Standard";
    public string wallDiff = "Standard";
    private static Difficulty difficulty;
    public static Difficulty GetDifficulty()
    {
        if(difficulty != null)
        {
            return difficulty;
        }
        GameObject obj = new GameObject("Difficulty");  
        difficulty = obj.AddComponent<Difficulty>();
        return difficulty;
    }
}
