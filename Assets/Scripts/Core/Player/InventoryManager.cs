using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private float _transformationCooldown;
    [SerializeField] private GameObject[] _tools;
    [SerializeField] private GameObject[] _toolsUIPanels;
    [SerializeField] private Color _activationColor;
    [SerializeField] private Color _DiactivateColor;
    [SerializeField] private PlayerMovementController _playerMovementController;
    [SerializeField] private ObserveArtifact _observeArtifact;

    private int _activatedTransformation;
    private bool[] _availableTransformations;


    void Start()
    {
        _activatedTransformation = 0;

        _availableTransformations = new bool[_tools.Length];

        for (int i = 1; i< _tools.Length; i++)
        {
            _availableTransformations[i] = false;
        }
        _availableTransformations[0] = true;
    }

    void Update()
    {
        _transformationCooldown += Time.deltaTime;
        int number;
        if (int.TryParse(Input.inputString, out number) && number > 0 && number < _tools.Length+1 && _transformationCooldown > 0.5f)
        {
            number--;

            if(_activatedTransformation != number && !_observeArtifact.IsObservation) Activate(number);

            _transformationCooldown = 0;
        }
    }

    public void Add(int tool)
    {
        _availableTransformations[tool] = true;
        _toolsUIPanels[tool].SetActive(true);
    }

    public void Activate(int tool)
    {
        if (_availableTransformations[tool] && tool != _activatedTransformation)
        {
            _tools[_activatedTransformation].GetComponent<Animator>().SetTrigger("Remove");

            _toolsUIPanels[_activatedTransformation].GetComponent<Image>().color = _DiactivateColor;

            _tools[tool].SetActive(true);
            _tools[tool].GetComponent<Animator>().SetTrigger("Take");
            _activatedTransformation = tool;

            _toolsUIPanels[_activatedTransformation].GetComponent<Image>().color = _activationColor;

            if (tool == 1)
                _playerMovementController.PistolEquiped(true);
            else
                _playerMovementController.PistolEquiped(false);
        }
    }
}
