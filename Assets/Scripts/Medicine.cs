using UnityEngine;

public class Medicine : MonoBehaviour
{
    public string _name;
    public ChemicalName _chemicalName;
    [SerializeField] private string _notPackedProperlyImg;

    public string urlToImgUsed;
    public float _weight = 5f; // in mg
    public string _issueDate = "26/07/25";
    public bool isPackedProperly = true;

    // controls view of image displayed
    ControlEnglargedView _controlEnglargedView;

    // drag and drop mechanics
    private bool dragging = false;
    private Vector3 offset;
    private Vector3 _beforeDragPosition;
    private Rigidbody2D rb;

    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      _controlEnglargedView = GameObject.FindWithTag(Tags.ControlEnglargedView).GetComponent<ControlEnglargedView>();
    }

    private void OnMouseDown()
    {
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

    // methods to rng the medicine's fields, so that it is "wrong"
    public void RngMedWeight(float offset)
    {
      _weight = Random.Range(_weight - offset, _weight + offset);
    }

    // method to set medicine as not packaged properly, so it is "wrong"
    public void SetAsNotPackedProperly()
    {
      isPackedProperly = false;
      urlToImgUsed = _notPackedProperlyImg;

      SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
      Sprite sprite = Resources.Load<Sprite>(urlToImgUsed);
      spriteRenderer.sprite = sprite;
    }


}
