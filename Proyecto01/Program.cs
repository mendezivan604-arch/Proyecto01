void menu()
{
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas de la sesión");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
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

    Console.Write("Ingrese tipo (pelicula, serie, documental, evento): ");
    tipo = Console.ReadLine().ToLower();

    while (true)
    {
        Console.Write("Ingrese duración en minutos: ");
        if (double.TryParse(Console.ReadLine(), out duracion) && duracion > 0)
            break;
        Console.WriteLine("Duración inválida");
    }

    while (true)
    {
        Console.Write("Clasificación (1.Todo público, 2.+13, 3.+18): ");
        if (int.TryParse(Console.ReadLine(), out clasificacion) && clasificacion >= 1 && clasificacion <= 3)
            break;
        Console.WriteLine("Error");
    }

    while (true)
    {
        Console.Write("Hora (0-23): ");
        if (int.TryParse(Console.ReadLine(), out hora) && hora >= 0 && hora <= 23)
            break;
        Console.WriteLine("Error");
    }

    Console.Write("Nivel de producción (bajo, medio, alto): ");
    nivel = Console.ReadLine().ToLower();

    Console.WriteLine("Analizando...");

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

    
    if (impacto == "alto")
    {
        Console.WriteLine("ENVIAR A REVISIÓN");
        revision++;
    }
    else
    {
        Console.WriteLine("PUBLICAR");
        publicados++;
    }

    Console.WriteLine($"Impacto: {impacto}");
    Console.ReadKey();
}
do
{
    menu();
    Console.Write("Seleccione una opción: ");
    opcion = int.Parse(Console.ReadLine());
    switch(opcion)
    {
        case 1:
            Console.WriteLine("Evaluando nuevo contenido...");
            evaluarContenido();
           

            break;
        case 2:
            Console.WriteLine("Mostrando reglas del sistema...");
            
            break;
        case 3:
            Console.WriteLine("Mostrando estadísticas de la sesión...");
            
            break;
        case 4:
            Console.WriteLine("Reiniciando estadísticas...");
            
            break;
        case 5:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
            break;
    }
} while (opcion != 5);
