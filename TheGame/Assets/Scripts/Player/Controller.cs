using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class Controller : IController
{
    private string _axisX = "Horizontal";
    private string _axisZ = "Vertical";
    private string _axisFire = "Fire1";

    public float MoveAxisX()
    {
        return Input.GetAxis(_axisX);
    }

    public float MoveAxisZ()
    {
        return Input.GetAxis(_axisZ);
    }

    public float AxisFire()
    {
        return Input.GetAxis(_axisFire);
    }

    public bool AxisReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int AxisChoose()
    {
        int numberWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Change1");
            return numberWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Change2");
            return numberWeapon = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Change3");
            return numberWeapon = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Change4");
            return numberWeapon = 4;
        }

        return 0;
    }

    public bool AxisJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AxisPause()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}