using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class BallController : NetworkBehaviour
{
    [SerializeField]
    public float BallSpeed = 4000f;
    Rigidbody rb;
    private int count = 5;
    public Text CountText;
    public Text WinText;
    
    // Start is called before the first frame update
    void Awake()
    {
        WinText.text = "";
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            Vector3 movement = new Vector3(-Input.acceleration.x,0f, -Input.acceleration.y);
            rb.AddForce(movement * BallSpeed * Time.deltaTime);
        }
            
        SetCountText();
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    void SetCountText()
    {
        
        if (count <= 0)
        {
            CountText.text = ("Go to fence !");
        }
        else
        {
            CountText.text = ("You need to pick: " + count.ToString() + " chests.");
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            other.gameObject.SetActive(false);
            count--;

        }

        if (other.gameObject.CompareTag("Goal"))
        {
            if (count <= 0)
            {
                WinText.text = "You Win!";
                
                SceneManager.LoadScene("MainMenu");
                System.Threading.Thread.Sleep(2000);
            }
        }

        if (other.gameObject.CompareTag("OUT1"))
        {
            SceneManager.LoadScene("Level1");
        }

        if (other.gameObject.CompareTag("OUT2"))
        {
            SceneManager.LoadScene("Level1");
        }

        if (other.gameObject.CompareTag("OUT3"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
