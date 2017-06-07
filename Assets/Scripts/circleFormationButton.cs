using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleFormationButton : MonoBehaviour
{
    public void setCircleFormation()
    {

        foreach(GameObject henomotia in SpartanArmy.selectedEnomotias)
        {
            if(henomotia.GetComponent<Henomotia>().selected)
            {
                henomotia.GetComponent<Henomotia>().CircleFormation();
            }
        }
    }
}
