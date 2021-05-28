using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private Vector2 screen;
    private GameObject explosion;
    public GameObject EnemyExplosion;
    void Start()
    {
        screen = ScreenSize.screenSize;
        explosion = GameObject.Find("eExplosion");
    }
    
    void Update()
    {
        foreach(GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            if (go.gameObject.name == "Bullet(Clone)")
            {
                if (outOfBounds(go.transform.position))
                    Destroy(go);
            }
            if (go.gameObject.name.StartsWith("Enemy"))
            {
                if (go.GetComponent<Enemy>().getHealth() <= 0)
                {
                    explosion = Instantiate(EnemyExplosion, go.transform.position, Quaternion.identity);
                    explosion.GetComponent<ParticleSystem>().Play();
                    Destroy(go);
                }
            }
            if (go.gameObject.name.Contains("Explosion"))
            {
                if (!go.GetComponent<ParticleSystem>().IsAlive())
                    Destroy(go);
            }
        }
    }
    
    bool outOfBounds(Vector3 pos)
    {
        if (pos.x > screen.x || pos.x < -screen.x || pos.y > screen.y || pos.y < -screen.y)
            return true;
        return false;
    }
}
