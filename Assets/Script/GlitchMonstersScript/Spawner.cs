using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Attacker attacker;
    private float spawnerTimer;
    private GameObject newAttacker;

    public GameObject[] gameObjects;
    public List<GameObject> gameObjectsInLane;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject attacker in gameObjects)
        {
            if (TimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
        foreach (GameObject attackerInList in gameObjectsInLane.ToArray())
        {
            if (attackerInList == null)
            {
                gameObjectsInLane.Remove(attackerInList);
            }
        }
    }

    private void Spawn(GameObject GO)
    {
        if (gameObjectsInLane.Count <= 3)
        {
            newAttacker = Instantiate(GO, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            gameObjectsInLane.Add(newAttacker);
        }
        else
        {
            return;
        }
    }

    private bool TimeToSpawn(GameObject gameObject)
    {
        attacker = gameObject.GetComponent<Attacker>();
        spawnerTimer = attacker.spawnEvery; //secondi effettivi per lo spawn del nemico

        float probabilityToSpawnInGivenSecond = 1 / spawnerTimer; //probabilità di spawnare in quel secondo

        if (Time.deltaTime > spawnerTimer)
        {
            Debug.LogWarning("Spawn rate capped by framerate");
        }

        float probabilityToSpawnInGiveFrame = (probabilityToSpawnInGivenSecond * Time.deltaTime) / 5; // probabilità di spawnare in quel frame sulla lane

        return (Random.value  < probabilityToSpawnInGiveFrame);


    }
}
