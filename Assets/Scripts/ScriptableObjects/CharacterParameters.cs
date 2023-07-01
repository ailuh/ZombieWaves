using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "New Character Parameters", order = 4)]
public class CharacterParameters : ScriptableObject
{
    [SerializeField] 
    private int hpAmount;
    public int HpAmount => hpAmount;
}
