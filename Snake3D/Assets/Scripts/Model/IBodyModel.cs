using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    interface IBodyModel
    {
        Vector3 PositionOfNewBody { get; set; }
        Vector3 PositionOfLastBody { get; set; }
        GameObject Body { get; set; }
        GameObject Newbody { get; set; }
    }
}
