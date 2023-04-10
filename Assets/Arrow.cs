using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            coll.gameObject.GetComponent<playerCT>().hit();
            GameObject.Find("Canvas").GetComponent<GM>().game = false;
            Destroy(gameObject);
        }      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
