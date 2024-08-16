public interface IStaticDataService
{
    SlotStaticData GetSlotDataById(int id);
    void LoadSlots();
}