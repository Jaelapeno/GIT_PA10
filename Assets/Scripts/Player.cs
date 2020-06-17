using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    private Rigidbody thisRigidbody = null;
    public float Force = 500;

    private float score = 0;

    public Text Txt_Score;
    
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            thisRigidbody.AddForce(Vector3.up * Force);
        }

        Txt_Score.text = "SCORE : " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Score")
        {
            score++;
        }
    }
}
