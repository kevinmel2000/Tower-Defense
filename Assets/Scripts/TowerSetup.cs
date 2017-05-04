using UnityEngine;
using UnityEngine.UI;

public class TowerSetup : MonoBehaviour
{
    public GameObject[] towerType;
    public int towerSelected;
    public GameObject tile;
    public int towerPrice;
    public Text[] priceLabels;

    bool isBuilding;

    public delegate void OnTowerBoughtHandler(int coinValue);

    public static event OnTowerBoughtHandler BuyTower;

    public void SelectTowerToBuild(int indexTower)
    {
        towerSelected = indexTower;
        towerPrice = towerType[towerSelected].GetComponent<Tower>().price;

        if (Stash.coin >= towerPrice) isBuilding = true;
    }

    public void SelectTileToBuild(GameObject tileSelected)
    {
        tile = tileSelected;
    }

    void OnTowerBought(int price)
    {
        BuyTower(price);
    }

    private void OnEnable()
    {
        UIButtonTower.Click += SelectTowerToBuild;
        Tile.Click += SelectTileToBuild;
    }

    private void OnDisable()
    {
        UIButtonTower.Click -= SelectTowerToBuild;
        Tile.Click -= SelectTileToBuild;
    }

    private void Start()
    {
        for(int i=0; i<3; i++)
        {
            priceLabels[i].text = towerType[i].GetComponent<Tower>().price.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isBuilding && (tile.GetComponent<Tile>().isTaken == false))
            {
                tile.GetComponent<Tile>().tower = Instantiate(towerType[towerSelected], tile.transform.position, Quaternion.identity) as GameObject;
                tile.GetComponent<Tile>().isTaken = true;
                
            }
        }
    }
}