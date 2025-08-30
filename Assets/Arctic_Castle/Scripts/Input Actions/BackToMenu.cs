using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public static BackToMenu Instance { get; private set; }

    [SerializeField] private SceneReference menuScene; // drag Main Menu scene here
    private PlayerControls controls;

#if UNITY_EDITOR
    private void OnValidate()
    {
        // force refresh of the nested SceneReference
        menuScene?.OnValidate();
    }
#endif

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        controls = new PlayerControls();
        controls.UI.BackToMenu.performed += ctx => LoadMenu();
    }

    private void OnEnable() => controls?.UI.Enable();
    private void OnDisable() => controls?.UI.Disable();

    private void LoadMenu()
    {
        if (menuScene.IsValid)
            SceneManager.LoadScene(menuScene.BuildIndex);
        else
            Debug.LogError("BackToMenu: Scene reference is missing!");
    }
}
