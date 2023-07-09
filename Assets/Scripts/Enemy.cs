using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    public float speed;  
    public Transform[] movePoints; //unityde belirlenen noktalarda karakterin random yürümesi için bir dizi oluþturdum.
    private int randomPos; // random sayý tutuluyor

    void Start()
    {
        randomPos = Random.Range(0, movePoints.Length); // noktanýn belirli yerlerine random þekilde atama yapýlýyor.
    }

    void Update()
    {
        //enemy karakterinin yürüme kodu
        transform.position = Vector3.MoveTowards(transform.position, movePoints[randomPos].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoints[randomPos].position) < 0.2f)
        {
            randomPos = Random.Range(0, movePoints.Length);
        }

       
    }
}
