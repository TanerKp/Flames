using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [SerializeField] GameObject Flame;
    [SerializeField] GameObject spawnParticle;
    [SerializeField] float spawnRate;

    private bool availableSpawn;

    private void Awake()
    {
        StartCoroutine(WaveSpawn());
    }

    private void Update()
    {
        if (availableSpawn)
        {
            StartCoroutine(WaveSpawn());
        }
    }

    IEnumerator WaveSpawn()
    {
        availableSpawn = false;

        int rnd = Random.Range(1,4);
        for (int i = 0; i < rnd; i++)
        {
            StartCoroutine(Spawn());
        }
        yield return new WaitForSeconds(spawnRate);

        availableSpawn = true;
    }

    IEnumerator Spawn()
    {
        Vector2 Pos = SearchLocation();
        Instantiate(spawnParticle, Pos, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(Flame, Pos, Quaternion.identity);
    }

    private Vector2 SearchLocation()
    {
        float yPos = Random.Range(-3.5f, 3.5f);
        float xPos = Random.Range(-8,8);

        return new Vector2(xPos, yPos);
    }


}
