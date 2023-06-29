using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] Animals;

    float min_x = -45f , min_z =29f;
    float max_x = 35f , max_z = 115f;
    float y = 10f;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStart)
        {
            time += Time.deltaTime;
            if (time >= Random.Range(3f, 6f))
            {
                time = 0f;
                Spawn();
            }
        }
        
    }

    void Spawn()
    {
        
        GameObject a = Instantiate(Animals[Random.Range(0, Animals.Length)]);
        a.transform.position = new Vector3 (Random.Range(min_x,max_x),y, Random.Range(min_z, max_z));
        a.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }
}
