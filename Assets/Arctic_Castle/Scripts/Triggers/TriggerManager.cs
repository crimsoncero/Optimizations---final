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
        if (barrelManager != null && !barrelManager.enabled)
        {
            barrelManager.enabled = true;
        }
    }
}
