namespace BreakTimer.State
{
    public class StateContainer
    {
        private int breakDuration;

        public int BreakDuration
        {
            get => breakDuration;
            set
            {
                breakDuration = value;
                NotifyStateChanged();
            }
        }

        private DateTime breakEndTime;

        public DateTime BreakEndTime
        {
            get => breakEndTime;
            set
            {
                breakEndTime = value;
                NotifyStateChanged();
            }
        }

        private TimeSpan breakTimeLeft;

        public TimeSpan BreakTimeLeft
        {
            get => breakTimeLeft;
            set
            {
                breakTimeLeft = value;
                NotifyStateChanged();
            }
        }

        private bool isBreakDurationHours;

        public bool IsBreakDurationHours
        {
            get => isBreakDurationHours;
            set
            {
                isBreakDurationHours = value;
                NotifyStateChanged();
            }
        }

        private bool isWorkDurationHours;

        public bool IsWorkDurationHours
        {
            get => isWorkDurationHours;
            set
            {
                isWorkDurationHours = value;
                NotifyStateChanged();
            }
        }

        private int workDuration;

        public int WorkDuration
        {
            get => workDuration;
            set
            {
                workDuration = value;
                NotifyStateChanged();
            }
        }

        private DateTime workEndTime;

        public DateTime WorkEndTime
        {
            get => workEndTime;
            set
            {
                workEndTime = value;
                NotifyStateChanged();
            }
        }

        private TimeSpan workTimeLeft;

        public TimeSpan WorkTimeLeft
        {
            get => workTimeLeft;
            set
            {
                workTimeLeft = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}