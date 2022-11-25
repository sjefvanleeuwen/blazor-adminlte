using System;

namespace Blazor.AdminLte
{
    public class InputState
    {
        private string _errorMessage;
        private Color? _originalBorderColor;
        private Color? _originalIconBgColor;
        private Color _borderColor;
        private Color _iconBgColor;

        public string Value { get; set; }
        public string Identifier { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                if (_originalBorderColor == null) _originalBorderColor = value;
            }
        }
        public Color IconBgColor
        {
            get { return _iconBgColor; }
            set
            {
                _iconBgColor = value;
                if (_originalIconBgColor == null) _originalIconBgColor = value;
            }
        }
        public string IconPointer { get; set; }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                _originalBorderColor ??= BorderColor;
                _originalIconBgColor ??= IconBgColor;

                if (!string.IsNullOrEmpty(value))
                {
                    BorderColor = Color.Danger;
                    IconBgColor = Color.Danger;
                }
                else
                {
                    BorderColor = _originalBorderColor.Value;
                    IconBgColor = _originalIconBgColor.Value;
                }
            }
        }

        public bool Validate(Func<string, bool> validator, string errorMessage)
        {
            var isValid = validator(Value);
            ErrorMessage = isValid ? null : errorMessage;
            return isValid;
        }
        
        public void Validate(string[] errors)
        {
            if (errors != null && errors.Length > 0)
            {
                ErrorMessage = errors[0];
            }
            else
            {
                ErrorMessage = null;
            }

        }
    }
}
