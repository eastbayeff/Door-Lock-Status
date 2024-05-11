using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<int, bool> _buttonStatuses = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void AddButton(Button button)
    {
        if (_buttonStatuses.ContainsKey(button.Id))
            button.Status = _buttonStatuses[button.Id];
        else
            _buttonStatuses.Add(button.Id, button.Status);
    }
}
