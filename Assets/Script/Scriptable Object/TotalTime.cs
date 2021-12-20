using UnityEngine;


[CreateAssetMenu(fileName ="Level", menuName ="Level/Totaltime", order=1)]
public class TotalTime : ScriptableObject
{
    [Header("Total level time")]
    public int level1;
    public int level2;
    public int level3;
}
