using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    private float scrollSpeed = 8f;
    
    
    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

    }
}
