using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calen.Prp.WPF.ViewModel;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace Calen.Prp.WPF.View
{
    public class DialogHelper : IDialogHelper
    {
        public static readonly DependencyProperty DialogContainerProperty = DependencyProperty.RegisterAttached("DialogContainer", typeof(ContentDialogContainer), typeof(DialogHelper));
        public static readonly DependencyProperty RegisterProperty = DependencyProperty.RegisterAttached(
            "Register", typeof(object), typeof(DialogHelper), new PropertyMetadata(default(object), RegisterPropertyChangedCallback));
        private static readonly IDictionary<object, DependencyObject> ContextRegistrationIndex = new Dictionary<object, DependencyObject>();
        private static void RegisterPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyPropertyChangedEventArgs.OldValue != null)
                ContextRegistrationIndex.Remove(dependencyPropertyChangedEventArgs.OldValue);

            if (dependencyPropertyChangedEventArgs.NewValue != null)
                ContextRegistrationIndex[dependencyPropertyChangedEventArgs.NewValue] = dependencyObject;
        }
        public static void SetRegister(DependencyObject element, object context)
        {
            element.SetValue(RegisterProperty, context);
        }

        public static object GetRegister(DependencyObject element)
        {
            return element.GetValue(RegisterProperty);
        }



        public static ContentDialogContainer GetDialogContainer(DependencyObject obj)
        {
            return (ContentDialogContainer)obj.GetValue(DialogContainerProperty);
        }
        public static void SetContentDialogContainer(DependencyObject obj,ContentDialogContainer container)
        {
            obj.SetValue(DialogContainerProperty, container);
        }

        public void ShowContentDialog(object context, object Content)
        {
            ContentDialogContainer cdc = GetDialogContainer(context);
            cdc.Content = context;
            cdc.Show();
        }
        public void RemoveContentDialog(object context)
        {
            ContentDialogContainer cdc = GetDialogContainer(context);
            cdc.Hide();
            cdc.Content = null;
        }

        internal static bool IsRegistered(object context)
        {
            if (context == null) throw new ArgumentNullException("context");

            return ContextRegistrationIndex.ContainsKey(context);
        }
        internal static DependencyObject GetAssociation(object context)
        {
            if (context == null) throw new ArgumentNullException("context");

            return ContextRegistrationIndex[context];
        }


        private static ContentDialogContainer  GetDialogContainer(object context)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (!IsRegistered(context))
                throw new InvalidOperationException(
                    "Context is not registered. Consider using DialogParticipation.Register in XAML to bind in the DataContext.");

            var association = GetAssociation(context);
            var window = Window.GetWindow(association) as MetroWindow;
            if (window == null)
                throw new InvalidOperationException("Control is not inside a MetroWindow.");

            ContentDialogContainer cdc = GetDialogContainer(window);
          
            return cdc;
        }

       
    }
}
