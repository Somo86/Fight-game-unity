# GODAY
De los muchos clanes ninja que viven en las aldeas Japonesas los más conocidos de todos són los miembros del clan **Goday**. También conocidos como los protectores de los cuatro elementos, los niños Goday son entrenados desde muy temprana edad para ser asesinos expertos, rápidos moviéndose entre las sombras y auténticos maestros en acabar con sus enemigos sin que estos si quiera puedan darse cuenta.
Pero si en algo son conocidos los miembros del clan **Goday** es por su capacidad innata en el control del chakra elemental, lo que les permite manejar los 4 elementos básicos, el fuego, el rayo, la energia natural y el agua.
### La gran aniquilición
Durante la gran guerra ninja, muchos fueron los que murieron en las inumerables batallas. El clan **Goday** juró proteger el templo de los Elementos y la lejendaria espada **Taka Goday** que allí se conservaba. Fué junto a sus históricos aliados, el clan **Aburame** como consiguieron mantener el templo intacto a pesar de los múltipleas asedios que vivieron. Pero fué en ese entonces cuando a fría traición el clan aburame asesinó a todos los soldados **Goday** mientras dormian, entraron en el temlplo y robaron a **Taka Goday**. 
El líder del clan al ver tal traición pidió a su mujer y a su hijo que escaparan del lugar, en medio del fulgor de la batalla, y con su muerte la história de los **Goday** llegaba a su fin.
### Shino, el último Goday.
Pese a que todos piensan que los **Goday** son historia, Shino, el hijo del líder del clan sobrevivió a **la gran aniquilación**, y oculto con su madre, aprendió de esta las artes tradicionales de su pueblo. Han sido años duros, pero ahora Shino está dispuesto a devolver el honor a su clan traicionado, y para ello, está dispuesto a recuperar a **Taka Goday** de manos del clan **Aburame**.

## El juego
---
Lleva el control de Shino y viaja por diferentes aldeas para acabar con todos los miembros del clan **Aburame**.
### Objetivo del juego
En cada uno de los niveles tienes que asesinar a todos tus enemigos, no puede quedar ninguno con vida.
### Shino
Los movimientos básicos de Shino son correr, saltar, apuñalar y lanzar shiruken.
* Correr: Usa las teclas **"flecha derecha"** y **"flecha izquiera"** para moverte.
* Saltar: Usa la tecla **"flecha arriba"** para saltar.
* Apuñalar: Usa la tecla **"Q"** para apuñalar a tu enemigo. En Shino, el apuñalamiento sólo tiene efecto si se ataca a tus enemigos por la espalda.
* Lanzar shiruken : Usa la tecla **"W"** para lanzar un shiruken a distáncia. Ten en cuenta que tienes que esperar unos segundos entre un lanzamiento y otro.
### Combate cuerpo
---
Es la forma más rápida de acabar con tus enemigos, pero hay que tener cuidado. Shino ha sido entrenado en las artes del asesinato y el sigilo, por lo que no es un buen combatiente cuerpo a cuerpo, sinó que su destreza se encuentra en apuñalar por la espalda. Por tanto si decides atacar a tus enemigos de frente, no conseguirás ejercerles ningún daño, y muy probablemente seas impactado por los puñales enemigos. **¡Salta por encima de tus enemigos y apuñálales por la espalda!**

### Control de chakra elemental
---
Durante el juego encontrarás chakra de los 4 elementos, recógelos para adquirir temporalmente el poder de uno de los elementos.
* Chakra de fuego: Mientras está activo, cualquier ataque (lanzamiento o cuerpo a cuerpo) infligirá daños repetidamente durante unos segundos al enemigo impactado.
* Chakra relámpago: Mientras está activo, cualquier ataque (lanzamiento o cuerpo a cuerpo) que impacte sobre un enemigo producirá que este tarde más tiempo de lo normal en girarse hacia ti cuando le saltes por encima.
* Chakra natural: Mientras está activo, cualquier ataque (lanzamiento o cuerpo a cuerpo) que impacte sobre un enemigo incrementará tu salud.
* Chakra de agua:  Mientras está activo, cualquier ataque (lanzamiento o cuerpo a cuerpo) que impacte sobre un enemigo producirá que este sea incapaz de luchar o lanzar ningún shiruken durante unos segundos.
### El clan Aburame
---
Tus enemigos irán a tu búsqueda. Lanzarán shuriken o te atacaran si te tienen suficientemente cerca. Atacándoles de frente tienes las de perder, pero tienes una ventaja. Tu eres rápido y has sido entrenado en las artes del asesinato. Si saltas a tus enemigos y te colocas a sus espaldas, les dejarás desconcertados durante unos instantes, momento que tienes que aprovechar para apuñalarles.
### Perder
---
Si pierdes toda la salud tendrás que empezar el nivel de nuevo.
## Estructura del proyecto
Para este proyecto quise trabajar dos puntos básicos
* Profundizar en el sistema de partículas. Pensé que trabajar con el concepto de "los 4 elementos" me permitiria trabajar con efectos que se pueden encontrar en muchos juegos, como el fuego, el agua o los rayos.
* Trabajar con elementos de combate cuerpo a cuerpo.
Así que todo y no tener una idea clara de como tenia que ser el juego, sabia que estos dos conceptos eran básicos.
Después de explorar con diferentes ideas pensé que un juego inspirado en el mundo "ninja" me permitía añadir elementos de lucha y el tema del "sistema de partículas" se adaptaba muy bien también ya que en nuestro imaginario, los ninjas pueden dominar el chakra y producir ataques con grandes efectos visuales.
### Assets
La estrucutra de los Assets contiene los siguientes elementos:

* Animations: Contiene todas las animaciones de los personajes creadas por Unity.
* Fonts: Contiene las fuentes que se usan para los elementos de UI.
* Prefabs: Elementos que se repiten en el juego. Algunos de ellos se instancian directamente mediante scripts.
Resources: Contiene principalmente los sonidos y la banda sonora que se cargan en su mayoria mediante scripts.
* Scenes: Contiene todas las escenas del juego. El proyecto tiene las siguientes escenas: Logotipo, pantalla de título, menú, 2 niveles del juego y una pantalla final de créditos.
* Scripts: Mantiene todos los scripts del proyecto.
* Sprites: Contiene todos los Sprites del juego.
### Scripts
En esta sección detallaré todos los scripts que se encuentran en el proyecto y cuál es su función principal.
#### Los ninja
Dentro de los personajes ninja hay que diferenciar entre **Shino**, el ninja protagonista y los ninja del clan **Aburame**, nuestros enemigos.
Los script que controlan la mayoria de las acciones de todos los ninja son 3:
* CharacterController: Controla las acciones principales de los ninja como correr, saltar, disparar o atacar. Esta clase es compartida tanto por el protagonista como los enemigos.
* HeroController: Responsable de manejar las acciones del jugador con el teclado y traducirlo a en acciones del protagonista.
* EnemyController: Incorpora toda la IA que permite a los enemigos tener cierta inteligencia para determinar que acción realiza. Los enemigos realizan las seguientes acciones:
- - Cuando el protagonista se acerca a una determinada distancia a la posición del enemigo, este empieza a moverse hacia el protagonista.
- - Se gira para encararse siempre de frente al protagonista, pero no lo hace inmediatamente, sinó que cuando tienen que girarse porqué el protagonista ha cambiado de posición, el giro se produce después de un lapso de tiempo.
- - Si el protagonista está lo suficientemente cerca empiezan a disparar shuriken hacia él.
- - Si el protagonista está tan cerca que permite el ataque cuerpo a cuerpo, este se acciona.
#### Disparo
Hay una clase encargada del lanzamiento de los shuriken.
* ShootController: Se encarga de instanciar el shuriken y detectar cuando este colisiona contra un enemigo o el protagonista. También "envena" a los enemigos si el protagonista tiene un poder activo en el momento del impacto.
#### El uso del chakra de los elementos
Hay dos clases que se encargan de gestionar el efecto de poseer el chakra de un elemento y el efecto sobre nuestros enemigos:
* ElementsPowerController: Esta clase gestiona los efectos visuales que produce sobre nuestro protagonista cuando este obtiene un ítem de chakra. Es decir se encarga de instanciar el **sistema de partículas** correspondiente a cada elemento (fuego, agua rayo, naturaleza).
* HeroPowerController: Esta clase se encarga de activar el poder sobre nuestro protagonista y determinar el tiempo que este poder permanece activo. Eso quiere decir que también es esta clase aplicar los efectos de los ataques del protagonista cuando este está bajo los efectos de uno de los chakra.
Es esta clase la que determina que un ataque del protagonista tiene que "envenenar" al enemigo receptor del ataque con el efecto del chakra.
* EnemyPoisonedController: Esta clase se encarga de marcar visualmente a los enemigos que están afectados por el chakra del protagonista y que por tanto están sufriendo los efectos de ese poder.
#### Salud
Hay tres clases relacionadas con la gestión de la salud de los personajes:
* HealthController: Esta clase determina los puntos de resistencia de cada uno de los personajes y controla cuando perdemos o ganamos vida, según sea el caso. Es responsable de comunicar al juego cuando algunos de los personajes pierde todos los puntos de salud.
* HeroBarLifeController: Esta clase comunica los puntos de vida, gestionados por **HealthController**, de nuestro protagonista con la barra de salud que se encuentra en el canvas principal del juego.
* LifeUIController: Se encarga de mostrar sobre cada uno de los personajes cuando este pierde o gana x puntos de salud.
#### Gestión del juego
* GameManagerController: Es la clase encargada de controlar el proceso del juego. Sabe cuando el protagonista ha acabado con todos los enemigos o ha muerto, determinando si se ha superado el nivel o no. Gestiona también algunos elementos de la UI.
#### Otras escenas
Hay otras escenas con sus propios scripts:
* LogoController: Gestiona el cambio de escena desde la pantalla del logotipo.
* MenuController: Gestiona los eventos del click en los botones del menú
* TitleController: Gestiona el cambio de escena desde la pantalla de título.
## Recursos
* Sprites:
- - https://assetstore.unity.com/packages/2d/characters/mighty-heroes-rogue-2d-fantasy-characters-pack-85770
- - https://assetstore.unity.com/packages/2d/textures-materials/floors/
five-seamless-tileable-ground-textures-57060
- - https://assetstore.unity.com/packages/2d/textures-materials/sky/farland-skies-cloudy-crown-60004
* Musica:
- - https://mixkit.co/free-sound-effects/
- - https://www.free-stock-music.com/
* Fuentes:
- - https://www.fontspace.com/category/ninja
* Effects: 
- - https://assetstore.unity.com/packages/vfx/particles/fire-explosions/procedural-fire-141496
* Texturas:
- - https://assetstore.unity.com/packages/2d/textures-materials/water/foam-textures-72313
## Preview
[Ver archivo en mp4](https://gitlab.com/Somo86/albertsomoza-pec4/-/blob/master/goday.mp4)


