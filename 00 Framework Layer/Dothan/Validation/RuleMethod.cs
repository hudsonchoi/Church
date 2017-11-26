using System;
using System.Collections.Generic;
using System.Text;

namespace Dothan.Validation
{
    internal class RuleMethod
    {
        private object _target;
        private RuleHandler _handler;
        private string _ruleName = String.Empty;
        private RuleArgs _args;

    
        public override string ToString()
        {
            return _ruleName;
        }

        public string RuleName
        {
            get { return _ruleName; }
        }

        public RuleArgs RuleArgs
        {
            get { return _args; }
        }

        public RuleMethod(object target, RuleHandler handler, string propertyName)
        {
            _target = target;
            _handler = handler;
            _args = new RuleArgs(propertyName);
            _ruleName = _handler.Method.Name + "!" + _args.ToString();
        }

        
        public RuleMethod(object target, RuleHandler handler, RuleArgs args)
        {
            _target = target;
            _handler = handler;
            _args = args;
            _ruleName = _handler.Method.Name + "!" + _args.ToString();
        }

       
        public bool Invoke()
        {
            return _handler.Invoke(_target, _args);
        }
    }
}
