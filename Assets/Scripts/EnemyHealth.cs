using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override string getHealthText()
    {
        if (!isAlive())
        {
            return gameObject.name + "\n" + "DEAD";
        }
        return gameObject.name + "\n" + health.ToString();
    }

}
