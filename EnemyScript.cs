//The Script For Anyone Who Wants It:

using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    
    public float distanceFromPlayer;

    public bool playerIsSeen;

    public bool hitByLight;

    public Animator animator;
 
    public AudioSource attackSound;

    public AudioSource runningSound;

    public AudioSource deathSound;

    

    public Transform particleSystem;


	public GameObject Enemy;
	private void Awake()
	{
		Player = GameObject.Find("Player");
		Enemy = Resources.Load("monsterPaintedandAnimated") as GameObject;
	}
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = transform.GetChild(2);   
    }

    public void finishedCowering()
    {
       // attackSound.Stop();
        //runningSound.Stop();
        deathSound.Play();
		gameObject.SetActive(false);
		Invoke("Respawn",10);
		deathSound.Stop(); 
        
    }

    void Respawn()
    {
        GameObject enemyClone = (GameObject)Instantiate(Enemy);
        enemyClone.transform.position = transform.position;
        particleSystem.transform.parent = enemyClone.transform.GetChild(0);
        enemyClone.SetActive(true);
        
	}

    public void stopTheMonster()
    {
        //print("should be stopping");
        animator.SetBool("playerSafe", value: true);
        _agent.isStopped = true;
        this.enabled = false; 
        
    }

    public void startTheMonster()
    {
        print("monster is on the move");
        animator.SetBool("playerSafe", value: false);
        _agent.isStopped = false;
        this.enabled = true; 
    }

    public void screamTime()
    {
        runningSound.Play(); 
    }

    public void onStartedAttacking()
    {
        attackSound.Play();
    }
    
    public void OnTriggerEnter(Collider other)
    {

        Flashlight lightCollider = other.GetComponent<Flashlight>(); 
        
        
        
        //print("hit a trigger: " + other.name);
        if (lightCollider != null && lightCollider.isLightOn)
        {
            print("hit by the flashlight");
            runningSound.Stop();
            deathSound.Play();
            stopTheMonster();
            animator.SetBool("hitByLight", value: true);
            
            
            
            
        }
        
    }

    
    
    
    // make a method that detects the spot lights and stops the speed of the monster.
    //just like the detection of the spot light but put it on the player (the collider w/ trigger)

    
    // set what ever distance you want for it to detect the player

    public float detectPlayerDist;
    
    public NavMeshAgent _agent;

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(Player.transform.position, this.transform.position);

        if(distanceFromPlayer <= detectPlayerDist)
        {
            playerIsSeen= true;

            if (distanceFromPlayer == 20)
            {
                runningSound.Play();
            }
            
            
            
            if (distanceFromPlayer <= 5)
            {
                //print("triggers the attack event");
                
                
                animator.SetBool("monsterCloseToPlayer", value: true);
                runningSound.Stop();
                
               
                // this is playing too frequently and does not accurately trigger the attack sound
            }
            else
            {
                animator.SetBool("monsterCloseToPlayer", value: false);
                animator.SetBool("playerSeen", value: true);
            }
            
        }
        if(distanceFromPlayer > detectPlayerDist)
        {
            playerIsSeen = false;
        }

        if (playerIsSeen)
        {
            _agent.isStopped = false;
            print("should start screaming");
            
            _agent.SetDestination(Player.transform.position);
        }
        if (!playerIsSeen)
        {
            
            _agent.isStopped = true;
        }

        if (hitByLight)
        {
            
            // destroy enemy here
            
        }
    }
    
}