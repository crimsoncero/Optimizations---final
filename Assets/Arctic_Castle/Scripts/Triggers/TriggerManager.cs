using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public BarrelManager barrelManager;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "FpsController")
        {
            return;
        }

        Debug.Log(string.Format("Something is inside the trigger: {0}", other.gameObject.name));

        Debug.Log("Object Tag: " + other.gameObject.tag);

        if (barrelManager != null && !barrelManager.enabled)
        {
            barrelManager.enabled = true;
        }
    }
}
