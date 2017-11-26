using System;

namespace Dothan.Validation
{
    [Serializable()]
    public class BrokenRulesCollection : Core.ReadOnlyBindingList<BrokenRule>
    {

        /// <summary>
        /// Returns the first <see cref="BrokenRule" /> object
        /// corresponding to the specified property.
        /// </summary>
        /// <remarks>
        /// Code in a business object or UI can also use this value to retrieve
        /// the first broken rule in <see cref="BrokenRulesCollection" /> that corresponds
        /// to a specfic property on the object.
        /// </remarks>
        /// <param name="property">The name of the property affected by the rule.</param>
        /// <returns>
        /// The first BrokenRule object corresponding to the specified property, or null if 
        /// there are no rules defined for the property.
        /// </returns>
        public BrokenRule GetFirstBrokenRule(string property)
        {
            foreach (BrokenRule item in this)
                if (item.Property == property)
                    return item;
            return null;
        }

        internal BrokenRulesCollection()
        {
            // limit creation to this assembly
        }

        internal void Add(RuleMethod rule)
        {
            Remove(rule);
            IsReadOnly = false;
            Add(new BrokenRule(rule));
            IsReadOnly = true;
        }

        internal void Remove(RuleMethod rule)
        {
            // we loop through using a numeric counter because
            // removing items within a foreach isn't reliable
            IsReadOnly = false;
            for (int index = 0; index < Count; index++)
                if (this[index].RuleName == rule.RuleName)
                {
                    RemoveAt(index);
                    break;
                }
            IsReadOnly = true;
        }

        /// <summary>
        /// Returns the text of all broken rule descriptions, each
        /// separated by a <see cref="Environment.NewLine" />.
        /// </summary>
        /// <returns>The text of all broken rule descriptions.</returns>
        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            bool first = true;
            foreach (BrokenRule item in this)
            {
                if (first)
                    first = false;
                else
                    result.Append(Environment.NewLine);
                result.Append(item.Description);
            }
            return result.ToString();
        }
    }
}
