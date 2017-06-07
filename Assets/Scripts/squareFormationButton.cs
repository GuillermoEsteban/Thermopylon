using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareFormationButton : MonoBehaviour
{
    public void setSquareFormation()
    {

        foreach (GameObject henomotia in SpartanArmy.selectedEnomotias)
        {
            if (henomotia.GetComponent<Henomotia>().selected)
            {
                henomotia.GetComponent<Henomotia>().SquareFormation();
            }
        }
    }
}