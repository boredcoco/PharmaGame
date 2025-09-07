using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
  private bool dragging = false;
  private Vector3 offset;

  private ControlEnglargedView _controlEnglargedView;

  private void Start()
  {
    _controlEnglargedView = GameObject.FindWithTag(Tags.ControlEnglargedView).GetComponent<ControlEnglargedView>();
  }

  private void Update() {
    if (dragging) {
      if (_controlEnglargedView.isActive)
      {
        return;
      }
      // Move object, taking into account original offset.
      transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }
  }

  private void OnMouseDown() {
    // Record the difference between the objects centre, and the clicked point on the camera plane.
    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    dragging = true;
  }

  private void OnMouseUp() {
    // Stop dragging.
    dragging = false;
  }
}
