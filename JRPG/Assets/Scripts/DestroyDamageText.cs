using UnityEngine;

public class DestroyDamageText : MonoBehaviour {

    private float destroyTime = 1.5f;

    void Start () 
    {
        Destroy(gameObject, destroyTime);
    }
	
    void OnDestroy()
    {
        GameObject turnSystem = GameObject.Find("TurnSystem");
        turnSystem.GetComponent<TurnSystem>().NextTurn();
    }
}