using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    public delegate void OnClickHandler(int coinValue);
    public static event OnClickHandler Click;

    void OnClick()
    {
        Click(value);
    }

    private void OnMouseDown()
    {
        OnClick();
        Destroy(gameObject);
    }
}