using System;

namespace Dothan
{
    [Serializable()]
    public abstract class CriteriaBase
    {
        private Type _objectType;

        public Type ObjectType
        {
            get { return _objectType; }
        }

        protected CriteriaBase(Type type)
        {
            _objectType = type;
        }
    }
}
