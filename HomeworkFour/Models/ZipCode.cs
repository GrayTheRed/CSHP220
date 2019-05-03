using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace HomeworkFour.Models
{
    

    class ZipCode : IDataErrorInfo, INotifyPropertyChanged
    {
        private string zip = string.Empty;
        private string zipError;

        public string ZipError
        {
            get
            {
                return zipError;
            }
            set
            {
                if(zipError != value)
                {
                    zipError = value;
                    OnPropertyChanged("ZipError");
                }
            }
        }

        public string Zip
        {
            get { return zip; }
            set
            {
                if(zip != value)
                {
                    zip = value;
                    OnPropertyChanged("Zip");
                }
            }
        }

        public string Error
        {
            get
            {
                return ZipError;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string usPattern = @"(^[0-9]{5}(?:-[0-9]{4})?$)";
                string caPattern = @"^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$";

                switch (columnName)
                {
                    case "Zip":
                        {
                            Match us = Regex.Match(Zip, usPattern);
                            Match ca = Regex.Match(Zip, caPattern);
                            ZipError = "";
                            if(string.IsNullOrEmpty(Zip) || Zip.Length == 0)
                            {
                                ZipError = "Zip cannot be empty";
                            }
                            if(!us.Success && !ca.Success)
                            {
                                ZipError = "Please enter a valid Zip Code.";
                            }
                            return ZipError;
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
