using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ToolBox.MVVM.Model
{
    public class ModelBase : INotifyPropertyChanging, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Dictionary<string, string> validationErrors;
        #region Constructeur
        public ModelBase()
        {
            validationErrors = new Dictionary<string, string>();
            this.PropertyChanged += new PropertyChangedEventHandler(ValidateProperty);
        }
        #endregion
        #region Implémentation des Interfaces
        #region INotifyPropertyChanging
        public event PropertyChangingEventHandler PropertyChanging;

        protected void RaisePropertyChanging(string PropertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(PropertyName));
        }

        protected void RaisePropertyChanging<T>(Expression<Func<T>> exp)
        {
            MemberExpression memberExpression = exp.Body as MemberExpression; 
            if (memberExpression != null)
            {
                string PropertyName = memberExpression.Member.Name;
                RaisePropertyChanging(PropertyName);
            }
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> exp)
        {
            //MemberExpression représente l'accès à un champ ou à une propriété.
            MemberExpression memberExpression = exp.Body as MemberExpression; 
            if (memberExpression != null)
            {
                string PropertyName = memberExpression.Member.Name;
                RaisePropertyChanged(PropertyName);
            }
        }

        //Signifie que toutes les propriétés ont changées.
        protected void RaiseAllPropertyChanged()
        {
            RaisePropertyChanged(string.Empty);
        }
        #endregion
        #region IDataErrorInfo
        private string _errors = string.Empty;
        public string Error {
            get { return validationErrors.Values.Aggregate(_errors, (agg, err) => agg + Environment.NewLine + err); }
        }

        public string this[string columnName] {
            get {
                //Obtention de la bonne valeur dans la liste des erreurs de validation
                string validationErreurDeLaPropriete = string.Empty;
                validationErrors.TryGetValue(columnName, out validationErreurDeLaPropriete);
                return validationErreurDeLaPropriete;
            }
        }
        #endregion
        #endregion
        #region ValidateProperty
        private void ValidateProperty(object sender, PropertyChangedEventArgs e)
        {
            //Creation du contexte de validation
            string propertyName = e.PropertyName;
            if (String.IsNullOrEmpty(propertyName))
                return;

            ValidationContext context = new ValidationContext(this, null, null) { MemberName = propertyName, DisplayName = propertyName };
            List<ValidationResult> validationResults = new List<ValidationResult>();
            //Obtention de la valeur de la propriete
            PropertyInfo proprieteInfo = this.GetType().GetProperty(propertyName);            
            if (proprieteInfo == null)
                return;
            
            //utilisation de la réflection pour récupérer la valeur
            object valeurDeLaPropriete = proprieteInfo.GetValue(this, null);

            //Application des règles de validation
            Validator.TryValidateProperty(valeurDeLaPropriete, context, validationResults);

            //Construction du message d'erreur
            string errors = validationResults.Aggregate<ValidationResult, string>(string.Empty, (s, vr) => s += Environment.NewLine + vr.ErrorMessage);
            if (!String.IsNullOrEmpty(errors))
            {
                errors = String.Format("[{0}]:{1}", propertyName, errors);
                validationErrors[propertyName] = errors;
            }
            else
            {
                validationErrors.Remove(propertyName);
            }
        }
        #endregion
    }
}

