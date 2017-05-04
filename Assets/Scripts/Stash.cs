using UnityEngine;
using UnityEngine.UI;

public class Stash : MonoBehaviour
{
    public static int coin;
    public Text textCoin;
    public int startingCoin;

    public void IncreaseAmount(int amount)
    {
        coin += amount;
    }

    public void DecreaseAmount(int amount)
    {
        coin -= amount;
    }

    private void OnEnable()
    {
        Coin.Click += IncreaseAmount;
        TowerSetup.BuyTower += DecreaseAmount;
    }

    private void OnDisable()
    {
        Coin.Click -= IncreaseAmount;
        TowerSetup.BuyTower -= DecreaseAmount;
    }

    private void Start()
    {
        coin = startingCoin;
    }

    private void Update()
    {
        textCoin.text = coin.ToString();
    }
}