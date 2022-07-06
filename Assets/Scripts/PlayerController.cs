using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerAndroid : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public float speed;
    public TextMeshProUGUI countText,winText;
    private Rigidbody rb;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = variableJoystick.Horizontal;
        float moveVertical = variableJoystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);

        rb.AddForce(movement * speed);  
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Points: "+ count.ToString();
            if(count >= 20)
            {
                winText.gameObject.SetActive(true);
            }
        }
    }
}
