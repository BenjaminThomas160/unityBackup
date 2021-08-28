using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject dead_version;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(dead_version, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
