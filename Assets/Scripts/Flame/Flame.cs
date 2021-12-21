using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour {

    [SerializeField] GameObject DeathTrap;
    [SerializeField] GameObject deathParticle;
    [SerializeField] GameObject KillsAnzeige;

    private void Update()
    {
        // Wenn eine Flame stirbt, lässt es eine Falle liegen und Tot-Partikel werden erstellt.
        if (GetComponent<HealthBar>().isDead)
        {
            Instantiate(DeathTrap, new Vector2(transform.position.x, transform.position.y - 0.8f), Quaternion.identity);
            Instantiate(deathParticle, new Vector2(transform.position.x, transform.position.y - 0.8f), Quaternion.identity);

            GameObject.Find("EventSystem").GetComponent<DeadMenu>().kills += 1;

            Destroy(this.gameObject);
        }
    }
}
