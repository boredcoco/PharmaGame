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

    private void Start()
    {
      _controlEnglargedView = GameObject.FindWithTag(Tags.ControlEnglargedView).GetComponent<ControlEnglargedView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
      _controlEnglargedView.SetMedicineView(this);
    }


}
