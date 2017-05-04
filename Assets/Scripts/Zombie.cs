using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int health;
    public float speed;
    public int attack;
    public int cooldownAttack;
    public bool collideWithTower;
    public float indexTimeCooldown;
    public bool isTimeToAttack;
    public GameObject towerTargeted;

    public delegate void OnZombieFinishHandler();
    public delegate void OnZombieDeadHandler();

    public static event OnZombieFinishHandler Finish;
    public static event OnZombieDeadHandler Dead;

    public void Damage(int dmg)
    {
        health -= dmg;
    }

    void Walk()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnZombieDead()
    {
        Dead();
    }

    void OnZombieFinish()
    {
        Finish();
    }

    private void Start()
    {
        collideWithTower = false;
        indexTimeCooldown = cooldownAttack;
        isTimeToAttack = false;
    }

    private void Update()
    {
        if(!collideWithTower)
        {
            Walk();
        }
        else
        {
            if(indexTimeCooldown <= 0)
            {
                isTimeToAttack = true;
                indexTimeCooldown = cooldownAttack;
            }
            indexTimeCooldown -= Time.deltaTime;
        }

        if(health <= 0)
        {
            OnZombieDead();
            Destroy(gameObject);
        }

        if(towerTargeted == null)
        {
            collideWithTower = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            towerTargeted = collision.gameObject;
            collideWithTower = true;
            collision.gameObject.SendMessage("Damage", attack);
            isTimeToAttack = false;
        }

        if(collision.gameObject.tag == "LoseArea")
        {
            OnZombieFinish();
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            collideWithTower = true;
            if(isTimeToAttack)
            {
                collision.gameObject.SendMessage("Damage", attack);
                isTimeToAttack = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            collideWithTower = false;
        }
    }
}