using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public GameObject explosionPrefab;

    void OnCollisionEnter(Collision c)
    {

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}