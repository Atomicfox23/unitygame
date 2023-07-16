using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Santa : MonoBehaviour
{
    public float Jumpforce = 10;
    private Rigidbody2D rb;
    public ParticleSystem Fire; 
    public float Score;
    public float Ammo;
    public Text AmmoText;
    public Text ScoreText;
    public GameObject Rocket;
    public Transform RSpawn;
    public AudioSource jump;
    public AudioSource pickUp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
        AmmoText.text = Ammo.ToString();
        if (Score >= 100)
        {
            SceneManager.LoadScene("Win");
        }
    }
    public void Jump()
    {
        
        rb.velocity = Vector2.up * Jumpforce;
        rb.gravityScale = 0;
        jump.Play();
        Fire.Play();
    }
    public void StopP()
    {
        rb.gravityScale = 2;
        Fire.Stop();
    }
    public void Shoot()
    {
        Time.timeScale = 0.3f;
    }
    public void NShoot()
    {
        if (Ammo > 0)
        {
            Instantiate(Rocket, RSpawn.transform.position, Quaternion.identity);
            Ammo--;
        }
        Time.timeScale = 1f;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tree")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (col.gameObject.tag == "Ammo")
        {
            Ammo += 3f;
            pickUp.Play();
            Destroy(col.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.gameObject.tag == "Score")
        {
            Score++;
        }
        if (col2.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
