using UnityEngine;

namespace Assets.Scripts.Model
{
    internal sealed class BodyModel : IBodyModel
    {
        public GameObject Body { get; set; }
        public GameObject Newbody { get; set; }
        public Vector3 PositionOfNewBody { get; set; }
        public Vector3 PositionOfLastBody { get; set; }

        public BodyModel()
        {
            Body = (GameObject)Resources.Load("Body");
            PositionOfNewBody = new Vector3(0f, 0f, 0f);
            PositionOfLastBody = new Vector3(0f, 0f, 0f);
        }
    }
}
