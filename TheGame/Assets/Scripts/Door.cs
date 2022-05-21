using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private bool _lock;
    [SerializeField] private bool _needKey;

    private Animator _animator;
    private float _waitingtime = 1.5f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void UnlockDoor()
    {
        _lock = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player) && !_lock)
        {
            if (!_needKey)
            {
                _animator.SetBool("Opened", true);
                StartCoroutine(StopAnimation());
            }
            else
            {
                if (player.key)
                {
                    _animator.SetBool("Opened", true);
                    StartCoroutine(StopAnimation());
                } 
            } 
        }
    }

    private IEnumerator StopAnimation()
    {
         yield return new WaitForSeconds(_waitingtime);
        _animator.enabled = false;
    }
}
