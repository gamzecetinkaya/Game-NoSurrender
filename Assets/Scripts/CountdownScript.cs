using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public int countDownTimer; // saniyeyi girmemiz i�in
    public TMP_Text countDownDisplay; // yaz�s�n� tutmak i�in
    
    

    private void Start()
    {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() 
    {
        while(countDownTimer > 0)
        {
            countDownDisplay.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }
        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);
    }
}
