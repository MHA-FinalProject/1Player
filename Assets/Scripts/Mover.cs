using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{
    [Tooltip("Step size in meters")]
    [SerializeField] float stepSize = 1f;

    [SerializeField] InputAction moveUp = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveDown = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveLeft = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveRight = new InputAction(type: InputActionType.Button);

    [SerializeField] Image miniMap;
    [SerializeField] RectTransform playerMarker;

    Vector2 miniMapSize;
    Vector2 miniMapCenter;

    void Start()
    {
        miniMapSize = miniMap.rectTransform.sizeDelta;
        miniMapCenter = new Vector2(Screen.width - miniMapSize.x / 2f, Screen.height - miniMapSize.y / 2f);
    }

    void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();
    }

    void OnDisable()
    {
        moveUp.Disable();
        moveDown.Disable();
        moveLeft.Disable();
        moveRight.Disable();
    }

    void Update()
    {
        if (moveUp.WasPressedThisFrame())
        {
            transform.position += new Vector3(0, stepSize, 0);
        }
        else if (moveDown.WasPressedThisFrame())
        {
            transform.position += new Vector3(0, -stepSize, 0);
        }
        else if (moveLeft.WasPressedThisFrame())
        {
            transform.position += new Vector3(-stepSize, 0, 0);
        }
        else if (moveRight.WasPressedThisFrame())
        {
            transform.position += new Vector3(stepSize, 0, 0);
        }

        UpdateMiniMap();
    }

    void UpdateMiniMap()
    {
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 miniMapPosition = miniMapCenter + playerPosition;
        playerMarker.anchoredPosition = miniMapPosition;
    }
}
