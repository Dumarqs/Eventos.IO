using Eventos.IO.Domain.Eventos.Commands;
using System;
using Eventos.IO.Domain.Core.Events;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new FakeBus();

            // Registro com sucesso
            var cmd = new RegistrarEventoCommand("TesteX", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), true, 0,
                true, "Testando o teste");

            Inicio(cmd);
            bus.SendCommand(cmd);
            Fim(cmd);

            // Registro com erros
            cmd = new RegistrarEventoCommand("", DateTime.Now.AddDays(2), DateTime.Now.AddDays(1), false, 0,
                false, "");

            Inicio(cmd);
            bus.SendCommand(cmd);
            Fim(cmd);

            //Atualizar Evento
            var cmd2 = new AtualizarEventoCommand(Guid.NewGuid(), "TesteX", "", "", DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2), true, 0, true, "Testando o teste");

            Inicio(cmd2);
            bus.SendCommand(cmd2);
            Fim(cmd2);

            //Excluir Evento
            var cmd3 = new ExcluirEventoCommand(Guid.NewGuid());
            Inicio(cmd3);
            bus.SendCommand(cmd3);
            Fim(cmd3);

            Console.ReadKey();
        }

        private static void Inicio(Message message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Inicio do Comando" + message.MessageType);
        }

        private static void Fim(Message message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Fim do Comando" + message.MessageType);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************");
            Console.WriteLine("");
        }

    }

}