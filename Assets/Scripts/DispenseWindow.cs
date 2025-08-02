using UnityEngine;

public class DispenseWindow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isMouseDown;

    private void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
      isMouseDown = Input.GetMouseButton(0); // get the left mouse button
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
      if (collider.gameObject.tag == Tags.Medicine)
      {
        spriteRenderer.color = Color.red;
      }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
      if (collider.gameObject.tag == Tags.Medicine)
      {
        if (!isMouseDown)
        {
          Debug.Log("the medicine is dispensed!");
        }
      }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
      spriteRenderer.color = Color.white;
    }
}
