using UnityEngine;
using System.Collections;

public class CloudControl : MonoBehaviour
{
    public Transform[] fruitObj;
    static public string spawnedYet = "n";
    static public Vector2 cloudxPos;
    static public Vector2 spawnPos;
    static public string newfruit="n";
    static public int whichFruit = 0;

    void Start()
    {

    }


    void Update()
    {
        spawnFruit();
        replaceFruit();

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }

        if ((!Input.GetKey("a")) && (!Input.GetKey("d")))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if ((GetComponent<Rigidbody2D>().velocity.x < 0) && (transform.position.x < -2.6))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if ((GetComponent<Rigidbody2D>().velocity.x < 0) && (transform.position.x > 2.6))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        cloudxPos = transform.position;

    }

    void spawnFruit()
    {
        if (spawnedYet == "n")
        {
            StartCoroutine(spawntimer());
            spawnedYet = "y";
        }
    }

    void replaceFruit()
    {
        if (newfruit == "y")
        {
            newfruit = "n";
            Instantiate(fruitObj[whichFruit + 1], spawnPos, fruitObj[0].rotation);
        }
    }

    IEnumerator spawntimer()
    {
        yield return new WaitForSeconds(.75f);
        Instantiate(fruitObj[Random.Range(0, 3)], transform.position, fruitObj[0].rotation);
    }
}
