using UnityEngine;

public class UIButtonTower : MonoBehaviour
{
    public delegate void OnUIButtonClickHandler(int indexTower);
    public static event OnUIButtonClickHandler Click;

    public void OnTowerAttackClick()
    {
        Click(0);
    }

    public void OnTowerDefenderClick()
    {
        Click(1);
    }

    public void OnTowerResourcerClick()
    {
        Click(2);
    }
}