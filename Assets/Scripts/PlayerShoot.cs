using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float nextFireTime = 0f;


    void Update()
    {
        if(GameManager.Instance == null) return;

        if(GameManager.Instance.gameOver || GameManager.Instance.paused) return;

        if (Keyboard.current.spaceKey.isPressed && Time.time >= nextFireTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }
}