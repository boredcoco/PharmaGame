using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ChemicalName _chemicalName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {
      Debug.Log("Clicked");
    }


}
