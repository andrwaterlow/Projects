namespace Assets.Scripts
{
    public sealed class Soldier : ITakeDamage, IMovement , IGunsList, IManagerWindow
    {
        private readonly ITakeDamage _takeDamageImplementation;
        private readonly IMovement _movementImplementation;
        private readonly IGunsList _gunsListImplementation;
        private readonly IManagerWindow _managerWindowImplementation;

        public Gun CurrentGun => throw new System.NotImplementedException();

        public Soldier(ITakeDamage takeDamageImplementation,
            IMovement movementImplementation, IGunsList gunsListImplementation, 
                IManagerWindow managerWindowImplementation)
        {
            _takeDamageImplementation = takeDamageImplementation;
            _movementImplementation = movementImplementation;
            _gunsListImplementation = gunsListImplementation;
            _managerWindowImplementation = managerWindowImplementation;
        }

        public void ChooseWeapon()
        {
            _gunsListImplementation.ChooseWeapon();
        }

        public void Fire()
        {
            _gunsListImplementation.Fire();
        }

        public void Jump()
        {
            _movementImplementation.Jump();
        }

        public void LookAround()
        {
            _movementImplementation.LookAround();
        }

        public void Move()
        {
            _movementImplementation.Move();
        }   

        public void Reloading()
        {
            _gunsListImplementation.Reloading();
        }

        public void TakeDamage(float damage)
        {
            _takeDamageImplementation.TakeDamage(damage);
        }

        public bool CheckLiveStatus()
        {
            return _takeDamageImplementation.CheckLiveStatus();
        }

        public void Paused()
        {
            _managerWindowImplementation.Paused();
        }
    }
}
