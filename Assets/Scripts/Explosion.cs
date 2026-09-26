using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        float duration = animator.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, duration);
    }
}