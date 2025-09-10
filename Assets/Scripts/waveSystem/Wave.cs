using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Waves", order = 1)]
public class Wave : ScriptableObject
{
    [field: SerializeField]
    public GameObject[] Enemies { get; private set; }
    [field: SerializeField]
    public float MaxTimeBetweenSpawn { get; private set; }
    [field: SerializeField]
    public float MinTimeBetweenSpawn { get; private set; }
    [field: SerializeField]
    public int NumberToSpawn { get; private set; }

}
