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
          ChemicalName.Acetylcysteine,
          new ChemicalComposition("Acetylcysteine", " C5H9NO3S")
        );
        dic.Add(
          ChemicalName.AmbroxylHydroxide,
          new ChemicalComposition("Ambroxyl Hydroxide", "C13H18Br2N2O·HCl")
        );
        dic.Add(
          ChemicalName.AmbroxylHydroxide,
          new ChemicalComposition("Amylmetacresol", "C12H18O")
        );
        dic.Add(
          ChemicalName.Monochloramine,
          new ChemicalComposition("Monochloramine", "NH2Cl")
        );
        dic.Add(
          ChemicalName.MagnesiumHydroxide,
          new ChemicalComposition("Magnesium Hydroxide", "Mg(OH)2")
        );
      }
}
