using Godot;

namespace Game.Systems.Trigger.Actions
{
    public abstract partial class BaseTriggerAction : Node
    {
        [Export] private Timer _timer;

        public void Trigger(TriggerData data)
        {
            _timer.Start();
            _timer.OneShot = true;

            _timer.Timeout += () =>{
                OnTrigger(data);
                _timer.Stop();
            };
        }

        protected abstract void OnTrigger(TriggerData data);
    }
}
