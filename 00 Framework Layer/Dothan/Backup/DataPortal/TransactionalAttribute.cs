using System;

namespace Dothan
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class TransactionalAttribute : Attribute
    {
        private TransactionalTypes _type;

        public TransactionalAttribute()
        {
            _type = TransactionalTypes.EnterpriseServices;
        }

        public TransactionalAttribute(TransactionalTypes transactionType)
        {
            _type = transactionType;
        }

        public TransactionalTypes TransactionType
        {
            get { return _type; }
        }
    }
}
