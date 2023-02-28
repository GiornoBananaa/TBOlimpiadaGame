using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    [SerializeField]

    private Animator _animator;
    private bool _isOpened;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _isOpened = true;
        _animator.SetTrigger("Open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpened && other.GetComponent<PlayerMovementController>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
