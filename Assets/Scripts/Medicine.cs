using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ChemicalName _chemicalName;
    [SerializeField] private string _urlToImg;

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
      _controlEnglargedView.SetMedicineImage(_urlToImg);
    }


}
