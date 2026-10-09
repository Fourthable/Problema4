using System;

// Clase: Bateria
class Bateria
{
    // Propiedad: voltaje actual de la batería (V)
    public double Voltaje { get; set; }

    // Propiedad: incremento de voltaje por ciclo (V)
    public double Incremento { get; set; }

    // Constante: voltaje objetivo de carga (V)
    public const double VoltajeLimite = 12.6;

    // Constructor
    public Bateria(double voltajeInicial, double incremento)
    {
        Voltaje = voltajeInicial;
        Incremento = incremento;
    }

    // Método: simula la carga ciclo por ciclo hasta llegar a 12.6 V
    public void Cargar()
    {
        int ciclo = 0;

        while (Voltaje < VoltajeLimite)
        {
            ciclo++;
            Voltaje += Incremento;

            // Si el último incremento supera el límite, se ajusta a 12.6 V
            if (Voltaje > VoltajeLimite)
            {
                Voltaje = VoltajeLimite;
            }

            Console.WriteLine($"Ciclo {ciclo}: {Voltaje:F2} V");
        }

        Console.WriteLine($"Carga completa: {Voltaje:F2} V en {ciclo} ciclos.");
    }
}

class Program
{
    // Lee un número decimal; si soloPositivo es true, exige que sea mayor que 0
    static double LeerDouble(string mensaje, bool soloPositivo)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor) && (!soloPositivo || valor > 0))
            {
                return valor;
            }
            Console.WriteLine("Valor inválido, intenta de nuevo.");
        }
    }

    static void Main()
    {
        Console.WriteLine("=== Carga de batería hasta 12.6 V ===");

        double voltajeInicial = LeerDouble("Voltaje inicial (V): ", false);
        // El incremento debe ser mayor que 0 para evitar un ciclo infinito
        double incremento = LeerDouble("Incremento por ciclo (V, mayor que 0): ", true);

        // Objeto: bateria
        Bateria bateria = new Bateria(voltajeInicial, incremento);

        if (bateria.Voltaje >= Bateria.VoltajeLimite)
        {
            Console.WriteLine($"La batería ya está cargada ({bateria.Voltaje:F2} V ≥ 12.6 V).");
        }
        else
        {
            bateria.Cargar();
        }

        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }
}