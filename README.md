Sistema de Evaluación de Contenidos para Streaming

Descripción del sistema

Este proyecto consiste en un sistema desarrollado en C# que simula la toma de decisiones dentro de una plataforma de streaming.  

El programa permite evaluar contenidos digitales (películas, series, documentales y eventos) tomando en cuenta distintos criterios como:

- Duración  
- Clasificación por edad  
- Hora de transmisión  
- Nivel de producción  

Con base en estos datos, el sistema determina automáticamente si el contenido debe:

- Publicarse  
- Enviarse a revisión  
- Ser rechazado  

Además, el sistema registra estadísticas de uso en tiempo real.


Instrucciones para ejecutarlo

1. Abrir el proyecto en Visual Studio o cualquier entorno compatible con C#  
2. Ejecutar el programa  
3. Aparecerá un menú con las siguientes opciones:

   1. Evaluar nuevo contenido  
   2. Mostrar reglas del sistema  
   3. Mostrar estadísticas  
   4. Reiniciar estadísticas  
   5. Salir  

4. Seleccionar una opción ingresando un número  
5. Seguir las instrucciones en pantalla  


Breve explicación del proyecto

El sistema está basado en estructuras fundamentales de programación en C#, incluyendo:

- if → para toma de decisiones  
- while → para validación de datos  
- do-while → para mantener el menú activo  
- for → para representación visual de datos  
- funciones → para organizar la lógica del sistema  

Funcionamiento general

1. El usuario selecciona una opción del menú  
2. Si elige evaluar contenido:
   - Se solicitan los datos  
   - Se validan las entradas  
   - Se simula un análisis  
   - Se aplican reglas del sistema  
3. Se calcula el impacto del contenido  
4. Se toma una decisión automática  
5. Se actualizan las estadísticas  


Características principales

- Validación completa de datos  
- Simulación de análisis del sistema  
- Cálculo de impacto (bajo, medio, alto)  
- Estadísticas en tiempo real  
- Interfaz de consola interactiva  

 Ejemplo de uso

Entrada:
- Tipo: película  
- Duración: 120  
- Clasificación: +13  
- Hora: 20  
- Nivel: medio  

Salida:
PUBLICAR  
Impacto: medio  


 Autor
Iván Méndez  
Proyecto académico – Ingeniería en Sistemas
