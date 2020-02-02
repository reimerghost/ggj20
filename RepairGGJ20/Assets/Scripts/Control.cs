using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private float horizontal, vertical;
    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.GetComponent<GameManager>().usarCartaPlayer(0, 1);
            print("Carta 1 - P1");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            this.GetComponent<GameManager>().usarCartaPlayer(1, 1);
            print("Carta 2 - P1");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            this.GetComponent<GameManager>().usarCartaPlayer(2, 1);
            print("Carta 3 - P1");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<GameManager>().usarCartaPlayer(0, 2);
            print("Carta 1 - P2");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.GetComponent<GameManager>().usarCartaPlayer(1, 2);
            print("Carta 2 - P2");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<GameManager>().usarCartaPlayer(2, 2);
            print("Carta 3 - P3");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<GameManager>().usarCartaDesastre();
        }

        horizontal = Input.GetAxis("Vertical");
        vertical = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            Debug.Log(horizontal);
        }

        if (vertical != 0)
        {
            Debug.Log(vertical);
        }
    }
}
