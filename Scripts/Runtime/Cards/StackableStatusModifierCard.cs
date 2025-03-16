using UnityEngine;

namespace ActorStatusManagement
{
    public abstract class StackableStatusModifierCard : ScriptableObject
    {
        public string Id;

        public Sprite Icon;

        public abstract StackableStatusModifier CreateModifierInstance();
    }
}
