using System.Collections.Generic;

namespace AsteroidsGame_HomeWork_
{
    public sealed class BulletController : IControlAction
    {
        private List<BaseObject> bullets;

        public BulletController(List<BaseObject> bullets)
        {
            this.bullets = bullets;
        }

        private bool CheckBulletsOnScreen(BaseObject bullet)
        {
            if (bullet.CurrentPosition.Y < 0 )
            {
                return true;
            }

            return false;
        }

        public void Death(BaseObject baseObject)
        {
            if (CheckBulletsOnScreen(baseObject))
            {
                var bullet = (Bullet)baseObject;
                var index = bullets.IndexOf(bullet);
                bullets.RemoveAt(index);
            }
        }
    }
}
