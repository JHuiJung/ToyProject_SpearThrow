using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Score_board;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spear")
        {
            GameManager.Instance.isGameStart = true;
            Score_board.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
