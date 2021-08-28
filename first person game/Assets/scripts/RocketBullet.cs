using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    public float explosionRadius = 5f;
    private Rigidbody rb;
    public GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject); 
        Destroy(expl, 3);
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in objectsInRange)
        {
            Target target = col.GetComponent<Target>();
            if (target != null)
            {
                float proximity = (transform.position - target.transform.position).magnitude;
                float effect = 1 - (proximity / explosionRadius);                
                target.TakeDamage(100 * effect);

            }
        }
        print("hit " + other.name + "!");
        //Destroy(gameObject, 2f);
    }
}
