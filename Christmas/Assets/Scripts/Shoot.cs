using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public GameObject Explosion;
    public AudioSource explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(Explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
        explosion.Play();
        if (col.gameObject.tag == "Tree")
        {
            Instantiate(Explosion,transform.position,Quaternion.identity);
            explosion.Play();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
