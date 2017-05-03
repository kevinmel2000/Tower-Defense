using UnityEngine;

public class Resourcer : Tower
{
    public float coinCooldown;
    public GameObject itemCoin;

    float indexTimeCooldown;

    void SpawnCoin()
    {
        Vector3 newPos = new Vector3(this.transform.position.x + Random.Range(-1f, 1f), this.transform.position.y + Random.Range(-1f, 1f), -1f);
        GameObject bul = Instantiate(itemCoin, newPos, Quaternion.identity) as GameObject;
    }

    private void Start()
    {
        indexTimeCooldown = coinCooldown;
    }

    private void Update()
    {
        if(indexTimeCooldown <= 0)
        {
            SpawnCoin();
            indexTimeCooldown = coinCooldown;
        }
        indexTimeCooldown -= Time.deltaTime;
    }
}