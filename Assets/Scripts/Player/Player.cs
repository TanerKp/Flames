using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //  TODO:   - Death Sound

    [SerializeField] Animator anim;
    [SerializeField] GameObject deathParticle;
    [SerializeField] AudioSource audio;

    private void Update()
    {
        if (GetComponent<HealthBar>().isDead)
        {
            ShakeCamera();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Traps")
        {
            DamagePlayer();
        }

        if (collision.tag == "Enemy")
        {
            if (collision.transform.position.y < transform.position.y - 0.75f)
            {
                DamagePlayer();
            }
            collision.GetComponent<HealthBar>().isDead = true;
        }
    }

    void DamagePlayer()
    {
        GetComponent<HealthBar>().TakeDamage(1);
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        ShakeCamera();
        audio.Play();
    }

    void ShakeCamera()
    {
        anim.SetTrigger("shake");
    }
}
