using System;

namespace RefactoringGuru.DesignPatterns.Facade.Conceptual
{
    // La clase Facade proporciona una interfaz simple a la lógica compleja de uno
    // o varios subsistemas. El Facade delega las solicitudes del cliente a los
    // objetos apropiados dentro del subsistema. El Facade también es responsable
    // de gestionar su ciclo de vida. Todo esto protege al cliente de la
    // complejidad no deseada del subsistema.
    public class Facade
    {
        protected Subsystem1 _subsystem1;

        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

        // Los métodos del Facade son atajos convenientes para la funcionalidad sofisticada
        // de los subsistemas. Sin embargo, los clientes solo tienen acceso a una
        // fracción de las capacidades de un subsistema.
        public string Operation()
        {
            string result = "Facade inicializa los subsistemas:\n";
            result += this._subsystem1.Operation1();
            result += this._subsystem2.Operation1();
            result += "Facade ordena a los subsistemas realizar la acción:\n";
            result += this._subsystem1.OperationN();
            result += this._subsystem2.OperationZ();
            return result;
        }
    }

    // El subsistema puede aceptar solicitudes tanto desde el facade como desde el cliente
    // directamente. En cualquier caso, para el subsistema, el Facade es solo otro
    // cliente y no forma parte del subsistema.
    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem1: ¡Listo!\n";
        }

        public string OperationN()
        {
            return "Subsystem1: ¡Adelante!\n";
        }
    }

    // Algunos facades pueden trabajar con múltiples subsistemas al mismo tiempo.
    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem2: ¡Prepárate!\n";
        }

        public string OperationZ()
        {
            return "Subsystem2: ¡Dispara!\n";
        }
    }

    class Client
    {
        // El código del cliente interactúa con los subsistemas complejos a través de una
        // interfaz simple proporcionada por el Facade. Cuando un facade gestiona el ciclo de vida
        // del subsistema, es posible que el cliente ni siquiera sepa acerca de la existencia
        // del subsistema. Este enfoque te permite mantener la complejidad bajo control.
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // El código del cliente puede tener algunos objetos del subsistema ya
            // creados. En este caso, podría valer la pena inicializar el
            // Facade con estos objetos en lugar de permitir que el Facade cree
            // nuevas instancias.
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }
}