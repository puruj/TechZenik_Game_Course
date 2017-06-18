using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    private LevelManager theLevelManager;

    //Session 5&6
    public int damageToGive;

    // Use this for initialization
    void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Session 5&6
            theLevelManager.HurtPlayer(damageToGive);
        }
    }
}
