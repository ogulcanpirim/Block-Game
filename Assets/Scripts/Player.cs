using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool nextBullet;
    public float bulletSpeed;
    private Vector2 screen;
    private float crossLoc; 
    private float playerSpeed;
    private float playerSize;
    private GameObject cross, crossParent;
    public GameObject bullet;
    void Start()
    {
        bulletSpeed = 0.1f;
        nextBullet = true;
        playerSpeed = 5.0f;
        cross = GameObject.Find("Cross");
        crossParent = GameObject.Find("CrossParent");
        crossLoc = cross.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        playerSize = this.GetComponent<SpriteRenderer>().bounds.size.x;
        screen = ScreenSize.screenSize;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W))
            pos.y += playerSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            pos.y -= playerSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            pos.x += playerSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            pos.x -= playerSpeed * Time.deltaTime;

        bool notInside = pos.x + playerSize / 2 > screen.x || 
                         pos.x - playerSize / 2 < -screen.x || 
                         pos.y + playerSize / 2 > screen.y || 
                         pos.y - playerSize / 2 < -screen.y;

        if (!notInside)
            transform.position = pos;
        crossParent.transform.position = pos;
        cross.transform.localPosition = new Vector3(0,-crossLoc,0);

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        crossParent.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));

        //Constant shoot with bulletSpeed
        /*
        if (nextBullet)
            StartCoroutine(shoot());
        */

        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 bulletPos = pos - crossParent.transform.up * playerSize;
            Instantiate(bullet, bulletPos, crossParent.transform.rotation);
        }

    }

    IEnumerator shoot()
    {
        if (nextBullet)
        {
            this.GetComponent<AudioSource>().Play();
            Vector3 bulletPos = transform.position - crossParent.transform.up * playerSize;
            Instantiate(bullet, bulletPos, crossParent.transform.rotation);
            nextBullet = false;
        }
        yield return new WaitForSeconds(bulletSpeed);
        nextBullet = true;
    }



    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
