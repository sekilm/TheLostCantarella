using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public GameObject item;
    public GameObject item2;

    private void OnDestroy()
    {
        Destroy(item);
        Destroy(item2);
    }
}
