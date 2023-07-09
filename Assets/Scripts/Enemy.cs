using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    public float speed;  
    public Transform[] movePoints; //unityde belirlenen noktalarda karakterin random y�r�mesi i�in bir dizi olu�turdum.
    private int randomPos; // random say� tutuluyor

    void Start()
    {
        randomPos = Random.Range(0, movePoints.Length); // noktan�n belirli yerlerine random �ekilde atama yap�l�yor.
    }

    void Update()
    {
        //enemy karakterinin y�r�me kodu
        transform.position = Vector3.MoveTowards(transform.position, movePoints[randomPos].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoints[randomPos].position) < 0.2f)
        {
            randomPos = Random.Range(0, movePoints.Length);
        }

       
    }
}
