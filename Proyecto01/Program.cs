void menu()
{
    Console.WriteLine("==================================");
    Console.WriteLine("   SISTEMA DE STREAMING");
    Console.WriteLine("==================================");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
    Console.WriteLine("==================================");
}
int opcion;
string tipo;
double duracion;
int clasificacion;
int hora;
string nivel;

int total = 0;
int publicados = 0;
int rechazados = 0;
int revision = 0;
int impactoAlto = 0;
int impactoMedio = 0; 
int impactoBajo = 0;
void evaluarContenido()
{
    Console.Clear();

    while (true)
    {
        Console.Write("Ingrese tipo (pelicula, serie, documental, evento): ");
        tipo = Console.ReadLine().ToLower();

        if (tipo == "pelicula" || tipo == "serie" || tipo == "documental" || tipo == "evento")
        {
            break;
        }

        Console.WriteLine("Tipo inválido. Intente nuevamente.");
    }

    while (true)
    {
        Console.Write("Ingrese duración en minutos: ");
        if (double.TryParse(Console.ReadLine(), out duracion) && duracion > 0)
        {
            break;
        } 
        Console.WriteLine("Duración inválida");
    }

    while (true)
    {
        Console.Write("Clasificación (1.Todo público, 2.+13, 3.+18): ");
        if (int.TryParse(Console.ReadLine(), out clasificacion) && clasificacion >= 1 && clasificacion <= 3)
        {
            break;
        }
            
        Console.WriteLine("Error");
    }

    while (true)
    {
        Console.Write("Hora (0-23): ");
        if (int.TryParse(Console.ReadLine(), out hora) && hora >= 0 && hora <= 23)
        {
            break;
        }
        Console.WriteLine("Error");
    }

    while (true)
    {
        Console.Write("Nivel de producción (bajo, medio, alto): ");
        nivel = Console.ReadLine().Trim().ToLower();

        if (nivel == "bajo" || nivel == "medio" || nivel == "alto")
        {
            break;
        }

        Console.WriteLine("Nivel inválido. Intente nuevamente.");
    }

    SimularAnalisis();

    total++;

    
    bool valido = true;
    string motivo = "";

    if (tipo == "pelicula" && (duracion < 60 || duracion > 180))
    {
        valido = false; 
        motivo = "Duración inválida para película";
    }
    else if (tipo == "serie" && (duracion < 20 || duracion > 90))
    {
        valido = false; 
        motivo = "Duración inválida para serie";
    }
    else if (tipo == "documental" && (duracion < 30 || duracion > 120))
    {
        valido = false; 
        motivo = "Duración inválida para documental";
    }
    else if (tipo == "evento" && (duracion < 30 || duracion > 240))
    {
        valido = false; 
        motivo = "Duración inválida para evento";
    }

    if (valido)
    {
        if (clasificacion == 2 && (hora < 6 || hora > 22))
        {
            valido = false; 
            motivo = "+13 fuera de horario";
        }
        else if (clasificacion == 3 && !(hora >= 22 || hora <= 5))
        {
            valido = false; 
            motivo = "+18 fuera de horario";
        }
    }

    if (valido)
    {
        if (nivel == "bajo" && clasificacion == 3)
        {
            valido = false;
            motivo = "Producción baja no permite +18";
        }
    }

    if (!valido)
    {
        Console.WriteLine($"RECHAZADO: {motivo}");
        rechazados++;
        Console.ReadKey();
        return;
    }

    
    string impacto = "bajo";

    if (nivel == "alto" || duracion > 120 || (hora >= 20 && hora <= 23))
    {
        impacto = "alto";
        impactoAlto++;
    }
    else if (nivel == "medio" || (duracion >= 60 && duracion <= 120))
    {
        impacto = "medio";
        impactoMedio++;
    }
    else
    {
        impacto = "bajo";
        impactoBajo++;
    }


    string decision;

    if (impacto == "alto")
    {
        decision = "ENVIAR A REVISIÓN";
        revision++;
    }
    else
    {
        decision = "PUBLICAR";
        publicados++;
    }

    MostrarResultado(decision, impacto);
    Console.ReadKey();
}
void SimularAnalisis()
{
    Console.Write("Analizando");
    for (int i = 0; i < 3; i++)
    {
        System.Threading.Thread.Sleep(500);
        Console.Write(".");
    }
    Console.WriteLine();
}
void MostrarResultado(string decision, string impacto)
{
    Console.WriteLine("=== RESULTADO FINAL ===");
    Console.WriteLine($"Decisión: {decision}");
    Console.WriteLine($"Impacto: {impacto}");
}
double CalcularPorcentaje(int total, int publicados)
{
    if (total > 0)
    {
        return (publicados * 100.0) / total;
    }
    else
    {
        return 0;
    }
}
do
{
    Console.Clear();
    menu();
    Console.Write("Seleccione una opción: ");
    int.TryParse(Console.ReadLine(), out opcion);
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Evaluando nuevo contenido...");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            evaluarContenido();
            break;
        case 2:
            Console.WriteLine("Mostrando reglas del sistema...");
            Console.WriteLine("=== REGLAS ===");
            Console.WriteLine("Reglas de clasificación y horario");
            Console.WriteLine("* Todo público: cualquier hora");
            Console.WriteLine("* +13: 6 a 22");
            Console.WriteLine("* +18: 22 a 5");
            Console.WriteLine("Reglas de duración por tipo");
            Console.WriteLine("* Película: 60–180 minutos");
            Console.WriteLine("* Serie: 20–90 minutos");
            Console.WriteLine("* Documental: 30–120 minutos");
            Console.WriteLine("* Evento en vivo: 30–240 minutos");
            Console.WriteLine("Reglas de producción");
            Console.WriteLine("* Producción baja solo válida para Todo público o +13");
            Console.WriteLine("* Producción media o alta válida para cualquier clasificación");
            Console.ReadKey();
            break;
        case 3:
            Console.WriteLine("Mostrando estadísticas de la sesión...");
            Console.WriteLine("=== ESTADÍSTICAS ===");
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Publicados: {publicados}");
            Console.WriteLine($"Rechazados: {rechazados}");
            Console.WriteLine($"En revisión: {revision}");

            double porcentaje = CalcularPorcentaje(total, publicados);

            Console.WriteLine($"% Aprobación: {porcentaje}%");

            
            Console.Write("Publicados: ");
            for (int i = 0; i < publicados; i++)
            {
                Console.Write("| ");
            }

            Console.WriteLine();
            Console.ReadKey();
            break;
        case 4:
            Console.WriteLine("Reiniciando estadísticas...");
            total = 0;
            publicados = 0;
            rechazados = 0;
            revision = 0;
            impactoAlto = 0;
            impactoMedio = 0;
            impactoBajo = 0;
            Console.WriteLine("Estadísticas reiniciadas");
            Console.ReadKey();
            break;
        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
            break;
    }
} while (opcion != 5);
