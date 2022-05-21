namespace AsteroidsGame_HomeWork_
{
    public sealed class PointsController
    {
        private  int point = 0; 

        internal  int Point
        {
            get { return point; }
        }

        public  int PointUp() 
        {
            var pointsForAsteroid = 100;
            return point += pointsForAsteroid;
        }

        public  int PointClear()
        {
            return point = 0;
        }
    }
}
