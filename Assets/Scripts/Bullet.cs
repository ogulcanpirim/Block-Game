using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject bExplosion;
    public GameObject bulletExplosion;
    public static float bulletDamage;
    private GameObject crossParent;
    private float bulletSpeed;
    void Start()
    {
        bulletSpeed = 7.5f;
        crossParent = GameObject.Find("CrossParent");
        bulletDamage = 3.0f;
    }

    void Update()
    {
        transform.position += -transform.up * bulletSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bExplosion = Instantiate(bulletExplosion, this.transform.position, Quaternion.identity);
        bExplosion.GetComponent<ParticleSystem>().Play();
    }
}
