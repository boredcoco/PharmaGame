using System;
using System.Collections.Generic;

public class ChemGlossary
{
      Dictionary<ChemicalName, ChemicalComposition> dic;

      private ChemGlossary()
      {
        dic = new Dictionary<ChemicalName, ChemicalComposition>();
        init();
      }

      private void init()
      {
        dic.Add(
          ChemicalName.AmbroxylHydroxide,
          new ChemicalComposition("Ambroxyl Hydroxide", "C13H18Br2N2O·HCl")
        );
        dic.Add(
          ChemicalName.Monochloramine,
          new ChemicalComposition("Monochloramine", "NH2Cl")
        );
      }
}
