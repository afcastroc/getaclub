# getaclub
Prueba técnica de karts Andrés Fabián Castro Castro.

Ítems de la prueba presentes:

1. Crear un modo de juego en el que haya un temporizador inicial. Cuando este temporizador llegue a cero, es Game Over y el jugador vuelve a la pantalla principal. El objetivo es agarrar objetos que te dan tiempo adicional y poder llegar a la meta antes de que se acabe el tiempo. 
2. Crear un sistema de estadísticas a los carros en los que se puedan cambiar su velocidad máxima, aceleración, tiempo de frenado, sensibilidad al tomar curvas. Estos cambios deben poder hacerse dentro del inspector.
3. Crear una IA que corra contra el jugador y tenga 3 niveles de dificultas diferentes. 
4. Crear e implementar 3 mecánicas de suelo (Turbo, pérdida de control del vehículo, salto, etc) en las que cuando el carro pase por encima de ellos se active la mecánica en específico.
5. Desarrollar una mecánica de derrape para que el carro se deslice por el suelo cuando las curvas sean muy pronunciadas.

Uso:
Clonar o descargar el proyecto y abrirlo con Unity en su versión 2019.2.21.f
Abrir el proyeto y ubicar la escena en la carpeta AndresCastroAssets/Scenes/MainMenu.
Ubicar el GameObject Builder donde se puede seleccionar la dificultad y el modo de juego entre Timer, Vs e Items y los atributos del carro a implementar.
Dar play y disfrutar de los tipos de juego y dificultades.

Proyecto:
Todos los elementos creados para el propósito del proyecto están en la carpeta AndresCastroAssets.
Las carpetas se dividen en: 

JsonDotNet - para uso interno de json.
Materials - Materiales para diferenciar los items de suelo.
Scenes - Escenas del juego.
Scripts - Código creado, a su vez se divide en:
	
	AI - Código creado para el uso de los comportamientos AI como el input y el recorrido.
	GameModes - Los scripts de los distintos modos de juego.
	General - Constantes, clases de formato para Json, Detector de Lap y GameManager de la escena de juego.
	Items - Clases de los distintos Items incluyendo la clase base.
	Player - Clase que calcula el progreso de avance de la pista.
	Skills - Clase con el uso del drift. (El drift se obtiene en juego empleando las direccionales combinadas con la tecla espacio)

KartingAssets - Assets originales de Karting Microgame
TextMesh Pro - Assets de TExtMeshPro para la UI de Unity.

Muchas gracias por la oportunidad.

