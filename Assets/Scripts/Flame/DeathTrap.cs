using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour {

    int health = 2;

    bool end;

    private void Start()
    {
        StartCoroutine(FlipObject());
    }

    private void Update()
    {
        if (end)
            StartCoroutine(FlipObject());
    }

    IEnumerator FlipObject()
    {
        end = false;


        yield return new WaitForSeconds(0.25f);

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.y *= -1;
        transform.localScale = theScale;

        end = true;
    }

    public void ReduceScale()
    {
        health -= 1;

        if (health == 0)
        {
            Destroy(this.gameObject);
        }

        Vector3 theScale = transform.localScale;
        theScale.x *= 0.5f;
        theScale.y *= 0.5f;
        transform.localScale = theScale;



    }
}
