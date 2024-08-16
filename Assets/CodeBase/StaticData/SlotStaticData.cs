using UnityEngine;

public enum SlotType
{
    Default,
    Wild
}

[CreateAssetMenu(fileName = "SlotData", menuName = "StaticData/Slots")]
public class SlotStaticData : ScriptableObject
{
    public int Id;
    public SlotType SlotType;
    public Sprite Icon;
}
