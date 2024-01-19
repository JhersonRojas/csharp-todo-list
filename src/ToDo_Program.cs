namespace ToDo_Program
{
    ///<summary>
    /// Clase principal Todo para el programa
    ///</summary>
    public class ToDo
    {
        // Instancia del valor que mantiene el programa en ejecución
        static private bool appRunning = true;

        // Lista de deberes existentes en el programa
        static private List<string> toDoList = [];

        /// <summary>
        /// Metodo principal para iniciar el programa de ToDo
        /// </summary>
        public static void RunProgram()
        {

            Console.WriteLine("\n--- Ingresa algún elemento o mira las opciones con '--help' si lo necesitas. ---\n");

            /// Bucle para mantener el programa en ejecución
            while (appRunning == true)
            {
                /// Captura la acción que ejecuta el usuario
                string? input = Console.ReadLine();

                // Casos de uso del programa
                switch (input)
                {
                    case null:
                        {
                            Console.WriteLine("No se ha realizado ninguna acción");
                            break;
                        }
                    case "":
                        {
                            Console.WriteLine("No se ha realizado ninguna acción");
                            break;
                        }
                    case string a when a.StartsWith("--help"):
                        {
                            Help();
                            break;
                        }
                    case string b when b.StartsWith("--exit"):
                        {
                            CloseProgram();
                            break;
                        }
                    case string c when c.StartsWith("--show"):
                        {
                            ListTasks();
                            break;
                        }
                    case string d when d.StartsWith("--rm"):
                        {
                            RemoveTask(d);
                            break;
                        }
                    default:
                        {
                            toDoList.Add(input);
                            Console.WriteLine("\n--- Se ha agregado un deber a la lista ---\n");
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Metodo para obtener las opciones y especificaciones del programa
        /// </summary>
        static private void Help()
        {
            Console.WriteLine("\nComandos: \n '(escribir...)' : Agrega un deber a la fila actual. \n --show : Muestra el listado de deberes actuales. \n --rm (id) : Elimina algún deber en base a su Id. \n --exit: termina el programa. \n");
        }

        /// <summary>
        /// Metodo para cerrar el programa
        /// </summary>
        static void CloseProgram()
        {
            // Finalizando ejecución del programa
            appRunning = false;
        }

        /// <summary>
        /// Metodo para listar los deberes existentes en el programa
        /// </summary>
        static void ListTasks()
        {
            // Indice para el Id de cada deber listado
            int index = 0;

            // Mostrando los deberes existentes
            if (toDoList.Count == 0)
            {
                Console.WriteLine("\n--- No hay elementos actualmente para listar ---\n");
            }
            else
            {
                Console.WriteLine("\n----- Lista de deberes -----");
                foreach (var item in toDoList)
                {
                    Console.WriteLine($"Id: {index} - Deber: {item}");
                    index++;
                }
                Console.WriteLine("----------------------------\n");
            }
        }

        /// <summary>
        /// Metodo para eliminar un deber de la lista actual
        /// </summary>
        /// <param name="taskItem"> Entrada recibida desde el programa </param>
        static void RemoveTask(string taskItem)
        {

            // Obtener el Id del deber
            string[] commandParts = taskItem.Split("--rm ");

            // Verificando si el Id es valido
            if (commandParts.Length < 2 || !int.TryParse(commandParts[1], out int taskId))
            {
                Console.WriteLine("\n---Id de deber inválido. Debe ser un número entero ---\n");
                return;
            }

            // Verificando si el Id del deber existe en la lista
            if (taskId < 0 || taskId >= toDoList.Count)
            {
                Console.WriteLine($"\n---El deber con Id {taskId} no existe en el listado ---\n");
                return;
            }

            // Eliminar la tarea y mostrar un mensaje de éxito
            toDoList.RemoveAt(taskId);
            Console.WriteLine($"\n--- El deber con Id {taskId} se ha eliminado ---\n");

        }
    }
}
