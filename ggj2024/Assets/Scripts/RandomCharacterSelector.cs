   using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCharacterSelector : MonoBehaviour
{
   public static List<int> SelectJuris()
   {
      List<int> Selected = new List<int>();
      
      for (var i = 0; i < 3; i++)
      {
         int randomValue = Random.Range(0, 10);
         if (!Selected.Contains(randomValue))
         {
            Selected.Add(randomValue);
         }
         else
         {
            randomValue = Random.Range(0, 10);
            while (Selected.Contains(randomValue))
            {
               randomValue = Random.Range(0, 10);
            }
            Selected.Add(randomValue);
         }
      }

      return Selected;
   }
}
