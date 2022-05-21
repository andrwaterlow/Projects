using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{ 
    private Player player;
    private Text Text;

    private void Awake()
    {
        Text = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Debug.Log(player);
        Debug.Log(player.InterfaceManager);
        var HP = player.InterfaceManager.HP();
        var Armour = player.InterfaceManager.Armour();
        Text.text = $" HP {HP}\n Armour {Armour}";
    }
}
