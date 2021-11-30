using UnityEngine;

[CreateAssetMenu(fileName ="level", menuName ="level/numberOfBrick", order=1)]
public class BrickLevel : ScriptableObject
{
    [Header("Play")]
    public int level1;
    public int level2;
    public int level3;
    public int level4;

    [Space(5)]

    [Header("Test")]
    public int test;
}