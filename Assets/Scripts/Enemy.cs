using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float duration = -10f;
    public GameObject explosionPrefab;

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.gameOver) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

        if (transform.position.x < duration)
        {
            Destroy(gameObject);
            GameManager.Instance.Lose();
        }
    }

    public void DestroyEnemy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}