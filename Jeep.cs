using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Jeep : MonoBehaviour {

    private float SideToSide = 0.1f;
    Vector3 Origin;
    private float seconds = 0f;
    public Text Score;

    private void Start()
    {
        Origin = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // keys to move jeep 
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.root.position += new Vector3(SideToSide, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.root.position -= new Vector3(SideToSide, 0, 0);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position += (Vector3.up * 40 * Time.deltaTime);
        }

        seconds += Time.deltaTime;

        Score.text = "Time: " + seconds.ToString();
    }

    // game ends when jeep is pushed out of screen or falls into water
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
        }

        // resets jeep position when it moves from origin
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.position = Origin;
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
}
