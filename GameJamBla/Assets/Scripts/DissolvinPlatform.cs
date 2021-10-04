using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvinPlatform : MonoBehaviour
{
    private bool AktivPlatform;
    private bool TimerTwoAk;
    private float TimerTime;
    private float TimerTimeTwo;
    public EdgeCollider2D edge;
    public PlatformEffector2D platformEffector2D;
    public GameObject Particles;
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){

           TimerTwoAk=true;
        }
    }
   void Start(){
       AktivPlatform=false;
       TimerTwoAk=false;
   }
    void Update(){
        if(AktivPlatform){
            Timer();
            TimerTime+=0.1f;
        }
        if(TimerTwoAk){
            TimerTwo();
            TimerTimeTwo+=0.05f;
        }
    }
    void Timer(){
        Debug.Log(TimerTime);
        if(TimerTime>=10){
            TimerTime=0;
            AktivPlatform=false; 
            platformEffector2D.enabled=true;
            Particles.SetActive(true);
            edge.enabled=true; 
        }
    }
    void TimerTwo(){
        Debug.Log(TimerTimeTwo);
        
        if(TimerTimeTwo>=10){
            AktivPlatform=true;   
            platformEffector2D.enabled=false;
            Particles.SetActive(false);

            edge.enabled=false;
            TimerTwoAk=false;
            TimerTimeTwo=0;
        }
    }
}