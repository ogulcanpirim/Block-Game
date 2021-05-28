using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float enemyHealth;
    private float enemySpeed;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        enemySpeed = 0.5f;
        enemyHealth = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.position = (Vector3) Vector2.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<AudioSource>().Play();
        float damage = Bullet.bulletDamage;
        enemyHealth -= damage;
        if (collision.gameObject.name.Contains("Bullet"))
            Destroy(collision.gameObject);
        StartCoroutine(changeColor());
    }

    public float getHealth()
    {
        return enemyHealth;
    }

    IEnumerator changeColor()
    {
        Color curr = this.GetComponent<SpriteRenderer>().color;
        Color colorChange;
        ColorUtility.TryParseHtmlString("#D28080", out colorChange);
        this.GetComponent<SpriteRenderer>().color = colorChange;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<SpriteRenderer>().color = curr;
    }
}
