using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deltaFormationButton : MonoBehaviour
{
    public void setDeltaFormation()
    {

        foreach (GameObject henomotia in SpartanArmy.selectedEnomotias)
        {
            if (henomotia.GetComponent<Henomotia>().selected)
            {
                henomotia.GetComponent<Henomotia>().DeltaFormation();
            }
        }
    }
}
