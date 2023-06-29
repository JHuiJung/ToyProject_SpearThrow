using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Animal : MonoBehaviour
{
    const int animal_Vector_size = 8;
    public int hp = 1;
    public float speed = 8f;
    public int animal_Score = 10;
    float time;
    float turnTime_min = 2f;
    Animator animator;
    Vector3 nowVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Walk");

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Check_inGround();
        
        
    }
    void Move()
    {
        time += Time.deltaTime;
        if (time >= Random.Range(turnTime_min, 3f))
        {
            time = 0;
            nowVector = new Vector3(0, Random.Range(0, 360f), 0);
            this.transform.eulerAngles = nowVector;
        }

        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void Check_inGround()
    {
        if (transform.position.x > 40) { 
            float y = transform.position.y;
            float z = transform.position.z;
            float x = 40f;
            transform.position = new Vector3(x, y, z);
        }
        else if( transform.position.x < -50)
        {
            float y = transform.position.y;
            float z = transform.position.z;
            float x = -50f;
            transform.position = new Vector3(x, y, z);
        }

        if (transform.position.z > 120)
        {
            float y = transform.position.y;
            float z = 120f;
            float x = transform.position.x;
            transform.position = new Vector3(x, y, z);
        }
        else if (transform.position.z < 24)
        {
            float y = transform.position.y;
            float z = 24f;
            float x = transform.position.x;
            transform.position = new Vector3(x, y, z);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spear")
        {
            
            hp -= 1;
            Debug.Log("¸ÂÀ½"+hp.ToString());
            if (hp == 0)
            {
                onDie();
            }
            else
            {
                speed = speed * 2;
                animator.SetTrigger("Run");
                turnTime_min = 1f;
            }
            
        }
        other.GetComponent<Spear>().Destroy_this();
    }

    void onDie()
    {
        speed = 0f;
        animator.SetTrigger("Die");
        GameManager.Instance.score += animal_Score;
        Destroy(gameObject, 1.5f);
    }
}
