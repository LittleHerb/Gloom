using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform FirePoint;
    public float bulletSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

    }

    private void Fire()
    {
        GameObject Rocket = Instantiate(rocketPrefab);
        //Physics.IgnoreCollision(Rocket.GetComponent<Collider>(), FirePoint.parent.GetComponent<Collider>());

        Rocket.transform.position = FirePoint.position;

        Vector3 rotation = Rocket.transform.rotation.eulerAngles;

        Rocket.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        Rocket.GetComponent<Rigidbody>().AddForce(FirePoint.forward * bulletSpeed, ForceMode.Impulse);

    }

}

/*{
    public GameObject rocketPrefab;
    public Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject g = (GameObject)Instantiate(rocketPrefab, transform.firePoint, transform.parent.rotation);


            float force = g.GetComponent<Rocket>().speed;
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * force);
        }
    }
}*/