using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float speed = 60f; //karakter hýzý
    [SerializeField]
    private float rotationSpeed = 10f; //kamera dönme hýzý
    [SerializeField]
    private Camera followCamera;    //kamera karakteri takip edecek
    private int score;
    [SerializeField]
    private TMP_Text scoreText;







    public Animator anim;
    public Rigidbody rb;

    Vector3 moveVelocity;
    

    void Start()
    {

        anim = GetComponent<Animator>();  //animasyon çalýþtýrma 
        characterController = GetComponent<CharacterController>();
        score = 0;
        scoreText.text = "Score: " + score.ToString(); // skor int ama to string ile yazý haline çevirip yazdýrýyoruz

    }

    void Update()
    {


        Move();
        scoreText.text = "Score: " + score.ToString();


    }



    private void Move()  //karakter yürütme kodu
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        anim.SetBool("isWalking", movementDirection != Vector3.zero);

        //characterController.Move(movementDirection * speed * Time.deltaTime);
        characterController.Move(movementDirection * speed * Time.deltaTime + 9.81f * Time.deltaTime * Vector3.down);




        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }


    }
    void OnTriggerEnter(Collider col) //karakter enemy tagli cisme çarptýðýnda cisim yok olacak ve skor artacak
    {
        if (col.gameObject.tag == "enemy")
        {

            
            Destroy(col.gameObject, 3f);
            score++;

            

        }

    }


}