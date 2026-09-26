using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.gameOver) return;
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BigEnemy big = other.GetComponent<BigEnemy>();
        if(big != null)
        {
            GameManager.Instance.AddScore(2);
            big.DestroyEnemy();
            Destroy(gameObject);
            return;
        }

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            GameManager.Instance.AddScore(1);
            enemy.DestroyEnemy();
            Destroy(gameObject);
        }
/*
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Enemy>() != null)
            {
                GameManager.Instance.AddScore(1);
                other.GetComponent<Enemy>().DestroyEnemy();
            }
            Destroy(gameObject);
        }*/
    }
}