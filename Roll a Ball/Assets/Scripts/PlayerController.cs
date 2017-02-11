using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private int count;

    public float Speed = 1;
    public Text countText;
    public Text winText;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        rigidBody.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            if (count >= 8)
            {
                winText.text = "You Win!";
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count;
    }
}
