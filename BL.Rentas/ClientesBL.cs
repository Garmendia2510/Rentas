using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class ClientesBL
    {
        public BindingList<Cliente> ListaClientes { get; set; }

        public ClientesBL()
        {
            ListaClientes = new BindingList<Cliente>();

            var cliente1 = new Cliente();
            cliente1.Id = 1;
            cliente1.Nombre = "Claudia";
            cliente1.Correo = "claudia@gmail.com";
            cliente1.Telefono = "10";
            cliente1.Direccion = "Choloma";
            cliente1.Activo = true;

            ListaClientes.Add(cliente1);

            var cliente2 = new Cliente();
            cliente2.Id = 2;
            cliente2.Nombre = "Josy";
            cliente2.Correo = "josy@gmail.com";
            cliente2.Telefono = "20";
            cliente2.Direccion = "Puerto Cortés";
            cliente2.Activo = true;

            ListaClientes.Add(cliente2);

            var cliente3 = new Cliente();
            cliente3.Id = 3;
            cliente3.Nombre = "Joselyn";
            cliente3.Correo = "joselyn@gmail.com";
            cliente3.Telefono = "30";
            cliente3.Direccion = "SPS";
            cliente3.Activo = true;

            ListaClientes.Add(cliente3);

            var cliente4 = new Cliente();
            cliente4.Id = 4;
            cliente4.Nombre = "Leonel";
            cliente4.Correo = "leonel@gmail.com";
            cliente4.Telefono = "40";
            cliente4.Direccion = "SPS";
            cliente4.Activo = true;

            ListaClientes.Add(cliente4);

            var cliente5 = new Cliente();
            cliente5.Id = 5;
            cliente5.Nombre = "Zertin";
            cliente5.Correo = "zertin@gmail.com";
            cliente5.Telefono = "50";
            cliente5.Direccion = "SPS";
            cliente5.Activo = true;

            ListaClientes.Add(cliente5);
        }

        public BindingList<Cliente> ObtenerClientes()
        {
            return ListaClientes;
        }

        public resultado GuardarCliente(Cliente cliente)
        {
            var nresultado = validar(cliente);
            if (nresultado.Exitoso== false)
            {
                return nresultado;
            }

            if (cliente.Id == 0)
            {
                cliente.Id = ListaClientes.Max(item => item.Id) + 1;
            }

            nresultado.Exitoso = true;
            return nresultado;
        }

        public void AgregarCliente()
        {
            var nuevoCliente = new Cliente();
            ListaClientes.Add(nuevoCliente);
        }

        public bool EliminarCliente(int id)
        {
            foreach (var cliente in ListaClientes)
            {
                if (cliente.Id == id)
                {
                    ListaClientes.Remove(cliente);
                    return true;
                }
            }

            return false;
        }

        private resultado validar (Cliente cliente)
        {
            var nresultado = new resultado();
            nresultado.Exitoso = true;

            if (string.IsNullOrEmpty(cliente.Nombre) == true)
            {
                nresultado.Mensaje = "Ingrese un Nombre ";
                nresultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Correo) == true)
            {
                nresultado.Mensaje = "Ingrese un Correo ";
                nresultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Telefono) == true)
            {
                nresultado.Mensaje = "Ingrese un Telefono ";
                nresultado.Exitoso = false;
            }

            if (string.IsNullOrEmpty(cliente.Direccion) == true)
            {
                nresultado.Mensaje = "Ingrese una Direccion ";
                nresultado.Exitoso = false;
            }

            return nresultado;
        }
    }

    public class Cliente {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

    }

    public class resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }
}
