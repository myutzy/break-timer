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
            StateContainer.BreakTimeLeft = new TimeSpan(
                StateContainer.IsBreakDurationHours ? StateContainer.BreakDuration : 0,
                StateContainer.IsBreakDurationHours ? 0 : StateContainer.BreakDuration, 0);

            BreakTimer = new Timer(BreakTimerTick, null, 0, 1000);
        }

        public void StartWork()
        {
            StateContainer.WorkTimeLeft = new TimeSpan(
                StateContainer.IsWorkDurationHours ? StateContainer.WorkDuration : 0,
                StateContainer.IsWorkDurationHours ? 0 : StateContainer.WorkDuration, 0);

            WorkingTimer = new Timer(WorkTimerTick, null, 0, 1000);
        }

        public void StopBreak()
        {
            BreakTimer?.Dispose();
        }

        public void StopWork()
        {
            WorkingTimer?.Dispose();
        }

        private void BreakTimerTick(object? _)
        {
            StateContainer.BreakTimeLeft = StateContainer.BreakTimeLeft.Subtract(new TimeSpan(0, 0, 1));

            if (StateContainer.BreakTimeLeft ==  TimeSpan.Zero)
            {
                BreakTimer?.Dispose();
                NotifyBreakEnded();
            }
        }

        private void NotifyBreakEnded() => OnBreakEnded?.Invoke();
        private void NotifyWorkEnded() => OnWorkEnded?.Invoke();

        private void WorkTimerTick(object? _)
        {
            StateContainer.WorkTimeLeft = StateContainer.WorkTimeLeft.Subtract(new TimeSpan(0, 0, 1));

            if (StateContainer.WorkTimeLeft == TimeSpan.Zero)
            {
                WorkingTimer?.Dispose();
                NotifyWorkEnded();
            }
        }
    }
}
