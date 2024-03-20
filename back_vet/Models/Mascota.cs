using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_vet.Models
{
    public class Mascota
    {
        public int idMascota { get; set; }
        public string nombre { get; set; }
        public string raza { get; set; }
        public int edad { get; set; }
        public float peso { get; set; }
        public int idMedicamento { get; set; }
        public int idCliente { get; set; }

        public Mascota() { }

        public Mascota(int idMascota, string nombre, string raza, int edad, float peso, int idMedicamento, int idCliente)
        {
            this.idMascota = idMascota;
            this.nombre = nombre;
            this.raza = raza;
            this.edad = edad;
            this.peso = peso;
            this.idMedicamento = idMedicamento;
            this.idCliente = idCliente;
        }

        public Mascota(string nombre, string raza, int edad, float peso, int idMedicamento, int idCliente)
        {
            this.nombre = nombre;
            this.raza = raza;
            this.edad = edad;
            this.peso = peso;
            this.idMedicamento = idMedicamento;
            this.idCliente = idCliente;
        }
    }
}