using System;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    private Text text;  
    private Player player;

    private void Awake()
    {
        text = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
       var (curbull , gunbull ) = player.InterfaceManager.Ammo();
        Convert.ToString(curbull);
        Convert.ToString(gunbull);
        text.text = $"{curbull}/{gunbull}";
    }
}
