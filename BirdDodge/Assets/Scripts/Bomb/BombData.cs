using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Bomb", fileName = "New Bomb")]
public class BombData : ScriptableObject
{
    [Tooltip("Основной спрайт")]
    public Sprite mainSprite;

    [Tooltip("Скорость бомбы ")]
    public float speed;
}
