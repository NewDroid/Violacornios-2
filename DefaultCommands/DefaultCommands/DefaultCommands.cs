using Violacornios;
using UnityEngine.UI;


namespace DefaultCommands
{
    public class DefaultCommands : Mod
    {
        public override void Initialize()
        {
            base.Initialize();
            administrador.instancia.vcconsole.cprint("Añadiendo comandos default", true);
            administrador.instancia.vcconsole.AddCommand(new clear("clear"));
        }

        public class clear : Command
        {
            public clear(string nombre) : base(nombre) { }

            public clear(string nombre, params float[] args) : base(nombre, args) { }

            public override void Run()
            {
                vconsole.cout.text = "";
            }
        }
    }
}
