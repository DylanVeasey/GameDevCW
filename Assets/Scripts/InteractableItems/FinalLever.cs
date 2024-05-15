using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLever : Lever
{
    public List<ItemHolder> LockedLeverControllers;
    private int numFilled = 0;

   override
   public void Interact()
   {
        foreach( ItemHolder LockedLeverController in LockedLeverControllers)
        {
            if(LockedLeverController.getState() != -1)
            {
                numFilled++;
            }
        }   
        if(numFilled == 3)
        {
            foreach (Door door in doors)
            {
                door.Interact();
            }
            ToggleLever();
        }
   }

}
