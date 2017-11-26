using System;
using System.Collections.Generic;

namespace Dothan.Validation
{
     /// </summary>
    [Serializable()]
    public class ValidationRules
    {
        private BrokenRulesCollection _brokenRules;
        [NonSerialized()]
        private object _target;
        [NonSerialized()]
        private Dictionary<string, List<RuleMethod>> _rulesList;

        internal ValidationRules(object businessObject)
        {
            SetTarget(businessObject);
        }

        internal void SetTarget(object businessObject)
        {
            _target = businessObject;
        }

        private BrokenRulesCollection BrokenRulesList
        {
            get
            {
                if (_brokenRules == null)
                    _brokenRules = new BrokenRulesCollection();
                return _brokenRules;
            }
        }

        private Dictionary<string, List<RuleMethod>> RulesList
        {
            get
            {
                if (_rulesList == null)
                    _rulesList = new Dictionary<string, List<RuleMethod>>();
                return _rulesList;
            }
        }

        #region Adding Rules

      
        private List<RuleMethod> GetRulesForProperty(string propertyName)
        {
            // get the list (if any) from the dictionary
            List<RuleMethod> list = null;
            if (RulesList.ContainsKey(propertyName))
                list = RulesList[propertyName];
            if (list == null)
            {
                // there is no list for this name - create one
                list = new List<RuleMethod>();
                RulesList.Add(propertyName, list);
            }
            return list;
        }

    
        public void AddRule(RuleHandler handler, string propertyName)
        {
            // get the list of rules for the property
            List<RuleMethod> list = GetRulesForProperty(propertyName);

            // we have the list, add our new rule
            list.Add(new RuleMethod(_target, handler, propertyName));
        }

 
        public void AddRule(RuleHandler handler, RuleArgs args)
        {
            // get the list of rules for the property
            List<RuleMethod> list = GetRulesForProperty(args.PropertyName);

            // we have the list, add our new rule
            list.Add(new RuleMethod(_target, handler, args));
        }

        #endregion

        #region Checking Rules

        /// <summary>
        /// Invokes all rule methods associated with
        /// the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property to validate.</param>
        public void CheckRules(string propertyName)
        {
            List<RuleMethod> list;
            // get the list of rules to check
            if (RulesList.ContainsKey(propertyName))
            {
                list = RulesList[propertyName];
                if (list == null)
                    return;

                // now check the rules
                foreach (RuleMethod rule in list)
                {
                    if (rule.Invoke())
                        BrokenRulesList.Remove(rule);
                    else
                        BrokenRulesList.Add(rule);
                }
            }
        }


        public void CheckRules()
        {
            // get the rules for each rule name
            foreach (KeyValuePair<string, List<RuleMethod>> de in RulesList)
            {
                List<RuleMethod> list = de.Value;

                // now check the rules
                foreach (RuleMethod rule in list)
                {
                    if (rule.Invoke())
                        BrokenRulesList.Remove(rule);
                    else
                        BrokenRulesList.Add(rule);
                }
            }
        }

        #endregion

        #region Status Retrieval


        internal bool IsValid
        {
            get { return BrokenRulesList.Count == 0; }
        }


        public BrokenRulesCollection GetBrokenRules()
        {
            return BrokenRulesList;
        }

        #endregion
    }
}
