using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float duration = -10f;
    public GameObject smallEnemyPrefab;
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
        Vector3 offset = new Vector3(0, 10f, 0);

        Instantiate(smallEnemyPrefab, transform.position + offset, Quaternion.Euler(0,0,-90));
        Instantiate(smallEnemyPrefab, transform.position - offset, Quaternion.Euler(0,0,-90));

        Destroy(gameObject);
    }
}