using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public float speed = 1.3f; //공속도
    private float attack1Reload = 1f;
    private float attack2Reload = 5f;
    private float PlayTime = 0; //플레이시간
    private int i = 0; // 포인트 돌아가는 순서
    public bool game = false; // 게임 on/off

    public GameObject Player;
    public GameObject PFArrow; // 투사체
    public GameObject[] Point; // 투사체 스폰 포인트
    public GameObject[] Point2; // 투사체 스폰 포인트

    Vector3 dir; // 타겟 위치

    public TextMeshProUGUI tmp; // 게임시간 Ui

    void Update()
    {
        
        if (game == true)
        {
            dir = new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y, 0);
            PlayTime += Time.deltaTime;
            tmp.text = "Time : " + string.Format("{0:0.##}", PlayTime);
        }
        else
        {
            StopAllCoroutines();
        }

        if (PlayTime > 10f)
        {
            attack1Reload = 0.8f;
        }
        if (PlayTime > 20)
        {
            attack1Reload = 0.6f;
        }
        if (PlayTime > 30)
        {
            attack1Reload = 0.5f;
        }
    }
    public void Gamestart()
    {
        Debug.Log("ok");
        attack1Reload = 1f;
        attack2Reload = 5f;
        PlayTime = 0;
        i = 0;
        game = true;

        Player.GetComponent<playerCT>().reStart();

        StartCoroutine("Attack1");
        StartCoroutine("Attack2");
    }
    IEnumerator Attack1()
    {
        while (true)
        {         
            Shoot1();
            yield return new WaitForSeconds(attack1Reload);
        }
    }

    IEnumerator Attack2()
    {
        while(true)
        {
            yield return new WaitForSeconds(attack2Reload);
            Shoot2();       
        }
    }

    void Shoot1()
    {
        if (PlayTime < 20f)
        {
            i++;
            if (i == 8)
                i = 0;
            GameObject Arrow = Instantiate(PFArrow);
            Arrow.transform.position = Point[i].transform.position;
            Arrow.gameObject.GetComponent<Rigidbody2D>().AddForce((dir - Point[i].transform.position) * speed, ForceMode2D.Impulse);
        }else
        {
            int rd = UnityEngine.Random.Range(0, 7);
            GameObject Arrow = Instantiate(PFArrow);
            Arrow.transform.position = Point[rd].transform.position;
            Arrow.gameObject.GetComponent<Rigidbody2D>().AddForce((dir - Point[rd].transform.position) * speed, ForceMode2D.Impulse);
        }
        if (PlayTime > 40f)
        {
            int rd = UnityEngine.Random.Range(0, 7);
            GameObject Arrow = Instantiate(PFArrow);
            Arrow.transform.position = Point2[rd].transform.position;
            Arrow.gameObject.GetComponent<Rigidbody2D>().AddForce((dir - Point2[rd].transform.position) * speed, ForceMode2D.Impulse);
        }
    }
    void Shoot2()
    {
        for (int j = 0; j < 8; j++)
        {
            GameObject Arrow = Instantiate(PFArrow);
            Arrow.transform.position = Point[j].transform.position;
            Arrow.gameObject.GetComponent<Rigidbody2D>().AddForce((dir - Point[j].transform.position) * speed, ForceMode2D.Impulse);
        }
    }
}
