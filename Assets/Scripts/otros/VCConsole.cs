using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace Violacornios
{
    public class hola : Command
    {
        public hola(string nombre) : base(nombre) { }

        public hola(string nombre, params float[] args) : base(nombre, args) { }

        public override void Run()
        {
            vconsole.cprint("pa ti mi cola xdddddddddd", true);
        }
    }

    public class Command
    {
        public string nombre;
        public float[] args;

        protected VCConsole vconsole = administrador.instancia.vcconsole;
   
        public Command(string nombre)
        {
            this.nombre = nombre;
        }

        public Command(string nombre, float[] args)
        {
            this.nombre = nombre;
            this.args = args;
        }

        public virtual void Run()
        {
            Debug.Log("XD");          
        }
    }

    public class VCConsole : MonoBehaviour
    {
        public Text cout;

        public InputField cin;

        public bool active;

        public List<Command> commands = new List<Command>();

        public KeyCode consoleKey;
        public GameObject consola;

        void Start()
        {
            active = false;
            AddCommand(new hola("hola"));
            //AddCommand(new clear("clear"));
        }

        void Update()
        {
            if (Input.GetKeyDown(consoleKey))
            {
                active = !active;
            }
            consola.SetActive(active);
            cin.Select();
        }

        public void cprint(string text, bool onlyConsole = true)
        {
            cout.text += "\n" + text;
            if(onlyConsole && active)
            {
                cin.Select();
            }
        }

        public void SetActive(bool active)
        {
            this.active = active;
        }

        public void ReadCommand()
        {
            string instruction = cin.text;

            if (cin.text != "")
            {
                string[] partes = instruction.Split(' ');

                Debug.Log(partes);

                Command command = null;

                float[] args = new float[partes.Length - 1];

                foreach (Command comando in commands)
                {
                    if (comando.nombre == partes[0])
                    {
                        command = comando;
                        break;
                    }
                }

                if (command == null)
                {
                    cprint("Command not found", true);
                    cin.text = "";
                    return;
                }

                object[] parameters = new object[2];

                for (int i = 1; i < partes.Length; i++)
                {
                    try
                    {
                        args[i-1] = float.Parse(partes[i]);
                    }
                    catch
                    {       
                        cprint("Argument " + i + " is invalid", true);
                        cin.text = "";
                        return;
                    }
                }

                parameters[0] = partes[0];

                parameters[1] = args;
                
                Type t = command.GetType();
                object instance = Activator.CreateInstance(t, parameters);
                MethodInfo commandMethod = t.GetMethod("Run");
                commandMethod.Invoke(instance, null);

                cin.text = "";
                cin.Select();
            }
            cin.Select();
        }
        public void AddCommand(Command command)
        {
            commands.Add(command);
        }
    }
}