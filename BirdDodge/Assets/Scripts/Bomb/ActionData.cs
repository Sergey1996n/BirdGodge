using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Action", fileName = "New Action")]
public class ActionData : ScriptableObject
{
    [Tooltip("Основной спрайт")]
    public Sprite mainSprite;

    [Tooltip("Дополнительный спрайт")]
    public Sprite AdditionalSprite;

    [Tooltip("Скорость Action ")]
    public float speed;

    [Tooltip("Прибавление Action ")]
    public float count;
}
