using System;

namespace ActorStatusManagement
{
    public abstract class StatusModifier : IDisposable
    {
        private readonly Status _status;

        public StatusModifier(Status status)
        {
            _status = status;
            _status.OnModifyStatus += OnModifyStatusValue;
        }

        public virtual void Dispose()
        {
            _status.OnModifyStatus -= OnModifyStatusValue;
        }

        protected abstract void OnModifyStatusValue(IModifiableStatus status);
    }
}
