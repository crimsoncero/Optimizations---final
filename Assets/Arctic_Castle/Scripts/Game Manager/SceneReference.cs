using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class SceneReference
{
#if UNITY_EDITOR
    [SerializeField] private SceneAsset sceneAsset; // drag in Inspector
#endif
    [SerializeField] private int buildIndex = -1;   // stored for runtime

    public bool IsValid => buildIndex >= 0;
    public int BuildIndex => buildIndex;

#if UNITY_EDITOR
    public void OnValidate()
    {
#if UNITY_EDITOR
        if (sceneAsset != null)
        {
            string path = AssetDatabase.GetAssetPath(sceneAsset);
            buildIndex = SceneUtility.GetBuildIndexByScenePath(path);

            if (buildIndex < 0)
                Debug.LogError($"SceneReference: '{sceneAsset.name}' is not in Build Settings!");
        }
        else
        {
            buildIndex = -1;
        }
#endif
    }
#endif
}
