using System.Linq;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private SlotStaticData[] _slotsDatas;

    public void LoadSlots() =>
        _slotsDatas = Resources.LoadAll<SlotStaticData>(AssetPath.SlotsStaticDataPath);

    public SlotStaticData GetSlotDataById(int id) =>
        _slotsDatas.First((slot) => slot.Id == id);
}
