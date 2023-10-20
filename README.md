# Excercise-05

Como parte del quinto ejercicio que se nos asignó utilizando el motor de videojuegos Unity, se estuvieron realizando las acciones OnJump y OnFastMovement en nuestro objeto shooter para controlar los movimientos y saltos de este personaje, tanto en un Script como en un Visual Script.

1.	Música añadida al file de Spotify:

  	Camila:Srcrets - OneRepublic (Lo estuvo añadiendo Karla, debido a que a Camila le aparecía como si el link estuviera vencido)

  	Raúl: Eye of the Tiger - Survivor

  	Karla: Bliding Lights - The Weeknd
  	
Pasos para llegar a la creación final de estas acciones:

2.	Se creó una matriz de acciones

    Action: Horizontal Movement	
  
          Mapping: A and D keys, Left and Right arrows, gamepad left stick

    Action: Vertical Movement
  	
          Mapping: W and S keys, Left and Right arrows, gamepad left stick

    Action: Shoot
  	
          Mapping: Left click of the mouse

    Action: Jump
  	
          Mapping: Space bar of the keyboard

    Action: Look
  	
          Mapping: Mouse movement

    Action: Fast Movement
  	
          Mapping: Y key 

3.	En este paso se crearon dos acciones adicionales a las que estaban implementadas ya en el script shootermovinput y aquí les dejamos los pasos para crear las mismas:

OnFastMovement (Acción de movimiento rápido):

-	Declaración de la acción: En la parte superior del script, se declara una variable public float fastSpeedMultiplier que representa el multiplicador de velocidad rápida. Este valor se usa para aumentar la velocidad de movimiento cuando se activa la acción "OnFastMovement."

-	Detección de entrada: La acción "OnFastMovement" se activa cuando el jugador realiza una entrada, como presionar una tecla o botón específico en el juego. La detección de entrada se maneja a través de Unity Input System y se configura en el Inspector.

-	Función "OnFastMovement": Cuando se activa la acción "OnFastMovement," se llama a la función public void OnFastMovement().

-	Multiplicación de velocidad: En la función "OnFastMovement," se multiplican los valores de movimiento (movementValue.x y movementValue.y) por el fastSpeedMultiplier. Esto aumenta la velocidad del movimiento del jugador mientras la acción se mantiene activa.

OnJump (Acción de salto):

-	Declaración de la acción: En la parte superior del script, se declara una variable public float jumpForce que representa la fuerza del salto. Esta variable determina cuán alto salta el personaje.

-	Control de saltos: Se utilizan varias variables para controlar el salto:
private bool isJumping: Un indicador que verifica si el personaje está en el aire.
private int jumpsLeft: El número de saltos permitidos (en este caso, 2).
private int jumpsMade: El número de saltos realizados.

-	Detección de entrada: La acción "OnJump" se activa cuando el jugador realiza una entrada, como presionar una tecla o botón específico en el juego. La detección de entrada se maneja a través de Unity Input System y se configura en el Inspector.

-	Función "OnJump": Cuando se activa la acción "OnJump," se llama a la función public void OnJump(InputValue value).

-	Salto inicial: La función "OnJump" primero verifica si quedan saltos disponibles (jumpsLeft > 0) y si el personaje no está actualmente en el aire (!isJumping). Si ambas condiciones son verdaderas, se aplica una fuerza hacia arriba (rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse)) para realizar el salto.

-	Actualización de estado de salto: Después del salto inicial, se actualiza el estado de salto (isJumping = true) y se reduce el número de saltos disponibles (jumpsLeft--) y se incrementa el número de saltos realizados (jumpsMade++).

-	Salto adicional (doble salto): Si el personaje ya está en el aire, pero no ha alcanzado el límite de saltos (jumpsMade < 2), se reinicia la velocidad vertical y se aplica otra fuerza de salto. Esto permite el doble salto.

-	Restablecimiento de saltos en el suelo: Cuando el personaje toca el suelo (detectado mediante la función "OnCollisionEnter"), se restablece el estado de salto, permitiendo al jugador realizar saltos nuevamente.



4. Correr el programa y mostrar los resultados

 ![GIF 10-17-2023 8-23-37 AM](https://github.com/krivera65/Excercise-05/assets/143332773/918b631b-9aef-4893-ae83-639d7517c3c2)

5. En este paso se crearon las acciones jump y fastmovement en el visual script:

   Para crear una acción de salto (jump) en Unity Visual Script, sigue estos pasos:

    - Abre el Visual Script en Unity.
      
    - En el grafo de Visual Script, comienza arrastrando el evento del botón "Jump" desde el Input System al grafo para detectar cuándo se presiona el botón de salto.

    - Agrega un nodo condicional después del evento "Jump". Esto se utiliza para verificar si el personaje está en el suelo antes de permitir un salto normal.
    
    - Conecta el resultado verdadero del nodo condicional a un nodo "Rigidbody - Add Force".
      
    - Configura la dirección de la fuerza en "Add Force" para que sea hacia arriba, lo que normalmente se logra estableciendo el valor en el eje Y en un número positivo. Este          valor representa la fuerza del salto (10).

    - Conecta el resultado falso del nodo condicional a un nodo adicional condicional para verificar si el personaje puede realizar un doble salto. Este segundo nodo                  condicional debe comprobar si canDoubleJump es verdadero.

    - Si canDoubleJump es verdadero (lo que significa que el personaje tiene la capacidad de realizar un doble salto), conecta el resultado verdadero del segundo nodo                  condicional a otro nodo "Rigidbody - Add Force".

   Para modificar la velocidad (speed) en una acción de "Move" utilizando un nodo condicional en un Visual Script:

    - Agrega un nodo condicional antes de la acción de "Move" para determinar cuándo aumentar la velocidad.
        
    - Conecta la entrada del nodo condicional a la condición que determinará cuándo aumentar la velocidad. Esto podría ser un evento, una entrada de jugador, o cualquier              condición específica que desees.
      
    - Conecta la salida verdadera (true) del nodo condicional a un nodo de adició. Este nodo de adición se utilizará para aumentar la velocidad si se cumple la condición.

    - Define la cantidad de velocidad adicional que deseas añadir en la entrada "B" del nodo de adición. Ingresa un valor numérico en "B" para especificar cuánta velocidad se         debe agregar.
        
    - Conecta la salida del nodo de adición de nuevo a la entrada de "Move." Esto asegurará que la velocidad aumentada se aplique a la acción de "Move."
        
    - Asegúrate de que la salida falsa (false) del nodo condicional esté conectada directamente a la entrada de "Move" si la condición no se cumple. Esto significa que si la          condición no se cumple, la velocidad permanecerá sin cambios.

6. Imágenes del resultado del visual script y su ejecusión
   
   ![imagen](https://github.com/krivera65/Ejercicio-05/assets/143332773/4ab5073f-8b54-4f55-85d2-c59ccf6920bc)

   ![imagen](https://github.com/krivera65/Ejercicio-05/assets/143332773/90bb7f6c-55c6-419a-be56-23858d38196e)

   ![imagen](https://github.com/krivera65/Ejercicio-05/assets/143332773/096618d4-9321-4b8b-8f00-0fbe6e684c07)

   ![imagen](https://github.com/krivera65/Ejercicio-05/assets/143332773/089ce62b-6cfc-4930-adb8-3653dfc0572a)

   ![imagen](https://github.com/krivera65/Ejercicio-05/assets/143332773/ae3d4b65-c2ce-4c12-8e70-7eeccfdb3225)

   ![imagen](https://github.com/krivera65/Ejercicio-05/assets/143332773/b627e9e5-a7b5-40f4-a74c-88bf5e117301)

   ![200w(1)](https://github.com/krivera65/Ejercicio-05/assets/143332773/99130cf8-6f31-413b-af03-c704764ca406)



   


    
