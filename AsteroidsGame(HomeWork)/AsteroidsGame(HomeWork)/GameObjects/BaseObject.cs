using System.Drawing;

namespace AsteroidsGame_HomeWork_
{
   public abstract class BaseObject : ICollision
    {
        internal Point CurrentPosition; 
        internal Point Dir; 
        internal Size SizeOfObject; 

        public Point pos
        {
            get { return CurrentPosition; }
        }

        protected BaseObject(Point pos, Point dir, Size size)
        {
            CurrentPosition = pos;
            Dir = dir;
            SizeOfObject = size;
        }

        public Rectangle Rect  => new Rectangle(CurrentPosition, SizeOfObject);

        public abstract void Draw(); 

        public abstract void Update(); 
    }
}
