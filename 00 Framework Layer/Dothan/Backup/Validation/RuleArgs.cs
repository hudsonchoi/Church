using System;


namespace Dothan.Validation
{
    public class RuleArgs
    {
        private string _propertyName;
        private string _description;

        public string PropertyName
        {
            get { return _propertyName; }
        }

     
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

       
        public RuleArgs(string propertyName)
        {
            _propertyName = propertyName;
        }

      
        public override string ToString()
        {
            return _propertyName;
        }
    }
}
