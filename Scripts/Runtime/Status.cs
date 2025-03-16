using System.Collections.Generic;
using UnityEngine;

namespace ActorStatusManagement
{
    public class Status : IModifiableStatus
    {
        private readonly Dictionary<int, float> _defaultValues = new Dictionary<int, float>();
        private readonly Dictionary<int, float> _modifiedValues = new Dictionary<int, float>();

        public delegate void ModifyStatusCallback(IModifiableStatus status);

        public event ModifyStatusCallback OnModifyStatus;

        public void Calculate()
        {
            foreach (var statusId in _defaultValues)
            {
                _modifiedValues[statusId.Key] = statusId.Value;
            }

            OnModifyStatus?.Invoke(this);
        }

        public void SetDefaultValue(string id, float value)
        {
            var idHash = id.GetHashCode();
            _defaultValues[idHash] = value;
            _modifiedValues[idHash] = value;
        }

        public float GetDefaultValue(string id)
        {
            var idHash = id.GetHashCode();
            if (_defaultValues.TryGetValue(idHash, out var value))
            {
                return value;
            }
            else
            {
                Debug.LogError($"Status with id {id} not found in DefaultValues");
                return 0;
            }
        }

        public float GetModifiedValue(string id)
        {
            var idHash = id.GetHashCode();
            if (_modifiedValues.TryGetValue(idHash, out var value))
            {
                return value;
            }
            else
            {
                Debug.LogError($"Status with id {id} not found in ModifiedValues");
                return 0;
            }
        }

        void IModifiableStatus.ModifyValue(string id, float value)
        {
            var idHash = id.GetHashCode();
            if (_modifiedValues.ContainsKey(idHash))
            {
                _modifiedValues[idHash] = value;
            }
            else
            {
                Debug.LogError($"Status with id {id} not found in ModifiedValues");
            }
        }
    }

    public interface IModifiableStatus
    {
        public float GetDefaultValue(string statusId);
        public float GetModifiedValue(string statusId);
        public void ModifyValue(string statusId, float value);
    }
}
