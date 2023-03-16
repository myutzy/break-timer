using Blazored.LocalStorage;
using BreakTimer.State;

namespace BreakTimer.Services
{
    public class TimeService
    {
        StateContainer StateContainer;
        Timer? BreakTimer;
        Timer? WorkingTimer;

        public event Action? OnBreakEnded;
        public event Action? OnWorkEnded;

        public TimeService(StateContainer stateContainer)
        {
            StateContainer = stateContainer;
        }

        public void StartBreak()
        {
            StateContainer.BreakEndTime = DateTime.Now + new TimeSpan(
                StateContainer.IsBreakDurationHours ? StateContainer.BreakDuration : 0,
                StateContainer.IsBreakDurationHours ? 0 : StateContainer.BreakDuration, 0);

            BreakTimer = new Timer(BreakTimerTick, null, 0, 1000);
        }

        public void StartWork()
        {
            StateContainer.WorkEndTime = DateTime.Now + new TimeSpan(
                StateContainer.IsWorkDurationHours ? StateContainer.WorkDuration : 0,
                StateContainer.IsWorkDurationHours ? 0 : StateContainer.WorkDuration, 0);

            WorkingTimer = new Timer(WorkTimerTick, null, 0, 1000);
        }

        public void StopBreak()
        {
            BreakTimer?.Dispose();
            StateContainer.BreakEndTime = default;
        }

        public void StopWork()
        {
            WorkingTimer?.Dispose();
            StateContainer.WorkEndTime = default;
        }

        private void BreakTimerTick(object? _)
        {
            StateContainer.BreakTimeLeft = StateContainer.BreakEndTime - DateTime.Now;

            if (StateContainer.BreakTimeLeft <=  TimeSpan.Zero)
            {
                BreakTimer?.Dispose();
                NotifyBreakEnded();
            }
        }

        private void NotifyBreakEnded() => OnBreakEnded?.Invoke();
        private void NotifyWorkEnded() => OnWorkEnded?.Invoke();

        private void WorkTimerTick(object? _)
        {
            StateContainer.WorkTimeLeft = StateContainer.WorkEndTime - DateTime.Now;

            if (StateContainer.WorkTimeLeft <= TimeSpan.Zero)
            {
                WorkingTimer?.Dispose();
                NotifyWorkEnded();
            }
        }
    }
}
