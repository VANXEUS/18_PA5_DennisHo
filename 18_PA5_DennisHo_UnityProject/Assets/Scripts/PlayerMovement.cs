using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Text txt_Coins;
    public float Speed = 70;
    Rigidbody thisRigidbody;
    private int CCollected;
    public static int level;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        thisRigidbody.AddForce(movement * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            CCollected++;
            txt_Coins.text = "Coins Collected: " + CCollected;
            Destroy(other.gameObject);

            if (CCollected == 4)
            {
                Scene scene = SceneManager.GetActiveScene();

                if (scene.name == "Gameplay_Level1")
                    level = 1;

                if (scene.name == "Level 2")
                    level = 2;

                if (level == 1)
                {
                    SceneManager.LoadScene("Level 2");
                }

                if (level == 2)
                {
                    SceneManager.LoadScene("GameWin");
                }
            }
        }

        if (other.tag == "Hazard")
            SceneManager.LoadScene("GameLose");
    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.other.tag == "Hazard")
        {
            //SceneManager.LoadScene("GameLose");
            //}
        }
    }
}
