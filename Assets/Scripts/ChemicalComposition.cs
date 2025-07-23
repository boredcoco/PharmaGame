public class ChemicalComposition
{
    private string name;
    private string chemicalFormula;

    public ChemicalComposition(string name, string chemFormula){
      this.name =  name;
      this.chemicalFormula = chemFormula;
    }

    public override bool Equals(object obj)
    {
      if (obj.GetType() != this.GetType())
      {
        return false;
      }
      return ((ChemicalComposition) obj).name == name;
    }
}
