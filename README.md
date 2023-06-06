# Monkey Island Demo

Este juego es una pequeña adaptación de un nivel de la conocida aventura gráfica "The secret of Monkey Island". En esta ocasión la trama ocurre en la montaña y consiste en la discusión entre un guardabosques (protagonista) y un pastor (enemigo). Básicamente, el pastor cansado de perder obejas en el bosque, se pelea con el protagonista para que haga bien su trabajo y encuentre a sus animales. Obviamente, nuestro personaje no se quedará atrás e intentará ganar la batalla hasta que uno de los dos se quede sin vidas.

## Index

- [Cómo jugar](https://github.com/Tomas-Gayo/monkey-island-demo/blob/main/README.md#c%C3%B3mo-jugar)
- [Escenas](https://github.com/Tomas-Gayo/monkey-island-demo/blob/main/README.md#escenas)
- [Demo](https://github.com/Tomas-Gayo/pec1_adventure_game/-/blob/main/adventure-game/README.md#demo)
- [Estructura de carpetas](https://github.com/Tomas-Gayo/pec1_adventure_game/-/blob/main/adventure-game/README.md#estructura-de-carpetas)
- [Máquina de estados](https://github.com/Tomas-Gayo/pec1_adventure_game/-/blob/main/adventure-game/README.md#m%C3%A1quina-de-estados)
- [Funcionamiento de JSON](https://github.com/Tomas-Gayo/pec1_adventure_game/-/blob/main/adventure-game/README.md#funcionamiento-de-json)
- [Animaciones y sonidos](https://github.com/Tomas-Gayo/pec1_adventure_game/-/blob/main/adventure-game/README.md#animaciones-y-sonidos)
- [Atribuciones](https://github.com/Tomas-Gayo/pec1_adventure_game/-/blob/main/adventure-game/README.md#atribuciones)

## Cómo jugar

Las mecánicas son sencillas. Hay dos tipos de turnos: turno del jugador y turno del enemigo. El primer turno se decide aleatoriamente y los siguientes dependerán de quien gana el turno actual. Ambos personajes tienen tres vidas y el objetivo consiste en acabar con las vidas del enemigo antes de que él lo haga con nosotros. 
- **Turno del jugador**: El jugador empieza primero seleccionando un insulto y el enemigo tiene que responder con el _handicap_ de que su respuesta es aleatoria. Si el enemigo acierta el contrainsulto, entonces,  ganará el turno y el jugador perderá una vida, de lo contrario perderá el turno y una vida. 
- **Turno del enemigo**: El enemigo lanza un insulto aleatorio y el jugador tiene que elegir una respuesta adecuada. Si el jugador responde correctamente, el enemigo pierde el turno y una vida, si, por el contrario, no acierta el contrainsulto, el jugador perderá el turno y una vida.  

## Escenas

El juego consite en tres escenas: Menu incial, Pantalla de juego y Pantalla final. 

- **Menu inicial**:

<img src="adventure-game/images/MainMenu.PNG" alt="Pantalla inicial" width="500"/>

Esta es la primera escena al inciar el juego. Dos botones centrales son los que marcan las acciones disponibles, empezar "nuevo juego" y "cerrar juego". Además, para ambientar al usuario, las imagenes en el _backgorund_ situan al jugador en un bosque montañoso.

- **Pantalla de juego**:

<img src="adventure-game/images/GameScreen.PNG" alt="Pantalla de juego" width="500"/>

Una vez seleccionado "Nuevo juego" en el menu principal, cambiamos de escena y llegamos a la pantalla de juego. Como se puede observar la escena consiste en (de arriba a abajo): una caja de dialogo compartida entre jugador y enemigo, donde apareceran los insultos y contrainsultos una vez seleccionados; una caja con _scroll_ para permitir seleccionar las respuestas, esta será la ventana de interacción con el juego; barra de vida para cada personaje, un corazoón equivale a una vida y al perder turno se borrará un corazón. Por último, y posiblemente lo más importante, el protagonista (izquierda) y el enemigo (derecha) sesituan en el centro de la pantalla.  

- **Pantalla final**:

<img src="adventure-game/images/FinalScreen.PNG" alt="Pantalla final" width="500"/>

Posiblemente, la escena más simple de todo el juego. si gana el usuario el titulo será ¡VICTORIA!, si pierde dirá ¡DERROTA!. También hay dos botones para dar la posibilidad de "Reiniciar juego" o "Volver al menu".  

## Demo

El juego se ha publicado en itch.io, [prueba el juego en su versión Web](https://toyoerin.itch.io/adventuregame).

También podéis ver la [demostración del juego en video](https://youtu.be/0CzynyenGcI) en Youtube para su versión de PC y Android. 

## Estructura de carpetas

<img src="adventure-game/images/unityFolders.PNG" alt="Estructura de carpetas"/>

Con la intención de mantener el máximo de orden posible el proyecto se ha dividido en diversas carpetas. Estas son: 
- "**Animations**": todas las animaciones y sus controladores se guardan aquí.
- "**Asset Store**": se ha utilizado un asset adicional llamado "TextMesh Pro". Cualquier otro asses se guardaría en esta carpeta.
- "**Prefabs**": se han guardado dos prefabs que corresponden a botones.
- "**Resources**": en esta carpeta se guardan todos aquellos recuros a los que se accederán a través de la clase Resources de Unity. En este casom se encuentran los sonidos y el fichero JSON. 
- "**Scenas**": las tres escenas del juego se pueden encontran aquí.
- "**Scripts**": posiblemente la carpeta más compleja de estructurar puesto que hay muchos _scripts_. En la imagen se puede observar que se han añadido las sub-carpetas "UI" y "Game" para diferenciar el objetivo de cada _script_ rápidamente. Además, dentro de cada una hay más sub-divisiones, puesto que la cantidad de ficheros puede hacer que su busqueda sea ineficiente. Por ejemplo, si queremos buscar los _scripts_ de la máquina de estados es tan sencillo como hacer: Scripts -> Game -> State Machine.
- "**Sprites**": todos los sprites o imagenes, tanto de UI como del juego, se guardan aquí. Se ha utilizado la misma idea que en la carpeta anterior. 

## Máquina de estados

Una de las partes más interesantes del código es la máquina de estados. Es un patrón muy básico pero que funciona, puesto que lo que se esta implementando no requiere de mucha complejidad.
La siguiente imagen representa el diagrama simplificado de los diferentes estados. 

<img src="adventure-game/images/stateMachine.PNG" alt="Máquina de estados"/>

En el código partimos de la clase "GameplayManager", esta en un principio contenía toda la lógica de turnos, sin embargo, con la máquina de estados se ha conseguido repartir esa tarea con los diferentes estados. En primer lugar, la clase "StateMachine" es la responsable de establecer los estados de clase "State". Además, la clase "State" contendrá los métodos virtuales que cada estado llamará para sobreescribirlos, ya que, cada uno se implementa en clases separadas, pero, requieren de esta clase para funcionar. Seguidamente, desde la clase "GameplayManager", ahora vaciada de lógica y heredando de la clase "StateMachine", será la responsable de iniciar la máquina. Después, en cada estado dependiendo de las condiciones se irán cambiando de estados siguiendo el diagrama mostrado más arriba. 

**Resumen de los estados**

- "**Begin**": Primer estado y donde se decide quien empieza turno. La primera vez es aleatorio y las siguientes depende de una variable que marca el ganador del turno anterior. 
- "**Player Turn**": Define el turno del jugador. La mayor parte de la lógica se encuentra aquí (junto con el "Enemy Turn"), muy por encima, el jugador selecciona una opción en una botonera instanciada por código y el enemigo responde una respuesta aleatoria. Entonces, se elige un ganador y se restan corazones. Después, la información se envía al siguente estado. 
- "**Enemy Turn**": Define el turno del enemigo. Es la misma lógica del estado del jugador pero invirtiendo el orden de algunas lineas para que el turno sea coherente. 
- "**End Game**": último estado que se dedica a decidir si la partida a finalizado o hay que seguir jugando. Eso dependerá de la puntuación de los jugadores, el primero en llegar a cero pierde, por lo tanto, si no se llega a esa condición, entonces, se vuelve al estado "Begin".

## Funcionamiento de JSON

La implementación del JSON es sencilla pero no evidente. Se han creado dos clases, la primera para crear la estructura de datos y la otra para convertir en lista los datos que se encentran en el fichero de texto (aquí también se crearan métodos para obtener datos de la lista). El primer paso es leer el JSON desde la carpeta "Resources" con la clase Resources y guardarlo en un objeto que se ha de convertir en una lista. Una vez se consigue esto solo hay que pasar estos datos a un GameObject que a su vez le dará estos datos al "GameplayManager". Una vez se tienen esos datos en el juego, simplemente hay que llamar a los métodos creados en la clase "JSON reader" que es donde tenemos la lista para conseguir los datos. 

## Animaciones y sonidos

Se han añadido multiples animaciones y sonidos tanto en la UI como en los elementos del juego. 

- **Parallax**: Efecto _parallax_ añadido en el _background_ del menu inicial. Esto consiste en añadir varias capas de fondo e ir moviendolas cada una independientemente. En la pantalla de juego se ha optado por mantener el fondo fijo pero permitir el movimiento en las nubes para que parezca un mundo más vivo. 

- **UI**: Todos los botones tienen animación de _Highlight_ cuando pasamos por encima y animación de presionado al clicar. De la misma manera, cada efecto tiene un sonido determinado.

- **Dialogo**: Se ha añadido una animación para evitar que el texto aparezca de repente, por lo que va apareciendo una letra detrás de otra simulando que el personaje habla, asimismo, cada vez que se aparece una letra un sonido se reproduce para dar esa misma sensación. 

- **Personajes**: Cada personaje tiene sus propias animaciones de reposo, ataque, daño y muerte. También, las tres últimas mencionadas tienen un sonido relacionado que se dispara cuando la animación se activa. 

- **Música de fondo**: Hay una pista que se reproduce en _loop_ tanto en el menu incial como en la pantalla final. Durante el juego se reproduce una pista diferente (en _loop_) más animada que la que se reproduce en las otras escenas, ya que, no se pretende dormir al jugador. 

## Atribuciones

Todos los recursos se han encontrado en la página web [opengameart.org](https://opengameart.org/).

- **Background**: [usuario PWL](https://opengameart.org/users/pwl)

- **Personajes y sus animaciones**: [Usuario CraftPix.net 2D Game Assets](https://opengameart.org/users/craftpixnet-2d-game-assets)

- **Corazón**: [Usuario Nicole Marie T](https://opengameart.org/users/nicole-marie-t) 

- **Sonidos UI**: [Usuario Kenney](https://opengameart.org/users/kenney)

- **Música Menu**: [Usuario adn_adn](https://opengameart.org/users/adnadn)

- **Música juego**: [Usuario Macro](https://opengameart.org/users/macro)






