using Gtk;
using GTKToolboxComponents;
using System;
using System.Collections.Generic;

class Program
{
    static List<string> historialConversiones = new List<string>();

    static void Main()
    {
        Application.Init();
        Window ventana = new Window("Conversor de Moneda");
        ventana.DeleteEvent += delegate { Application.Quit(); };
        ventana.SetDefaultSize(300, 300);

        Fixed layout = new Fixed();

        // Componentes
        CustomLabel lbl_IngreseMonto = new CustomLabel("Ingrese monto:");
        CustomEntry txt_Monto = new CustomEntry();
        CustomLabel lbl_De = new CustomLabel("De:");
        string[] monedas = { "Euros", "Dólares", "Pesos Colombianos" };
        CustomComboBox combo_De = new CustomComboBox(monedas);
        CustomLabel lbl_A = new CustomLabel("A:");
        CustomComboBox combo_A = new CustomComboBox(monedas);
        
        CustomButton btn_Convertir = new CustomButton("Convertir", (sender, args) =>
        {
            double monto;
            if (double.TryParse(txt_Monto.Text, out monto))
            {
                string monedaOrigen = combo_De.ActiveText;
                string monedaDestino = combo_A.ActiveText;
                double montoConvertido = ConvertirMoneda(monto, monedaOrigen, monedaDestino);
                string resultado = $"Monto convertido: {montoConvertido} {monedaDestino}";
                
                // Guarda en el historial
                historialConversiones.Add($"{monto} {monedaOrigen} a {monedaDestino}: {montoConvertido} {monedaDestino}");
                
                CustomMessageDialog.ShowMessage(ventana, resultado);
            }
            else
            {
                CustomMessageDialog.ShowMessage(ventana, "Por favor, ingrese un número válido.");
            }
        });

        CustomButton btn_Historial = new CustomButton("Ver Historial", (sender, args) =>
        {
            if (historialConversiones.Count > 0)
            {
                string historial = string.Join("\n", historialConversiones);
                CustomMessageDialog.ShowMessage(ventana, "Historial de Conversiones:\n" + historial);
            }
            else
            {
                CustomMessageDialog.ShowMessage(ventana, "No hay conversiones en el historial.");
            }
        });

        // Posiciones
        layout.Put(lbl_IngreseMonto, 20, 20);
        layout.Put(txt_Monto, 20, 50);
        layout.Put(lbl_De, 20, 90);
        layout.Put(combo_De, 20, 120);
        layout.Put(lbl_A, 150, 90);
        layout.Put(combo_A, 200, 120);
        layout.Put(btn_Convertir, 40, 170);
        layout.Put(btn_Historial, 160, 170);

        ventana.Add(layout);
        ventana.ShowAll();
        Application.Run();
    }

    static double ConvertirMoneda(double monto, string monedaOrigen, string monedaDestino)
    {
        // Tasas
        const double EUR_A_USD = 1.17;
        const double USD_A_COP = 4258.00;
        const double EUR_A_COP = EUR_A_USD * USD_A_COP;
        const double COP_A_USD = 1 / USD_A_COP;
        const double USD_A_EUR = 1 / EUR_A_USD;
        const double COP_A_EUR = 1 / EUR_A_COP;

        if (monedaOrigen == monedaDestino) return monto;

        // Conversion
        if (monedaOrigen == "Euros" && monedaDestino == "Dólares") return monto * EUR_A_USD;
        if (monedaOrigen == "Euros" && monedaDestino == "Pesos Colombianos") return monto * EUR_A_COP;
        if (monedaOrigen == "Dólares" && monedaDestino == "Euros") return monto * USD_A_EUR;
        if (monedaOrigen == "Dólares" && monedaDestino == "Pesos Colombianos") return monto * USD_A_COP;
        if (monedaOrigen == "Pesos Colombianos" && monedaDestino == "Euros") return monto * COP_A_EUR;
        if (monedaOrigen == "Pesos Colombianos" && monedaDestino == "Dólares") return monto * COP_A_USD;

        return monto;
    }
}





