using Gtk;
using System;

namespace GTKToolboxComponents
{
    // Clase para crear un botón
    public class CustomButton : Button
    {
        public CustomButton(string labelText, EventHandler onClick)
        {
            this.Label = labelText;
            this.Clicked += onClick;
        }
    }

    // Clase para crear una etiqueta (Label)
    public class CustomLabel : Label
    {
        public CustomLabel(string text)
        {
            this.Text = text;
        }
    }

    // Clase para crear un cuadro de texto (TextBox)
    public class CustomEntry : Entry
    {
        public CustomEntry(bool isPassword = false)
        {
            if (isPassword)
            {
                this.Visibility = false;  // Ocultar texto si es un campo de contraseña
            }
        }
    }

    // Clase para crear una caja de verificación (CheckBox)
    public class CustomCheckButton : CheckButton
    {
        public CustomCheckButton(string labelText)
        {
            this.Label = labelText;
        }
    }

    // Clase para crear un cuadro combinado (ComboBox)
    public class CustomComboBox : ComboBoxText
    {
        public CustomComboBox(string[] items)
        {
            foreach (var item in items)
            {
                this.AppendText(item);
            }
        }
    }

    // Clase para crear una barra de progreso (ProgressBar)
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            this.Fraction = 0.0; // Inicialmente vacío
        }

        public void SetProgress(double fraction)
        {
            this.Fraction = fraction;
        }
    }

    // Clase para crear un panel (Frame)
    public class CustomFrame : Frame
    {
        public CustomFrame(string title = "")
        {
            this.Label = title;
        }
    }

    // Clase para crear una lista desplegable (ListBox)
    public class CustomListBox : VBox
    {
        public CustomListBox(string[] items)
        {
            foreach (var item in items)
            {
                Label label = new Label(item);
                this.PackStart(label, false, false, 5);
            }
        }
    }

    // Clase para crear un control de fecha (Calendar)
    public class CustomCalendar : Calendar
    {
        public CustomCalendar()
        {
            // Se puede personalizar si es necesario
        }
    }

    // Clase para crear un control de selección de archivos (FileChooserButton)
    public class CustomFileChooser : FileChooserButton
    {
        public CustomFileChooser(string title, FileChooserAction action) : base(title, action)
        {
            // Configurar opciones adicionales si es necesario
        }
    }

    // Clase para crear un cuadro de mensaje (MessageDialog)
    public class CustomMessageDialog
    {
        public static void ShowMessage(Window parent, string message, string title = "Mensaje")
        {
            MessageDialog dialog = new MessageDialog(parent, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, message);
            dialog.Title = title;
            dialog.Run();
            dialog.Destroy();
        }
    }
}

