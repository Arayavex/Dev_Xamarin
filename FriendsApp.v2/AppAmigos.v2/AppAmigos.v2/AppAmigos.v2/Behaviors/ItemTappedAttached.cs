using System.Windows.Input;
using Xamarin.Forms;

namespace AppAmigos.v2.Behaviors
{

    //Clase compleja para declarar el comando que se desee en cada uno de los controles
    public class ItemTappedAttached
    {

        public static readonly BindableProperty CommandProperty =
            BindableProperty.CreateAttached(
                propertyName: "Command",
                returnType: typeof(ICommand),
                declaringType: typeof(ListView),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                validateValue: null,
                propertyChanged: OnItemTappedChanged);

        //Metodo de tipo ICommand
        public static ICommand GetItemTapped(BindableObject bindable)
        {
            return (ICommand)bindable.GetValue(CommandProperty);
        }


        public static void SetItemTapped(BindableObject bindable,
            ICommand value)
        {
            bindable.SetValue(CommandProperty, value);
        }

        private static void OnItemTappedChanged(BindableObject bindable,
            object oldValue, object newValue)
        {
            var control = bindable as ListView;
            if (control != null)
            {
                control.ItemTapped += OnItemTapped;
            }
        }

        private static void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var control = sender as ListView;
            var command = GetItemTapped(control);

            if (command != null && command.CanExecute(e.Item))
            {
                command.Execute(e.Item);
            }
        }

    }
}
