using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvent : MonoBehaviour
{
    [SerializeField]
    private int amountOfObjects;
    [SerializeField]
    private GameObject spawnArea;
    [SerializeField]
    private GameObject[] objects;

    [Header("Spawn Range")]

    [SerializeField]
    private float xRange;
    [SerializeField]
    private float yRange;
    [SerializeField]
    private float zRange;

    [SerializeField]
    private float spawnSpeed;
    [SerializeField]
    private float launchSpeed;

    private bool activated;

    private void Start()
    {
        activated = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        spawnArea.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !activated)
        {
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < amountOfObjects; i++)
        {
            int item = Random.Range(0, objects.Length);

            GameObject spawn = Instantiate(objects[item], new Vector3(spawnArea.transform.position.x + Random.Range(-xRange, xRange), spawnArea.transform.position.y + Random.Range(-yRange, yRange), spawnArea.transform.position.z + Random.Range(-zRange, zRange)), spawnArea.transform.rotation);

            //lauches items forward
            spawn.GetComponent<Rigidbody>().AddForce(Vector3.back * launchSpeed, ForceMode.Impulse);

            activated = true;

            yield return new WaitForSeconds(spawnSpeed);
        }
        Destroy(this.gameObject);
    }
}
