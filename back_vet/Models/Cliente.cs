using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_vet.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string genero { get; set; }
        public string correo { get; set; }

        public Cliente() { }
        public Cliente(int idCliente, string nombre, string apellido, string direccion, string telefono, string genero, string correo)
        {
            this.idCliente = idCliente; 
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.genero = genero;
            this.correo = correo;
        }

        public Cliente(string nombre, string apellido, string direccion, string telefono, string genero, string correo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.genero = genero;
            this.correo = correo;
        }

    }
}