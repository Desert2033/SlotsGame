using UnityEngine;

public class SpinService : ISpinService
{
    private ISlotsContainerService _slotsContainerService;
    private ICombinationService _combinationService;
    private SlotMachine _slotMachine;

    public SpinService(ISlotsContainerService slotsContainerService, ICombinationService combinationService)
    {
        _slotsContainerService = slotsContainerService;
        _combinationService = combinationService;
    }

    public void InitSlots(SlotMachine slotMachine)
    {
        _slotMachine = slotMachine;

        _slotMachine.FillSlots(_slotsContainerService.SlotsRespin());
    }

    public void Spin()
    {
        _slotMachine.SpinAnimation(_slotsContainerService.SlotsRespin());

        Slot[][] winSlots = _combinationService.CalculateWinSlots(_slotMachine.SlotsView);

        _slotMachine.SetWinSlots(winSlots);
    }
}
