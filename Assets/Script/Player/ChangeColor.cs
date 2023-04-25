using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeColor : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = _spriteRenderer.color;
    }

    void ColorChange()
    {
        Color col = Random.ColorHSV();
        col.a = 1;
        _spriteRenderer.color = col;
    }
    
    void ResetColor()
    {
        _spriteRenderer.color = originalColor;
    }

    private void OnChangeColor(InputValue value) //Modo Yato lo comentado
    {
        //GameObject.Find("Player").GetComponent<Renderer>().material.color = new Color(Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f);
        ColorChange();
    }

    private void OnResetColor(InputValue value)
    {
        ResetColor();
        Debug.Log("Hola");
    }
}
