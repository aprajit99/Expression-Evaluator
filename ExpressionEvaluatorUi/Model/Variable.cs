using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExpressionEvaluatorUi.Model
{
    public class Variable:IVariable,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _type;
        private string _description;
        private object _value;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Type
        {
            get { return _type; }
            set 
            { 
                _type = value;
                OnPropertyChanged((nameof(Type)));
            }
        }
        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value; 
                OnPropertyChanged(nameof(Description));
            }
        }
        public object Value
        {
            get { return _value; }
            set 
            { 
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
