using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;
    public float attack = 0;

    public void Init(float spd, int atk)
    {
        speed = spd;
        attack = atk;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.SendMessage("Damage", attack);
            Destroy(gameObject);
        }
    }
}