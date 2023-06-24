using System;
using System.Collections;
using UnityEngine;

public class ClickText : MonoBehaviour
{
    private void Start()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);
        StartCoroutine(StartTimer(1f));
    }

    private IEnumerator StartTimer(float timeLeft)
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            transform.position= new Vector2(transform.position.x,  transform.position.y + 0.05f);
            yield return null;
        }
        Destroy(gameObject);
    }
}
