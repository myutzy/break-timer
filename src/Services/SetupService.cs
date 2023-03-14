using Blazored.LocalStorage;
using BreakTimer.State;

namespace BreakTimer.Services
{
    public class SetupService
    {
        readonly ISyncLocalStorageService LocalStorage;
        StateContainer StateContainer;

        public SetupService(ISyncLocalStorageService localStorage, StateContainer stateContainer)
        {
            LocalStorage = localStorage;
            StateContainer = stateContainer;
            Initialize();
        }

        public void Initialize()
        {
            if (LocalStorage.ContainKey("BreakDuration") == false) LocalStorage.SetItem("BreakDuration", 5);
            StateContainer.BreakDuration = LocalStorage.GetItem<int>("BreakDuration");

            if (LocalStorage.ContainKey("IsBreakDurationHours") == false) LocalStorage.SetItem("IsBreakDurationHours", false);
            StateContainer.IsBreakDurationHours = LocalStorage.GetItem<bool>("IsBreakDurationHours");

            if (LocalStorage.ContainKey("IsWorkDurationHours") == false) LocalStorage.SetItem("IsWorkDurationHours", false);
            StateContainer.IsWorkDurationHours = LocalStorage.GetItem<bool>("IsWorkDurationHours");

            if (LocalStorage.ContainKey("WorkDuration") == false) LocalStorage.SetItem("WorkDuration", 25);
            StateContainer.WorkDuration = LocalStorage.GetItem<int>("WorkDuration");
        }

        public void Update()
        {
            LocalStorage.SetItem("BreakDuration", StateContainer.BreakDuration);
            LocalStorage.SetItem("IsBreakDurationHours", StateContainer.IsBreakDurationHours);
            LocalStorage.SetItem("IsWorkDurationHours", StateContainer.IsWorkDurationHours);
            LocalStorage.SetItem("WorkDuration", StateContainer.WorkDuration);
        }
    }
}
