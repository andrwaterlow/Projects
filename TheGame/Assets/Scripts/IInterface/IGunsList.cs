namespace Assets.Scripts
{
    public interface IGunsList
    {
        public Gun CurrentGun { get; }
        public void Fire();
        public void Reloading();
        public void ChooseWeapon();
    }
}