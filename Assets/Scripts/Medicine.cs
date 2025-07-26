using UnityEngine;

public class Medicine : MonoBehaviour
{
    public string _name;
    [SerializeField] private ChemicalName _chemicalName;
    public string _urlToImg;

    public float _weight = 5f; // in mg
    public string _issueDate = "26/07/25";

    // controls view of image displayed
    ControlEnglargedView _controlEnglargedView;

    // drag and drop mechanics
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 _beforeDragPosition;

    private void Start()
    {
      _controlEnglargedView = GameObject.FindWithTag(Tags.ControlEnglargedView).GetComponent<ControlEnglargedView>();
    }

    private void Update()
    {
      if (dragging) {
        // Move object, taking into account original offset.
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
      }
    }

    private void OnMouseDown() {
      // Record the difference between the objects centre, and the clicked point on the camera plane.
      offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
      _beforeDragPosition = transform.position;
      dragging = true;
    }

    private void OnMouseUp() {
      if (_beforeDragPosition.Equals(transform.position))
      {
        _controlEnglargedView.SetMedicineView(this);
      }
      dragging = false;
    }

    // private void OnMouseDrag()
    // {
    //   offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //   dragging = true;
    // }


}
