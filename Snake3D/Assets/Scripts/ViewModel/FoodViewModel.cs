using System;
using UnityEngine;
using Assets.Scripts.Model;

namespace Assets.Scripts.ViewModel
{
    class FoodViewModel : IFoodViewModel
    {
        public IFoodModel FoodModel { get; set; }

        public event Action OnBeEated;

        public FoodViewModel(IFoodModel foodModel)
        {
            FoodModel = foodModel;
        }

        public void ActionEated()
        {
            OnBeEated.Invoke();
        }

        public void CreateNewFood()
        {
            GetNewCoordinates();
            GetNewVector3();
            FoodModel.NewFood = GameObject.Instantiate(
                FoodModel.Food, FoodModel.NewLocation, Quaternion.identity);
        }

        private void GetNewCoordinates()
        {
            FoodModel.newValueAxisX = UnityEngine.Random.Range(
                FoodModel.SizeMinusOfPlayAreaX, FoodModel.SizePlusOfPlayAreaX);

            FoodModel.newValueAxisZ = UnityEngine.Random.Range(
                FoodModel.SizeMinusOfPlayAreaZ, FoodModel.SizePlusOfPlayAreaZ);
        }

        private void GetNewVector3()
        {
            var newPosition = FoodModel.NewLocation;
            newPosition.Set(FoodModel.newValueAxisX, 0.25f, FoodModel.newValueAxisZ);
            FoodModel.NewLocation = newPosition;
        }   
    }
}
