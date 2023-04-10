using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCT : MonoBehaviour
{
    public Transform tr;

    public float moveSpeed = 5f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tr.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tr.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tr.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tr.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
    public void reStart()
    {
        gameObject.transform.position = GameObject.Find("SpawnPoint").transform.position;
        gameObject.SetActive(true);
    }
    public void hit()
    {
        gameObject.SetActive(false);
    }
}
