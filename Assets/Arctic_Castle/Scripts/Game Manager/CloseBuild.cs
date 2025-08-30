using UnityEngine;

public class CloseBuild : MonoBehaviour
{
    public static CloseBuild Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static void QuitGame()
    {
        Debug.Log("quit pressed");
        Application.Quit();
    }
}
