using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
   // Assign a new color through the Unity Inspector or via code.
    public Color dangerColor = Color.red;
    public Color warnColor = Color.yellow;

    // Use this for initialization
    void Start()
    {
        // You can change the color here if you want it to change on start.
        // ChangeObjectColor(newColor);
    }

    // Update is called once per frame
    void Update()
    {
        // As an example, change color when the "C" key is pressed.
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeObjectColor(dangerColor);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            ChangeObjectColor(Color.white);
        }

        // As an example, change color when the "C" key is pressed.
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ChangeObjectColor(warnColor);
        }

        if (Input.GetKeyUp(KeyCode.Y))
        {
            ChangeObjectColor(Color.white);
        }
    }

    void ChangeObjectColor(Color color)
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.color = color;
        }
    }
}
