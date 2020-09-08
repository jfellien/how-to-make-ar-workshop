using UnityEngine;

namespace Variables
{
    [CreateAssetMenu(menuName = "Variables/Bool")]
    public class BoolVariable : ScriptableObject
    {
        [SerializeField]
        private bool _internalValue;

        public bool Value => _internalValue;

        public void Set(bool v)
        {
            _internalValue = v;
        }

        public void Set(BoolVariable v)
        {
            _internalValue = v._internalValue;
        }

        public void Reverse()
        {
            _internalValue = !_internalValue;
        }

        public bool Compare(bool v)
        {
            return v == _internalValue;
        }

        public bool Compare(BoolVariable v)
        {
            return _internalValue == v._internalValue;
        }

        public bool IsTrue()
        {
            return _internalValue == true;
        }
        
        public bool IsFalse()
        {
            return _internalValue == false;
        }
    }
}