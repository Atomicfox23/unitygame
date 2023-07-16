using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject tree;
    public float hight;
    public float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newtree = Instantiate(tree);
        newtree.transform.position = transform.position + new Vector3(0, Random.Range(hight, -hight),0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= maxTime)
        {
            GameObject newtree = Instantiate(tree);
            newtree.transform.position = transform.position + new Vector3(0, Random.Range(hight, -hight),0);
            Destroy(newtree, lifeTime);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
