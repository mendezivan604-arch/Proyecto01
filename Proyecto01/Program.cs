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
void evaluarContenido()
{
    Console.Write("Ingrese el tipo de contenido (película, serie, documental): ");
    tipo = Console.ReadLine();
    Console.Write("Ingrese la duración en minutos: ");
    duracion = double.Parse(Console.ReadLine());
    Console.Write("Ingrese la clasificación (1. +13, 2. +18, 3. todo público: ");
    clasificacion = int.Parse(Console.ReadLine());
    Console.Write("Ingrese la hora de visualización (0-23): ");
    hora = int.Parse(Console.ReadLine());
    Console.Write("Ingrese el nivel de satisfacción (bajo, medio, alto): ");
    nivel = Console.ReadLine();
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
            while (!int.TryParse(hora, out horaprogramada) || horaprogramada < 0 || horaprogramada > 23)
            {
                Console.WriteLine("Hora invalida. Ingrese un numero entre 0 y 23.");
                Console.Write("Ingrese hora programada (0-23): ");
                hora = Console.ReadLine();
            }

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
