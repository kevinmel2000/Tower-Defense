using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isTaken;
    public GameObject tower;

    public delegate void OnClickHandler(GameObject thisTile);
    public static event OnClickHandler Click;

    private void Update()
    {
        if (isTaken && (tower == null)) isTaken = false;
    }

    public void ChangeStatus()
    {
        isTaken = !isTaken;
    }

    private void OnMouseDown()
    {
        Click(this.gameObject);
    }
}