using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] GameObject shotParticle;

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    //public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<HealthBar>().TakeDamage(damage);
            }


            if (hitInfo.collider.CompareTag("Traps"))
            {
                //hitInfo.collider.GetComponent<DeathTrap>().ReduceScale();     // NICHT SICHER OB ES GUT IST WEGEN THEMA
            }

            DestroyProjectile();
            Instantiate(shotParticle, transform.position, Quaternion.identity);
        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
