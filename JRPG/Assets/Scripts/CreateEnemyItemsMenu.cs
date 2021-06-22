using UnityEngine;
using UnityEngine.UI;

public class CreateEnemyItemsMenu : MonoBehaviour
{
    public GameObject targetEnemyUnit;
    public GameObject targetEnemyUnitHp;
    public Sprite menuItem;
    public Vector2 initialPos, itemDimensions;
    public KillEnemy killEnemyScript;

    private GameObject targetEnemyHp;

    private void Update()
    {
        targetEnemyHp.GetComponent<Text>().text = "HP " + gameObject.GetComponent<UnitStats>().health + " / " + gameObject.GetComponent<UnitStats>().maxHealth;
    }

    private void Awake()
    {
        GameObject enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");

        GameObject[] existingItems = GameObject.FindGameObjectsWithTag("TargetEnemyUnit");
        Vector2 nextPos = new Vector2(initialPos.x + existingItems.Length * itemDimensions.x, initialPos.y + 20.0f);

        GameObject targetEnemyUnit = Instantiate(this.targetEnemyUnit, enemyUnitsMenu.transform);
        targetEnemyUnit.name = "Target" + gameObject.name;
        targetEnemyUnit.transform.localPosition = nextPos;
        targetEnemyUnit.transform.localScale = new Vector2(0.7f, 0.7f);
        targetEnemyUnit.GetComponent<Button>().onClick.AddListener(() => SelectEnemyTarget());
        targetEnemyUnit.GetComponent<Image>().sprite = menuItem;

        GameObject targetHp = Instantiate(targetEnemyUnitHp, enemyUnitsMenu.transform);
        targetEnemyHp = targetHp;
        targetHp.name = "Target" + gameObject.name + "Hp";
        targetHp.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 100);
        targetHp.transform.localScale = new Vector2(0.7f, 0.7f);
        targetHp.transform.localPosition = new Vector2(nextPos.x, initialPos.y - 55.0f);
        targetHp.GetComponent<Text>().text = "HP" + gameObject.GetComponent<UnitStats>().health + " / " + gameObject.GetComponent<UnitStats>().maxHealth;

        killEnemyScript.item = targetEnemyUnit;
        killEnemyScript.item2 = targetHp;
    }

    public void SelectEnemyTarget()
    {
        GameObject playerParty = GameObject.Find("PlayerParty");
        playerParty.GetComponent<SelectUnit>().AttackEnemyTarget(gameObject);
    }
}
