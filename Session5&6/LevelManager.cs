using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;

    public GameObject Death_Explosion;

    //Session 5&6
    public int coinCount;

    //Session 5&6
    public Text coinText;

    //Session 5&6
    public Image heart1;
    public Image heart2;
    public Image heart3;
    //Session 5&6
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;
    //Session 5&6
    public int maxHealth;
    public int healthCount;

    //Session 5&6
    private bool respawning;

    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        //Session 5&6
        coinText.text = "Coins: " + coinCount;

        healthCount = maxHealth;
    }

    // Update is called once per frame
    void Update () {
        //Session 5&6
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        Instantiate(Death_Explosion, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);
        //Session 5&6
        healthCount = maxHealth;
        respawning = false;
        updateHeartMeter();

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }
    //Session 5&6

    public void AddCoins(int coinsToAdd)
    {
        coinCount = coinCount + coinsToAdd;
        //Session 5&6
        coinText.text = "Coins: " + coinCount;
    }

    //Session 5&6
    public void HurtPlayer(int damageToTake)
    {
        healthCount -= damageToTake;
        updateHeartMeter();
    }

    public void updateHeartMeter()
    {
        switch (healthCount)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;

            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;

            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
        }
    }
}
