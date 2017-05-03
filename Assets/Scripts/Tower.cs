using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int price;

    public void Damage(int dmg)
    {
        health -= dmg;
        if (health <= 0) Destroy(GameObject);
    }
}