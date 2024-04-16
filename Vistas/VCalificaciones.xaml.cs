namespace rtoasaT2.Vistas;

public partial class VCalificaciones : ContentPage
{
	public VCalificaciones()
	{
		InitializeComponent();
	}

    private void OnCalcularButtonClicked(object sender, EventArgs e)
    {
        if (!double.TryParse(etrNotaSeg1.Text, out double notaSeg1) ||
            !double.TryParse(etrNotaExamen1.Text, out double notaExamen1) ||
            !double.TryParse(etrNotaSeg2.Text, out double notaSeg2) ||
            !double.TryParse(etrNotaExamen2.Text, out double notaExamen2))
        {
            DisplayAlert("Error", "Por favor, ingrese solo números en los campos de notas.", "OK");
            return;
        }

        double notaParcial1 = notaSeg1 * 0.3 + notaExamen1 * 0.2;
        double notaParcial2 = notaSeg2 * 0.3 + notaExamen2 * 0.2;
        double notaFinal = notaParcial1 + notaParcial2;

        string estado = "REPROBADO";
        if (notaFinal >= 7)
        {
            estado = "APROBADO";
        }
        else if (notaFinal >= 5 && notaFinal <= 6.9)
        {
            estado = "COMPLEMENTARIO";
        }

        DisplayAlert("Calificaciones",
            $"Nombre: {pckEstudiantes.SelectedItem}\n" +
            $"Fecha: {pckDate.Date.ToString("dd/MMMM/yyyy")}\n" +
            $"Nota Parcial 1: {notaParcial1}\n" +
            $"Nota Parcial 2: {notaParcial2}\n" +
            $"Nota Final: {notaFinal}\n" +
            $"Estado: {estado}",
            "OK");
    }

}