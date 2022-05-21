using UnityEngine;

namespace Assets.Scripts.Model
{
    internal sealed class FoodModel : IFoodModel
    {
        public float SizePlusOfPlayAreaX { get; set; }
        public float SizeMinusOfPlayAreaX { get; set; }
        public float SizePlusOfPlayAreaZ { get; set; }
        public float SizeMinusOfPlayAreaZ { get; set; }
        public float newValueAxisX { get; set; }
        public float newValueAxisZ { get; set; }

        public Vector3 NewLocation { get; set; }
        public GameObject Food { get; set; }
        public GameObject NewFood { get; set; }

        private GameObject _playArea;

        public FoodModel(GameObject playArea)
        {
            _playArea = playArea;
            Food = (GameObject)Resources.Load("Food");
            GetSizeAreaPlay();
        }

        private void GetSizeAreaPlay()
        {
            var foodSize = 0.5f;
            SizePlusOfPlayAreaX = _playArea.transform.position.x * 2 - foodSize;
            SizeMinusOfPlayAreaX = _playArea.transform.position.x / 2 - foodSize;
            SizePlusOfPlayAreaZ = _playArea.transform.position.z * 2 - foodSize;
            SizeMinusOfPlayAreaZ = _playArea.transform.position.z / 2 - foodSize;
        }
    }
}
