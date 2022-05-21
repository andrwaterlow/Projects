using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    private Soldier _soldier;

    [SerializeField] private Transform MineStartPosition;
    [SerializeField] private Transform GrenadeStartPosition;
    [SerializeField] private Transform BulletStartPosition;
    [SerializeField] private Transform MissleStartPosition;
    [SerializeField] private Transform RayCastStartPosition;
    [SerializeField] private Transform CenterScreen;

    [SerializeField] private AudioClip Shot;
    [SerializeField] private AudioClip ShotBazooka;
    [SerializeField] private AudioClip Explode;

    public Health Health;
    public Armour Armour;
    public IController Controller;
    public IInterfaceManager InterfaceManager;
    public IItemManager ItemManager;
    private ManagerWindow _managerWindow;
    private ITakeDamage _damage;
    private ILookAround _lookAround;
    private IMovement _movement;
    private IGunsList _gunsList;

    public GameObject _camera;
    public Paused Paused;
    private AudioSource _audioSource;
    private Animator _animator;

    public bool IsAlive { get; private set; } = true;
    public bool key = false;
    private float Speed = 20;
    private float Sensevity = 9;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        Initialeze();
    }

    private void Initialeze()
    {
        Camera camera = GetComponentInChildren<Camera>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        CharacterController characterController = GetComponent<CharacterController>();
        Health = new Health(100f,100f);
        Armour = new Armour(100f, 100f);
        var riffle = GetComponentInChildren<Riffle>();
        var bazooka = GetComponentInChildren<Bazooka>(); 
        var grenade = GetComponentInChildren<Grenades>();
        var mine = GetComponentInChildren<Mines>();
        riffle.SetStartPositionAndCenterScreen(BulletStartPosition, CenterScreen);
        bazooka.SetStartPositionAndCenterScreen(MissleStartPosition, CenterScreen);
        grenade.SetStartPositionAndCenterScreen(GrenadeStartPosition, CenterScreen);
        mine.SetStartPositionAndCenterScreen(MineStartPosition, CenterScreen);
        _damage = new Damage(Health, Armour);
        Controller = new Controller(); 
        _lookAround = new LookAround(camera, rigidbody, Sensevity, this);
        _movement = new Movement(Controller, Speed, this, characterController, _lookAround);
        _gunsList = new GunsList(Controller, riffle, bazooka, grenade, mine);
        InterfaceManager = new InterfaceManager(Health, Armour, (GunsList)_gunsList);
        ItemManager = new ItemManager(Health, Armour, (GunsList)_gunsList);
        _managerWindow = new ManagerWindow(Controller);
        _managerWindow.SetWindow(Paused);
        _soldier = new Soldier(_damage, _movement, _gunsList, _managerWindow);
    }

    void Update()
    {
        if (IsAlive)
        {
            _soldier.ChooseWeapon();
            _soldier.Fire();
            _soldier.Jump();
            _soldier.LookAround();
            _soldier.Move();
            _soldier.Reloading();
            _soldier.Paused();
        }
    }

    public void KeyUp()
    {
        key = true;
    }

    private void PlayShot()
    {
        _audioSource.PlayOneShot(Shot);
    }

    private void PlayShotBazooka()
    {
        _audioSource.PlayOneShot(ShotBazooka);
    }

    private void PlayExplode()
    {
        _audioSource.PlayOneShot(Explode);
    }

    public void MakeDamage(float damage)
    {
        _soldier.TakeDamage(damage);
        IsAlive = _damage.CheckLiveStatus();
        DeathOrLive();
    }

    private void DeathOrLive()
    {
        if (!IsAlive)
        {
            _animator.SetTrigger("Death");
        }
    }
}


