using UnityEngine;

namespace Assets.Scripts.Model
{
    interface IFoodModel
    {
        Vector3 NewLocation { get; set; }
        GameObject Food { get; set; }
        GameObject NewFood { get; set; }

        float SizePlusOfPlayAreaX { get; set; }
        float SizeMinusOfPlayAreaX { get; set; }
        float SizePlusOfPlayAreaZ { get; set; }
        float SizeMinusOfPlayAreaZ { get; set; }

        float newValueAxisX { get; set; }
        float newValueAxisZ { get; set; }
    }
}
