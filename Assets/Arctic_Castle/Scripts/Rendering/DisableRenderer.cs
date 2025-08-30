using UnityEngine;

public class DisableRenderer : MonoBehaviour
{
    [SerializeField] private Renderer objectRenderer;

    void Start()
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = false;
        }
        else
        {
            Debug.LogWarning("Renderer component is not assigned in the Inspector.");
        }
    }
}
