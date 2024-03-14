using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitControl : MonoBehaviour
{
    private string inthecloud = "y";
    private string timetocheck = "n";

    void Start()
    {
        if (transform.position.y < 3.5)
        {
            inthecloud = "n";
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    void Update()
    {
        if (inthecloud == "y")
        {
            GetComponent<Transform>().position = CloudControl.cloudxPos;
        }

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            inthecloud = "n";
            CloudControl.spawnedYet = "n";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            CloudControl.spawnPos = transform.position;
            CloudControl.newfruit = "y";
            CloudControl.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "limit" && timetocheck == "y") // Corrected the condition
        {
            Debug.Log("game over");
        }
    }

    IEnumerator chkGameOver()
    {
        yield return new WaitForSeconds(.75f);
        timetocheck = "y";
    }
}
