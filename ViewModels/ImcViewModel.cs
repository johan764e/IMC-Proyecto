using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using IMC_MVVM_JAPD.Models;

namespace IMC_MVVM_JAPD.ViewModels;

public class ImcViewModel : INotifyPropertyChanged
{
    // Los Entry capturan texto, incluso al escribir números
    public string PTexto { get; set; } = "";
    public string ETexto { get; set; } = "";

    private string resultado = "Ingresa tus datos.";
    public string Resultado
    {
        get { return resultado; }
        set
        {
            resultado = value;
            // Avisamos al Label que el resultado cambió
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(Resultado)));
        }
    }

    // El botón usará este comando mediante binding
    public ICommand CalcularImcCommand { get; }

    public ImcViewModel()
    {
        // Al ejecutar el comando se llama a Calcular
        CalcularImcCommand = new Command(Calcular);
    }

    // El binding escucha este evento
    public event PropertyChangedEventHandler? PropertyChanged;

    private void Calcular()
    {
        // Validamos cada campo por separado
        double peso;
        bool pesoValido = double.TryParse(PTexto, out peso);
        if (pesoValido == false || !double.IsFinite(peso) || peso <= 0)
        {
            Resultado = "Escribe un peso válido mayor que cero.";
            return; // Termina sin hacer el cálculo
        }

        double estatura;
        bool estaturaValida = double.TryParse(ETexto, out estatura);
        if (estaturaValida == false || !double.IsFinite(estatura) || estatura <= 0)
        {
            Resultado = "Escribe una estatura válida en metros.";
            return;
        }

        // Creamos el modelo y le asignamos los datos
        Persona persona = new Persona();
        persona.Peso = peso;
        persona.Estatura = estatura;

        // El modelo realiza la operación
        double imc = persona.CalcularImc();

        // Evitamos mostrar un resultado numérico inválido
        if (!double.IsFinite(imc))
        {
            Resultado = "Revisa el peso y la estatura.";
            return;
        }

        // F2 muestra el número con dos decimales
        Resultado = "Tu IMC es: " + imc.ToString("F2");
    }
}