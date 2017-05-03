using UnityEngine;

public class Attacker : Tower
{
    public int attackPower;
    public float attackCooldown;
    public float attackRadius;
    public float bulletSpeed;
    public GameObject bullet;

    float indexTimeCooldown;
    bool zombieDetected;

    void Shoot()
    {
        GameObject bul = Instantiate(bullet, this.transform.position, Quaternion.identity) as GameObject;
        bul.GetComponent<Bullet>().Init(bulletSpeed, attackPower);
    }

    private void Start()
    {
        indexTimeCooldown = 0;
    }

    private void Update()
    {
        if (zombieDetected)
        {
            if(indexTimeCooldown <= 0)
            {
                Shoot();
                indexTimeCooldown = attackCooldown;
            }
            indexTimeCooldown -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.right, attackRadius);
        zombieDetected = false;
        
        for(int i = 0; i < hit.Length; i++)
        {
            if(hit[i].collider.CompareTag("Zombie"))
            {
                zombieDetected = true;
            }
        }
    }
}